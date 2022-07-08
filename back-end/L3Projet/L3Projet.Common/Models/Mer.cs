using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{
    public class Mer
    {
        public Mer(string nom_Mer)
        {
            Nom_Mer = nom_Mer;
            Limite_Ile = 6;
            Score_Mer = 0;
            Liste_Iles = new List<Ile>(1);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID_Mer { get; set; }
        public string Nom_Mer { get; set; }
        public float Limite_Ile { get; set; }
        public int Score_Mer { get; set; }
        public ICollection<Ile> Liste_Iles { get; set; }

    }
}
