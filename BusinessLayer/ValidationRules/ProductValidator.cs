using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ProductValidator :AbstractValidator<Product>
	{
		public ProductValidator() 
		{
			RuleFor(x => x.Name).MinimumLength(1).WithMessage("asda");
			RuleFor(x=>x.Description).NotEmpty().WithMessage("... Error");
			RuleFor(x => x.Quantity).LessThan(0).WithMessage("... Error");
			RuleFor(x => x.Price).LessThan(0).WithMessage("... Error"); RuleFor(x => x.Price).LessThan(0).WithMessage("... Error");
			RuleFor(x => x.CategoryId).NotEmpty().WithMessage("... Error");

		}
	}
}
