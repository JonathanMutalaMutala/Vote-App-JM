using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vote_Application_JonathanMutala.Models
{
    public class User : IdentityUser
    {
        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
       
        public bool IsActive { get; set; }
    }
}
