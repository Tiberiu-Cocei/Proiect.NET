using FluentValidation;
using SmartCity.WebApi.ModelValidators.Coordinates;
using SmartCity.WebApi.Models.Bus;

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
