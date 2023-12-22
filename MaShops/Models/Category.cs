using System.ComponentModel.DataAnnotations;

namespace MaShops_Sandbox_1.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
