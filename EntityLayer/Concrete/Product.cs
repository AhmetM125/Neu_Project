using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Product
	{
		[Key]
        public int ProductId { get; set; }
		[Required]
		[StringLength(50)]
		public string Name { get; set; }
		[StringLength(100)]
		public string Description { get; set; }
		[Required]
        public int Quantity { get; set; }
		[Required]
        public float Price { get; set; }
		[Required]
		public int CategoryId { get; set; }
		public Category Category { get; set; }

    }
}
