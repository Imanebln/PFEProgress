namespace PFE.Models
{
    public class Soutenance
    {
        public int Id { get; set; }

        public int IdEtudiant { get; set; }
        public int IdEncadrant{ get; set; }

        public string Sujet { get; set; }
        public DateTime Date { get; }

        public int Jury { get; set; }
    }
}
