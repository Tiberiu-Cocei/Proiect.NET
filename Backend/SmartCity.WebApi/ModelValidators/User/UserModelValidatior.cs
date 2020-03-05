using FluentValidation;
using SmartCity.WebApi.Models.User;

namespace SmartCity.WebApi.ModelValidators.User
{
    public class UserModelValidatior : AbstractValidator<UserModel>
    {
        public UserModelValidatior()
        {
            RuleFor(x => x.Username).NotEmpty().Length(7, 50);
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
