using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
	public  class EntryCart
    {
        [Key]
        [Column(Order = 1)]
        //FK
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }    
		[Key]
		[Column(Order = 0)]
		public int ChartId { get; set; }
        //FK
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }



    }
}
