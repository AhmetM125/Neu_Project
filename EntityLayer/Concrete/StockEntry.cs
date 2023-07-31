using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class StockEntry
	{
        [Key]
        [Column(Order = 1)]
        public int TransactionNo { get; set; }
        [Key]
        [Column(Order = 2)]
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
