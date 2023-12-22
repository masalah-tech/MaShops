using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaShops.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double? OldPrice { get; set; }
        [Required]
        public double NewPrice { get; set; }
        [Required]
        public string MainPosterPath { get; set; }
        [Required]
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public Store Store { get; set; }
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public int InStock { get; set; }
        [Required]
        public string HTMLDescription { get; set; }

    }
}
