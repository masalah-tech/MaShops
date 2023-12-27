using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MaShops.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DisplayName("Password")]
        public string EncPassword { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Second Name")]
        public string SecondName { get; set; }
        [Required]
        [DisplayName("Third Name")]
        public string ThirdName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Profile Photo")]
        public string? PhotoPath { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
