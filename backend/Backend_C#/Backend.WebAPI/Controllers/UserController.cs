using AutoMapper;
using Backend.Application.Models.Users.Commands.CreateUser;
using Backend.Application.Models.Users.Commands.DeleteUser;
using Backend.Application.Models.Users.Commands.UpdateUser;
using Backend.Application.Models.Users.Queries.GetUserDetails;
using Backend.Application.Models.Users.Queries.GetUserList;
using Backend.Domain.Models;
using Backend.WebAPI.Middleware;
using Backend.WebAPI.Models.CreateDto;
using Backend.WebAPI.Models.UpdateDto;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Backend.WebAPI.Controllers
{
    public class UserController : BaseController
    {
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<TourController> _logger;
        private static readonly EmailAddressAttribute _emailAddressAttribute = new();
        string? confirmEmailEndpointName = null;

        public UserController(IEmailSender emailSender, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ILogger<TourController> logger)
        {
            _emailSender = emailSender;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return Ok("Email confirmed successfully.");
            }
            else
            {
                return BadRequest("Error confirming email.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendEmailConfirmation(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Action(nameof(ConfirmEmail), "User", new { userId = user.Id, token = token }, protocol: HttpContext.Request.Scheme);

            await _emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");

            return Ok("Confirmation email sent.");
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action(nameof(ResetPasswordConfirm), "User", new { token = token, email = email }, protocol: HttpContext.Request.Scheme);

            await _emailSender.SendEmailAsync(email, "Reset Password",
                $"Please reset your password by clicking this link: <a href='{callbackUrl}'>link</a>");

            return Ok("Password reset email sent.");
        }

        [HttpPost]
        public async Task<IActionResult> ResetPasswordConfirm(string token, string email, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            if (result.Succeeded)
            {
                return Ok("Password reset successfully.");
            }
            else
            {
                return BadRequest("Error resetting password.");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDetailsVm>> GetUser()
        {
            try
            {
                var UserId = HttpContext.User.GetUserId();
                var query = new GetUserDetailsQuery
                {
                    UserId = UserId
                };
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                var command = _mapper.Map<CreateUserCommand>(createUserDto);
                var UserId = await Mediator.Send(command);
                return Ok(UserId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }

        


        [HttpPut]
        [Authorize(Roles = "User, TourAgency")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
                var UserId = HttpContext.User.GetUserId();
                var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
                command.UserId = UserId;
                await Mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }

        [HttpPut]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdatePasswordUser([FromBody] UpdatePasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }

            return NoContent();
        }



        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var command = new DeleteUserCommand
                {
                    UserId = id
                };
                await Mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserListVm>> GetAllUsers()
        {
            try
            {
                var query = new GetUserListQuery
                {
                };
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }

        [HttpPost]
        public async Task<Results<Ok, ValidationProblem>> UserRegistration([FromBody] RegisterRequest registration, [FromServices] IServiceProvider sp)
        {
            try
            {
                if (!_userManager.SupportsUserEmail)
                {
                    throw new NotSupportedException($"{nameof(UserRegistration)} requires a user store with email support.");
                }

                var userStore = sp.GetRequiredService<IUserStore<User>>();
                var emailStore = (IUserEmailStore<User>)userStore;
                var email = registration.Email;

                if (string.IsNullOrEmpty(email) || !_emailAddressAttribute.IsValid(email))
                {
                    return CreateValidationProblem(IdentityResult.Failed(_userManager.ErrorDescriber.InvalidEmail(email)));
                }

                var user = new User();
                await userStore.SetUserNameAsync(user, email, CancellationToken.None);
                await emailStore.SetEmailAsync(user, email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, registration.Password);

                if (!result.Succeeded)
                {
                    return CreateValidationProblem(result);
                }

                await _userManager.AddToRoleAsync(user, "User");
                return TypedResults.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }


        [HttpPost]
        public async Task<Results<Ok, ValidationProblem>> TourAgencyRegistration([FromBody] RegisterRequest registration, [FromServices] IServiceProvider sp)
        {
            try
            {
                if (!_userManager.SupportsUserEmail)
                {
                    throw new NotSupportedException($"{nameof(TourAgencyRegistration)} requires a user store with email support.");
                }

                var userStore = sp.GetRequiredService<IUserStore<User>>();
                var emailStore = (IUserEmailStore<User>)userStore;
                var email = registration.Email;

                if (string.IsNullOrEmpty(email) || !_emailAddressAttribute.IsValid(email))
                {
                    return CreateValidationProblem(IdentityResult.Failed(_userManager.ErrorDescriber.InvalidEmail(email)));
                }

            var user = new User();
            await userStore.SetUserNameAsync(user, email, CancellationToken.None);
            await emailStore.SetEmailAsync(user, email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, registration.Password);

                if (!result.Succeeded)
                {
                    return CreateValidationProblem(result);
                }

                await _userManager.AddToRoleAsync(user, "TourAgency");
                return TypedResults.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }



        public async Task<Results<Ok<AccessTokenResponse>, EmptyHttpResult, ProblemHttpResult>> Login
        ([FromBody] LoginRequest login, [FromQuery] bool? useCookies, [FromQuery] bool? useSessionCookies, [FromServices] IServiceProvider sp)
        {
            try
            {
                var signInManager = sp.GetRequiredService<SignInManager<User>>();
                var userManager = sp.GetRequiredService<UserManager<User>>();

                var useCookieScheme = (useCookies == true) || (useSessionCookies == true);
                var isPersistent = (useCookies == true) && (useSessionCookies != true);
                signInManager.AuthenticationScheme = useCookieScheme ? IdentityConstants.ApplicationScheme : IdentityConstants.BearerScheme;

                var result = await signInManager.PasswordSignInAsync(login.Email, login.Password, isPersistent, lockoutOnFailure: true);

                if (!result.Succeeded)
                {
                    return TypedResults.Problem(result.ToString(), statusCode: StatusCodes.Status401Unauthorized);
                }

                return TypedResults.Empty;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserInfoVm>> GetUserInfo()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound();
                }

                var roles = await _userManager.GetRolesAsync(user);

                var userInfo = new UserInfoVm
                {
                    Id = user.Id,
                    Roles = roles
                };

                return Ok(userInfo);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }

        private static ValidationProblem CreateValidationProblem(IdentityResult result)
        {
            // We expect a single error code and description in the normal case.
            // This could be golfed with GroupBy and ToDictionary, but perf! :P
            Debug.Assert(!result.Succeeded);
            var errorDictionary = new Dictionary<string, string[]>(1);

            foreach (var error in result.Errors)
            {
                string[] newDescriptions;

                if (errorDictionary.TryGetValue(error.Code, out var descriptions))
                {
                    newDescriptions = new string[descriptions.Length + 1];
                    Array.Copy(descriptions, newDescriptions, descriptions.Length);
                    newDescriptions[descriptions.Length] = error.Description;
                }
                else
                {
                    newDescriptions = [error.Description];
                }

                errorDictionary[error.Code] = newDescriptions;
            }

            return TypedResults.ValidationProblem(errorDictionary);
        }
    }

    public class UpdatePasswordModel
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }

}
