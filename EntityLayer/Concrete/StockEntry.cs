using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class StockEntry
	{
        [Key]
        public int InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public float TotalPrice { get; set; }


    }
}
