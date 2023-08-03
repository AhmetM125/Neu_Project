using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
	public class CategoryValidator : AbstractValidator<Category>
	{
		public CategoryValidator() {
			
			RuleFor(x=>x.Name).NotEmpty().WithMessage("Name cannot be null");
			RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be null");


		}
	}
}
