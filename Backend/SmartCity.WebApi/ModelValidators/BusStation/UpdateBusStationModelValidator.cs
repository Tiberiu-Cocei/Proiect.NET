using FluentValidation;
using SmartCity.WebApi.Models.BusStation;
using SmartCity.WebApi.ModelValidators.Bus;
using SmartCity.WebApi.ModelValidators.Coordinates;

namespace SmartCity.WebApi.ModelValidators.BusStation
{
    public class UpdateBusStationModelValidator : AbstractValidator<UpdateBusStationModel>
    {
        public UpdateBusStationModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().Length(3, 50);
            RuleFor(x => x.Coordinates).SetValidator(new CoordinatesModelValidator());
            RuleForEach(x => x.Buses).SetValidator(new BusModelValidator());
        }
    }
}
