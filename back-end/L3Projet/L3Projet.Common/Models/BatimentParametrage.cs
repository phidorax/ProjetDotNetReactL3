using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{
    public class BatimentParametrage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Batiment_Parametrage { get; set; }
        public String Nom_Batiment_Parametrage { get; set; }
        public int Score_Progression_Batiment_Parametrage { get; set; }
        public ICollection<CoutRessources> List_Cout_Ressources { get; set; }

    }
}
