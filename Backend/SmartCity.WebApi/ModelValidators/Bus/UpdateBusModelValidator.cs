using FluentValidation;
using SmartCity.WebApi.Models.Bus;
using SmartCity.WebApi.ModelValidators.Coordinates;

namespace SmartCity.WebApi.ModelValidators.Bus
{
    public class UpdateBusModelValidator : AbstractValidator<UpdateBusModel>
    {
        public UpdateBusModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Coordinates).SetValidator(new CoordinatesModelValidator());
            RuleFor(x => x.GoingToGarage).NotEmpty();
        }
    }
}
