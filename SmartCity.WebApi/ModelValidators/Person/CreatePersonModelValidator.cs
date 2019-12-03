using FluentValidation;
using SmartCity.WebApi.Models.Person;

namespace SmartCity.WebApi.ModelValidators.Person
{
    public class CreatePersonModelValidation : AbstractValidator<CreatePersonModel>
    {
        public CreatePersonModelValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().Length(3, 50);
            RuleFor(x => x.LastName).NotEmpty().Length(3, 50);
            RuleFor(x => x.Email).NotEmpty().Length(10, 50);
            RuleFor(x => x.Username).NotEmpty().Length(7, 50);
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
