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
            RuleFor(x => x.Name).MinimumLength(1).WithMessage("Name cannot be less than 1 character");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty");
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0).WithMessage("Quantity must be greater than equal to 0");
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("Price must be greater than equal to 0"); 
           /* RuleFor(x => x.CategoryId).NotEmpty().WithMessage("");*/

        }
    }
}
