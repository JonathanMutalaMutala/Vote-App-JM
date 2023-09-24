using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace Vote_Application_JonathanMutala.Models
{
    public class Organization
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; } 

    }
}
