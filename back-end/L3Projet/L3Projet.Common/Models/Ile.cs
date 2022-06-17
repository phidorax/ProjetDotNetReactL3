using System.ComponentModel.DataAnnotations;

namespace L3Projet.Common.Models
{
    public class Ile
    {
        [Key]
        public Guid ID_Ile { get; set; }
        public String Nom_Ile { get; set; }
        public int Score_Ile { get; set; }
    }
}
