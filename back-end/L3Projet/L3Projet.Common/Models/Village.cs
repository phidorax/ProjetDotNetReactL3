using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{
    public class Village
    {
        public Village(string nom_Village)
        {
            Nom_Village = nom_Village;
            Liste_Cout_Ressources = new List<CoutRessources>();
            Liste_Cout_Ressources.Add(new CoutRessources(new Ressources(TypeRessources.Bois), 5000));
            Liste_Cout_Ressources.Add(new CoutRessources(new Ressources(TypeRessources.Métal), 5000));
            Liste_Cout_Ressources.Add(new CoutRessources(new Ressources(TypeRessources.Pierre), 5000));
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID_Village { get; set; }
        public String Nom_Village { get; set; }
        public int Score_Village { get; set; }
        public ICollection<CoutRessources> Liste_Cout_Ressources { get; set; }
        public ICollection<Batiment> Liste_Batiment { get; set; }

    }
}
