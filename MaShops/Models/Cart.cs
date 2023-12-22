using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaShops_Sandbox_1.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public int CustomerId { get; set; }
        public User Customer { get; set; }
    }
}
