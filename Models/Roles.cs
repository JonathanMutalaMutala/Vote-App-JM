using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vote_Application_JonathanMutala.Models
{
    public class Role : IdentityRole
    {
       

        public string? Description { get; set; }


    }
}
