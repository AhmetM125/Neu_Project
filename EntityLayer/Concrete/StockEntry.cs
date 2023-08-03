using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
	public class StockEntry
	{
		[Key]
		public int EntryId { get; set; }
		public int TransactionNo { get; set; }

		public int ProducId { get; set; }
		//FK - Product
		public virtual Product Product { get; set; }

		public DateTime Date { get; set; }
		public float Price { get; set; }

		//User - FK
		public virtual User User { get; set; }
		public int UserId { get; set; }
		//
		public int Quantity { get; set; }

	}
}
