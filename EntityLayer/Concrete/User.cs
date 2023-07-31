using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class User
    {
        

        [Key]
        public int Id { get; set; }

        [Required,StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Name { get; set; }

        [Required, StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Email { get; set; }


        [Required, StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string Username { get; set; }

        [Required, StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

       
        public bool Status { get; set; }

        

        public ICollection<Sale> Sales;
        public ICollection<SaleCart> SaleCarts { get; set; }
        public ICollection<StockEntry> StockEntries { get; set; }

    }
}
