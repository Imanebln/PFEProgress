using Microsoft.AspNetCore.Identity;
using PFE.Auth;

namespace PFE.Models
{
    public class Encadrant : IdentityUser

    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public string Filiere { get; set; }

    }
}
