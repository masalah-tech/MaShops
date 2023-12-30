using System.ComponentModel.DataAnnotations;

namespace MaShops.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
