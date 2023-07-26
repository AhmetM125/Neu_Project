using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }
		[Required,StringLength(50)]
		public string Name { get; set; }
		[Required,StringLength(50)]
        public string ContactNumber { get; set; }
		public string Address { get; set; }
		public string City { get; set; }

		
    }
}
