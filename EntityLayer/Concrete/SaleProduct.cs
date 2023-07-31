using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class SaleProduct
	{
		[Key]
		public Nullable<int> TransactionNo { get; set; }
		public float TotalPrice { get; set; }
		public DateTime SaleDate { get; set; }
		public virtual User User { get; set; }
		public int UserId { get; set; }


	}
}
