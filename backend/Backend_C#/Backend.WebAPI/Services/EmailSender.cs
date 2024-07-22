using Backend.Application.Services.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;


namespace Backend.Application.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(IConfiguration configuration, ILogger<EmailSender> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("Your App", _configuration["Email:Username"]));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart("plain") { Text = message };

                using (SmtpClient client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await client.ConnectAsync(_configuration["Email:SmtpServer"], int.Parse(_configuration["Email:Port"]), true);
                    await client.AuthenticateAsync(_configuration["Email:Username"], _configuration["Email:Password"]);
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }

                _logger.LogInformation("Email sent to {email}", email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email to {email}", email);
                throw;
            }
        }
    }
}
