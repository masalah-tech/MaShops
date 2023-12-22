using System.ComponentModel.DataAnnotations;

namespace MaShops_Sandbox_1.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
