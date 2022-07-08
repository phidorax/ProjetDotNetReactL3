using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{
    public class CoutRessources
    {
        public CoutRessources()
        {
            Cout_Ressource = 5000;
            id_ressource = new Ressources();
        }

        public CoutRessources(Ressources id_ressource, int cout_Ressource)
        {
            Cout_Ressource = cout_Ressource;
            this.id_ressource = id_ressource;
        }

        [Key]
        public int ID_Cout_Ressource { get; set; }
        public int Cout_Ressource { get; set; }
        public Ressources id_ressource { get; set; }
    }
}
