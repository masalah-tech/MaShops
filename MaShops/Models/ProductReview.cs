using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaShops_Sandbox_1.Models
{
    public class ProductReview
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public int CustomerId { get; set; }
        public User Customer { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public int Rating { get; set; }
        public string? Comment { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
    }
}
