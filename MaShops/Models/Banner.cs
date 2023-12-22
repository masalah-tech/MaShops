using System.ComponentModel.DataAnnotations;

namespace MaShops.Models
{
    public class Banner
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PhotoPath { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
