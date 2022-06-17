using System.ComponentModel.DataAnnotations;

namespace L3Projet.Common.Models
{
    public class Mer
    {
        [Key]
        public Guid ID_Mer { get; set; }
        public string Nom_Mer { get; set; }
        public float Nombre_d_ile { get; set; }
        public int Score_Mer { get; set; }
    }
}
