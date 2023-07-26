using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class SaleProduct
	{
		[Key]
		public int SaleId { get; set; }
		public Sale Sales { get; set; }
		
		public String TransactionNo { get; set; }

		public int Quantity { get; set; }

        public float Price { get; set; }

		public int ProductId { get; set; }
        public Product Product { get; set; }

		public DateTime SaleDate { get; set; }



	}
}
