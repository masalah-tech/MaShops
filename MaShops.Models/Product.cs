using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
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
        [DisplayName("Product Main Poster")]
        [ValidateNever]
        public string MainPosterURL { get; set; }
        [Required]
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        [ValidateNever]
        public Store Store { get; set; }
        [Required]
        [ForeignKey("Category")]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        [Required]
        public int InStock { get; set; }
        [Required]
        [DisplayName("Product Description")]
        public string HTMLDescription { get; set; }

    }
}
