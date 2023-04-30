using System.ComponentModel.DataAnnotations;

namespace Vote_Application_JonathanMutala.ViewModel
{
    /// <summary>
    /// Permettant de représenter les informations lors du login
    /// </summary>
    public class LoginViewModel
    {
        public string UserName { get; set; }

        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        [StringLength(255)]
        public string FirstName { get; set; }

        [StringLength(255)]
        public string LastName { get; set; }

        public bool IsActive { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
