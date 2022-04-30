using Microsoft.AspNetCore.Identity;
using PFE.Auth;

namespace PFE.Models
{
    public class Etudiant: IdentityUser
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public string Filiere { get; set; }

        public string PasswordHash { get; set; }

        public Etudiant()
        {
            this.PasswordHash = this.UserName;
        }

        /*public string Email { get; set; }
        public string Sujet { get; set; }
        public string NomSociete { get; set; }
        public string Ville { get; set; }
        public string TechnologiesUtilisees { get; set; }
        public string EmailEncadrant { get; set; }
*/
        /*public string PasswordEtudiant { get; set; }*/
    }
}
