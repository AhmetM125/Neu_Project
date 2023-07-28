using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace EntityLayer.Concrete
{
   public class SaleCart
    {
        
            [Key]
            public int ChartId { get; set; }

            public int Quantity { get; set; }
            
            public Nullable<float> Price { get; set; }
            //FK

            public float TotalPrice { get; set; }
            public virtual Product Product { get; set; }
            public int ProductId { get; set; }
            //FK
            public virtual User User { get; set; }
            public int UserId { get; set; }
        }
    }

