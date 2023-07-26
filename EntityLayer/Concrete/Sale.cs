using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Sale
	{
        [Key]
        public int SaleId { get; set; }
        [Required]
        public float TotalPrice { get; set; }
       
        public ICollection<SaleProduct> SalesProducts { get; set; }

    }
}
