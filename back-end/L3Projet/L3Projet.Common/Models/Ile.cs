using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{
    public class Ile
    {
        public Ile() {   }

        public Ile(string nom_Ile)
        {
            Nom_Ile = nom_Ile;
            ID_Village = new List<Village>(1);
            Score_Ile = 0;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID_Ile { get; set; }
        public String Nom_Ile { get; set; }
        public int Score_Ile { get; set; }
        public ICollection<Village> ID_Village { get; set; }

    }
}
