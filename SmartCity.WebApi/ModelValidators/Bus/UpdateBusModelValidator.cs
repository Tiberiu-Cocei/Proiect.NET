using FluentValidation;
using SmartCity.WebApi.Models.Person;
using SmartCity.WebApi.ModelValidators.Coordinates;
using SmartCity.WebApi.ModelValidators.City;
using SmartCity.WebApi.ModelValidators.BusRoute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartCity.WebApi.Models.Bus;

namespace SmartCity.WebApi.ModelValidators.Bus
{
    public class UpdateBusModelValidator : AbstractValidator<UpdateBusModel>
    {
        public UpdateBusModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Coordinates).SetValidator(new CoordinatesModelValidator());
            RuleFor(x => x.BusRoute).SetValidator(new BusRouteModelValidator());
            RuleFor(x => x.GoingToGarage).NotEmpty();
            RuleFor(x => x.City).SetValidator(new CityModelValidator());
        }
    }
}
