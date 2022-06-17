using System.ComponentModel.DataAnnotations;

namespace L3Projet.Common.Models
{
    public class Village
    {
        [Key]
        public Guid ID_Village { get; set; }
        public String Nom_Village { get; set; }
        public int Score_Village { get; set; }
        public int Cout_Ressource1_Village { get; set; }
        public int Cout_Ressource2_Village { get; set; }
        public int Cout_Ressource3_Village { get; set; }
    }
}
