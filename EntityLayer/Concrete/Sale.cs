using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Sale
	{
        [Key]
        public int SaleId { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }

        public ICollection<SaleProduct> SalesProducts { get; set; }

    }
}
