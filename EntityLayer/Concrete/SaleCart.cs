using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class SaleCart
    {

        [Key]
        [Column(Order = 1)]
        public int ChartId { get; set; }
        //FK
        public virtual User User { get; set; }
        [Key]
        [Column(Order = 2)]
        public int UserId { get; set; }
        public int Quantity { get; set; }

        public Nullable<float> Price { get; set; }
        //FK

        public float TotalPrice { get; set; }
        public virtual Product Product { get; set; }
        [Key]
        [Column(Order =3)]
        public int ProductId { get; set; }

    }
}

