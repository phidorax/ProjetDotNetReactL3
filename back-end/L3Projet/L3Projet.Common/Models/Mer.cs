using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{
    public class Mer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order=1, TypeName="serial")]
        public Guid ID_Mer { get; set; }
        public string Nom_Mer { get; set; }
        public float Limite_ile { get; set; }
        public int Score_Mer { get; set; }
        public ICollection<Ile> ID_Ile { get; set; }

    }
}
