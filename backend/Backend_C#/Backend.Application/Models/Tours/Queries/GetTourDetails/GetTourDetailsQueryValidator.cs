using FluentValidation;

namespace Backend.Application.Models.Tours.Queries.GetTourDetails
{
    public class GetTourDetailsQueryValidator
    : AbstractValidator<GetTourDetailsQuery>
    {
        public GetTourDetailsQueryValidator()
        {
            RuleFor(tour =>
                tour.TourId).NotEqual(Guid.Empty);
        }
    }
}
