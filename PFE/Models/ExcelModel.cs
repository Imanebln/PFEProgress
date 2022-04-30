using Npoi.Mapper.Attributes;

namespace PFE.Models
{
    public class ExcelModel
    {
        [Column("Nom")]
        public string Nom { get; set; }
        [Column("Prenom")]
        public string Prenom { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Sujet")]
        public string Sujet { get; set; }
        [Column("NomSociete")]
        public string NomSociete { get; set; }
        [Column("Ville")]
        public string Ville { get; set; }
        [Column("TechnologiesUtilisees")]
        public string TechnologiesUtilisees { get; set; }
        [Column("EmailEncadrant")]
        public string EmailEncadrant { get; set; }
        [Column("Filiere")]
        public string Filiere { get; set; }
    }
}
