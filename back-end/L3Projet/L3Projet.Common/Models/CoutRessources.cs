using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{
    public class CoutRessources
    {
        [Key]
        public int ID_Cout_Ressource { get; set; }
        public int Cout_Ressource { get; set; }
        public Ressources id_ressource { get; set; }
    }
}
