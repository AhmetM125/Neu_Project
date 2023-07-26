using EntityLayer.Concrete;

namespace Neu_Project.Models
{
    public class ShoppingChartItem
    {
        public int ChartId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float TotalPrice { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}