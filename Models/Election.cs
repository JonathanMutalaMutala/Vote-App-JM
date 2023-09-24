using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vote_Application_JonathanMutala.Models
{
    public class Election
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string? Description { get; set; }

      
        public bool IsInProgress { get; set; }

        public bool IsOnCreate { get; set; } 

        public bool IsClose { get; set; } 

        /// <summary>
        /// Représente la clé étrangère 
        /// </summary>
        public int? OrgId { get; set; }

        [ForeignKey("OrgId")]
        public Organization? Organization { get; set; }

        /// <summary>
        /// Représente le pays de l'élection
        /// </summary>
        [StringLength(30)]
        public string? Pays { get; set; }

        /// <summary>
        /// Représente la city de l'élection
        /// </summary>
        [StringLength(30)]
        public string? City { get; set; }

        /// <summary>
        /// Représente le nom de la region 
        /// </summary>
        [StringLength(30)]
        public string? Region { get; set; }

        /// <summary>
        /// Représente la date de début 
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Représente la date de fin 
        /// </summary>
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; } 
    }
}
