using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        public string OwnerId { get; set; }
        [ValidateNever]
        [ForeignKey("OwnerId")]
        public ApplicationUser Owner { get; set; }
        public string? PosterURL { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
