using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{
    public class Village
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Village { get; set; }
        public String Nom_Village { get; set; }
        public int Score_Village { get; set; }
        public ICollection<CoutRessources> List_Cout_Ressources { get; set; }
        public ICollection<Batiment> ID_Batiment { get; set; }

    }
}
