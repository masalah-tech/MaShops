using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaShops_Sandbox_1.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [ForeignKey("User")]
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public string? PosterPath { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
