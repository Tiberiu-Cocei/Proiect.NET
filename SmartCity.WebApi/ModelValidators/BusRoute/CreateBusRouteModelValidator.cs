using FluentValidation;
using SmartCity.WebApi.Models.BusRoute;
using SmartCity.WebApi.Models.Person;
using SmartCity.WebApi.ModelValidators.BusStation;
using SmartCity.WebApi.ModelValidators.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCity.WebApi.ModelValidators.BusRoute
{
    public class CreateBusRouteModelValidator : AbstractValidator<CreateBusRouteModel>
    {
        public CreateBusRouteModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 50);
            RuleForEach(x => x.BusStations).SetValidator(new BusStationModelValidator());
            RuleFor(x => x.City).SetValidator(new CityModelValidator());
        }
    }
}
