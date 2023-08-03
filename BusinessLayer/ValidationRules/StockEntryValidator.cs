using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
	public class StockEntryValidator : AbstractValidator<Product>
	{
		public StockEntryValidator(Product p)
		{
			RuleFor(x => x.Quantity).LessThan
				(NEUComponent.Instance.ProductService.GetQuantity(p.ProductId)).WithMessage("...");
			RuleFor(x => x.Quantity).GreaterThan(0);
		}
	}
}
