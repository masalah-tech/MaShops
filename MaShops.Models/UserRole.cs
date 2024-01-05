using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaShops.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ValidateNever]
        public User User { get; set; }
        [Required]
        [ForeignKey("Role")]
        [DisplayName("Role")]
        public int RoleId { get; set; }
        [ValidateNever]
        public Role Role { get; set; }
    }
}
