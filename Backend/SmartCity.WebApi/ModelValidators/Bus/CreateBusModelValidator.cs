using FluentValidation;
using SmartCity.WebApi.Models.Bus;
using SmartCity.WebApi.ModelValidators.Coordinates;

namespace SmartCity.WebApi.ModelValidators.Bus
{
    public class CreateBusModelValidator : AbstractValidator<CreateBusModel>
    {
        public CreateBusModelValidator()
        {
            RuleFor(x => x.Coordinates).SetValidator(new CoordinatesModelValidator());
        }
    }
}
