using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
	{
		public UserValidator() 

		{

          /*  RuleFor(x => x.Name).MinimumLength(3).WithMessage("Name cannot be null");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be null");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be null");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be null");*/



        }

    }
}
