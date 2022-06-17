using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{
    public class Village
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order=1, TypeName="serial")]
        public Guid ID_Village { get; set; }
        public String Nom_Village { get; set; }
        public bool Joueur_Village { get; set; }
        public int Score_Village { get; set; }
        public int Cout_Ressource1_Village { get; set; }
        public int Cout_Ressource2_Village { get; set; }
        public int Cout_Ressource3_Village { get; set; }
        public ICollection<Batiment> ID_Batiment { get; set; }
        public ICollection<Utilisateur> ID_Utilisateur { get; set; }

    }
}
