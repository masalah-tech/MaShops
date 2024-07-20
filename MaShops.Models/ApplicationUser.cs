using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace MaShops.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [DisplayName("Second Name")]
        public string? SecondName { get; set; }
        [DisplayName("Third Name")]
        public string? ThirdName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        [Column(TypeName = "Date")]
        [DisplayName("Birth Date")]
        public DateTime? BirthDate { get; set; }
        [DisplayName("Profile Photo")]
        public string? PhotoURL { get; set; }
        public string? Nationality { get; set; }
        public int? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address? Address { get; set; }
    }
}
