using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{

    public class StockageRessources
    {
        public StockageRessources()
        {
            Ressource = new Ressources();
            Resource_Stock = 0;
            LastUpdate = DateTime.Now;
            Max_Stock = 1000000;
        }

        public StockageRessources(Ressources ressource, ulong max_Stock)
        {
            Ressource = ressource;
            Resource_Stock = 0;
            LastUpdate = DateTime.Now;
            Max_Stock = max_Stock;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID_Stockage_Ressource { get; set; }
        public Ressources Ressource { get; set; }
        public ulong Resource_Stock { get; set; }
        public ulong Max_Stock { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
