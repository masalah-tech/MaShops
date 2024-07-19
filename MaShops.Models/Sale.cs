using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaShops.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public ApplicationUser Customer { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
    }
}
