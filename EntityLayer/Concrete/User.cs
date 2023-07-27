using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Required, StringLength(50)]
        public string Username { get; set; }
        [Required, StringLength(50)]
        public string Password { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        [Required]
        public string AdminRole { set; get; }

        public ICollection<SaleProduct> saleProducts;

        /* public string FullName { get; set; }*/
        public ICollection<SaleCart> SaleCarts { get; set; }

    }
}
