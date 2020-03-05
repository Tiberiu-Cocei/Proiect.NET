using FluentValidation;
using SmartCity.WebApi.Models.BusRoute;
using SmartCity.WebApi.ModelValidators.BusStation;

namespace SmartCity.WebApi.ModelValidators.BusRoute
{
    public class CreateBusRouteModelValidator : AbstractValidator<CreateBusRouteModel>
    {
        public CreateBusRouteModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 50);
            RuleForEach(x => x.BusStations).SetValidator(new BusStationModelValidator());
        }
    }
}
