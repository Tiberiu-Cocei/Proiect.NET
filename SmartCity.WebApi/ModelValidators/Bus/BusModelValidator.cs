using FluentValidation;
using SmartCity.WebApi.Models.Bus;
using SmartCity.WebApi.ModelValidators.Coordinates;

namespace SmartCity.WebApi.ModelValidators.Bus
{
    public class BusModelValidator : AbstractValidator<BusModel>
    {
        public BusModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Coordinates).SetValidator(new CoordinatesModelValidator());
            RuleFor(x => x.GoingToGarage).NotEmpty();
        }
    }
}
