﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please enter a name")]

        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price { get; set; }
        //[Required]

        
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        //

        public ICollection<SaleCart> SaleCarts { get; set; }
        public ICollection<StockEntry> StockEntries { get; set; }


    }
}
