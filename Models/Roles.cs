using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vote_Application_JonathanMutala.Models
{
    public class Roles : IdentityRole
    {
        [Key]
        public int Id {  get; set; }

        public string Name {  get; set; }

        public string Description { get; set; }


    }
}
