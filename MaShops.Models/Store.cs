using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaShops.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Store Name")]
        public string Name { get; set; }
        [Required]
        [ForeignKey("User")]
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public string? PosterURL { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
