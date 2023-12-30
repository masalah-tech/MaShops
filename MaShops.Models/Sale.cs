using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaShops.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        [ForeignKey("User")]
        public int CustomerId { get; set; }
        public User Customer { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
    }
}
