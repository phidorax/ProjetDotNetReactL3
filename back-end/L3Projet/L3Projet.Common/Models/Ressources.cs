using System.ComponentModel.DataAnnotations;

namespace L3Projet.Common.Models
{
    public class Ressources
    {
        [Key]
        public Guid ID_Ressource { get; set; }
        public String Nom_Ressource { get; set; }
        public int Production_Naturelle_Ressource { get; set; }
    }
}
