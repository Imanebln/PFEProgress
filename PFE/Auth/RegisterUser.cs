using System.ComponentModel.DataAnnotations;

namespace PFE.Auth
{
    public class RegisterUser
    {

        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Nom is required")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Prenom is required")]
        public string Prenom { get; set; }


        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public string Filiere = "GI";
    }
}
