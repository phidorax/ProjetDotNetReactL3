using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{
    public class Batiment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order=1, TypeName="serial")]
        public Guid ID_Batiment { get; set; }
        public String Nom_Batiment { get; set; }
        public int Niveau_Batiment { get; set; }
        public int Score_Total_Batiment { get; set; }
        public ICollection<BatimentParametrage> ID_Batiment_Parametrage { get; set; }

    }
}
