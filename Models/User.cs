using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vote_Application_JonathanMutala.Models
{
    public class User : IdentityUser
    {
        // Id,UserName,Email,PhoneNumber,FirstName,LastName,IsActive Herite de la classe IdentityUser

        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public  string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public bool IsActive { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }



    }
}
