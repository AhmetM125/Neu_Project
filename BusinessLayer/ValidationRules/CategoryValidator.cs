using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
