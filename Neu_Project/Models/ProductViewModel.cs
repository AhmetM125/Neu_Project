using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neu_Project.Models
{
	public class ProductViewModel
	{
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        
		public string Description { get; set; }
        public float Price { get; set; }
       
	}
}