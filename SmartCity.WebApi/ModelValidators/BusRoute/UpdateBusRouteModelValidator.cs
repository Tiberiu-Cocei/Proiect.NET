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
