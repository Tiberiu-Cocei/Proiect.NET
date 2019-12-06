﻿using FluentValidation;
using SmartCity.WebApi.Models.Person;
using SmartCity.WebApi.ModelValidators.PointOfInterest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCity.WebApi.ModelValidators.Person
{
    public class PersonModelValidator : AbstractValidator<PersonModel>
    {
        public PersonModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty().Length(3, 50);
            RuleFor(x => x.LastName).NotEmpty().Length(3, 50);
            RuleFor(x => x.Email).NotEmpty().Length(10, 50);
            RuleFor(x => x.Coordinates.Longitude).NotEmpty().GreaterThanOrEqualTo(-180).LessThanOrEqualTo(180);
            RuleFor(x => x.Coordinates.Latitude).NotEmpty().GreaterThanOrEqualTo(-90).LessThanOrEqualTo(90);
            RuleForEach(x => x.PointOfInterestModels).SetValidator(new PointOfInterestModelValidator());
            RuleFor(x => x.Username).NotEmpty().Length(7, 50);
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}