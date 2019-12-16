using FluentValidation;
using SmartCity.WebApi.ModelValidators.Coordinates;
using SmartCity.WebApi.Models.Bus;

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
