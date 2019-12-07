using FluentValidation;
using SmartCity.WebApi.Models.Person;
using SmartCity.WebApi.ModelValidators.BusRoute;
using SmartCity.WebApi.ModelValidators.Coordinates;
using SmartCity.WebApi.ModelValidators.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartCity.WebApi.Models.BusStation;

namespace SmartCity.WebApi.ModelValidators.BusStation
{
    public class UpdateBusStationModelValidator : AbstractValidator<UpdateBusStationModel>
    {
        public UpdateBusStationModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().Length(3, 50);
            RuleFor(x => x.Coordinates).SetValidator(new CoordinatesModelValidator());
            RuleForEach(x => x.BusRoutes).SetValidator(new BusRouteModelValidator());
        }
    }
}
