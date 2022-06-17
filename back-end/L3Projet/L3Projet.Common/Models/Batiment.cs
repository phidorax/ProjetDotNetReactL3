using System.ComponentModel.DataAnnotations;

namespace L3Projet.Common.Models
{
    public class Batiment
    {
        [Key]
        public Guid ID_Batiment { get; set; }
        public String Nom_Batiment { get; set; }
        public float Cout_Batiment { get; set; }
        public int Niveau_Batiment { get; set; }
        public int Score_Batiment { get; set; }
    }
}
