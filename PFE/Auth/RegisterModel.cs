using System.ComponentModel.DataAnnotations;

namespace PFE.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Nom is required")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Prenom is required")]
        public string Prenom { get; set; }

    }
}
