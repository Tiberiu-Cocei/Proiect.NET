using FluentValidation;
using SmartCity.WebApi.Models.User;

namespace SmartCity.WebApi.ModelValidators.User
{
    public class UserModelValidation : AbstractValidator<UserModel>
    {
        public UserModelValidation()
        {
            RuleFor(x => x.Username).NotEmpty().Length(7, 50);
            RuleFor(x => x.Password).NotEmpty().Length(7, 50);
        }
    }
}
