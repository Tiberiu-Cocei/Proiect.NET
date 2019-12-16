using FluentValidation;
using SmartCity.WebApi.Models.City;
using SmartCity.WebApi.ModelValidators.BusRoute;
using SmartCity.WebApi.ModelValidators.PointOfInterest;

namespace SmartCity.WebApi.ModelValidators.City
{
    public class UpdateCityModelValidator : AbstractValidator<UpdateCityModel>
    {
        public UpdateCityModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().Length(3, 50);
            RuleForEach(x => x.BusRoutes).SetValidator(new BusRouteModelValidator());
            RuleForEach(x => x.PointsOfInterests).SetValidator(new PointOfInterestModelValidator());
        }
    }
}