using Microsoft.AspNetCore.Identity;
using Npoi.Mapper.Attributes;
using PFE.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE.Models
{
    public class PFEModel: IdentityUser
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Filiere { get; set; }
        public string Email { get; set; }
        public string Sujet { get; set; }
        public string NomSociete { get; set; }
        public string Ville { get; set; }
        public string TechnologiesUtilisees { get; set; }
        public string EmailEncadrant { get; set; }
    }
}
