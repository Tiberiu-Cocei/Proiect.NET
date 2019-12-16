using FluentValidation;
using SmartCity.WebApi.Models.BusStation;
using SmartCity.WebApi.ModelValidators.Coordinates;

namespace SmartCity.WebApi.ModelValidators.BusStation
{
    public class CreateBusStationModelValidator : AbstractValidator<CreateBusStationModel>
    {
        public CreateBusStationModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 50);
            RuleFor(x => x.Coordinates).SetValidator(new CoordinatesModelValidator());
        }
    }
}
