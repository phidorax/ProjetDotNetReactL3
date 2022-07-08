using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{
    public enum TypeRessources
    {
        Bois, Pierre, Métal, Blé
    }

    public class Ressources
    {
        public Ressources()
        {
            Nom_Ressource = TypeRessources.Pierre;
            Production_Naturelle_Ressource = 10;
        }

        public Ressources(TypeRessources nom_Ressource)
        {
            Nom_Ressource = nom_Ressource;
            Production_Naturelle_Ressource = 10;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID_Ressource { get; set; }
        public TypeRessources Nom_Ressource { get; set; }
        public int Production_Naturelle_Ressource { get; set; }
    }
}
