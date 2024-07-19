using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaShops.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public ApplicationUser Customer { get; set; }
    }
}
