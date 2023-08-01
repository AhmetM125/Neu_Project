using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
	public class Sale
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		[Column(Order = 1)]
		public int TransactionNo { get; set; }
		[Key]
		[Column(Order = 2)]
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }

		public int Quantity { get; set; }
		public float Price { get; set; }
		public DateTime SaleDate { get; set; }
		public virtual User User { get; set; }
		public int UserId { get; set; }


	}
}
