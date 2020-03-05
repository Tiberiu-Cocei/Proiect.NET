using FluentValidation;
using SmartCity.WebApi.Models.BusRoute;
using SmartCity.WebApi.ModelValidators.BusStation;

namespace SmartCity.WebApi.ModelValidators.BusRoute
{
    public class UpdateBusRouteModelValidator : AbstractValidator<UpdateBusRouteModel>
    {
        public UpdateBusRouteModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().Length(3, 50);
            RuleForEach(x => x.BusStations).SetValidator(new BusStationModelValidator());
        }
    }
}
