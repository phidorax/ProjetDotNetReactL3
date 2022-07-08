using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{
    public enum TypeBatiment
    {
        Mairie,
        Scierie,
        Mine_de_fer,
        Carrière,
        Entrepôt,
        Ferme
    }

    public class Batiment
    {
        public Batiment()
        {
            Nom_Batiment = TypeBatiment.Mairie;
            Niveau_Batiment = 1;
            Score_Total_Batiment = 0;
            GenerateStockage();
            ID_Batiment_Parametrage = new List<BatimentParametrage>();
        }

        public Batiment(TypeBatiment nom_Batiment)
        {
            Nom_Batiment = nom_Batiment;
            Niveau_Batiment = 1;
            Score_Total_Batiment = 0;
            Liste_Cout_Ressources = new List<CoutRessources>();
            Liste_Cout_Ressources.Add(new CoutRessources(new Ressources(TypeRessources.Bois), 2500));
            Liste_Cout_Ressources.Add(new CoutRessources(new Ressources(TypeRessources.Pierre), 2500));
            Liste_Cout_Ressources.Add(new CoutRessources(new Ressources(TypeRessources.Métal), 2500));
            GenerateStockage();
            ID_Batiment_Parametrage = new List<BatimentParametrage>();
        }

        private void GenerateStockage()
        {
            Liste_Stockage_Ressources = new List<StockageRessources>();
            switch (Nom_Batiment)
            {
                case TypeBatiment.Mairie:
                    break;

                case TypeBatiment.Scierie:
                    Liste_Stockage_Ressources.Add(new StockageRessources(new Ressources(TypeRessources.Bois), 10000));
                    break;

                case TypeBatiment.Mine_de_fer:
                    Liste_Stockage_Ressources.Add(new StockageRessources(new Ressources(TypeRessources.Métal), 10000));
                    break;

                case TypeBatiment.Carrière:
                    Liste_Stockage_Ressources.Add(new StockageRessources(new Ressources(TypeRessources.Pierre), 10000));
                    break;

                case TypeBatiment.Entrepôt:
                    Liste_Stockage_Ressources.Add(new StockageRessources(new Ressources(TypeRessources.Bois), 1000000));
                    Liste_Stockage_Ressources.Add(new StockageRessources(new Ressources(TypeRessources.Métal), 1000000));
                    Liste_Stockage_Ressources.Add(new StockageRessources(new Ressources(TypeRessources.Pierre), 1000000));
                    Liste_Stockage_Ressources.Add(new StockageRessources(new Ressources(TypeRessources.Blé), 1000000));
                    break;

                case TypeBatiment.Ferme:
                    Liste_Stockage_Ressources.Add(new StockageRessources(new Ressources(TypeRessources.Pierre), 10000));
                    break;

            }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID_Batiment { get; set; }
        public TypeBatiment Nom_Batiment { get; set; }
        public int Niveau_Batiment { get; set; }
        public int Score_Total_Batiment { get; set; }
        public ICollection<CoutRessources> Liste_Cout_Ressources { get; set; }
        public ICollection<StockageRessources> Liste_Stockage_Ressources { get; set; }
        public ICollection<BatimentParametrage> ID_Batiment_Parametrage { get; set; }

    }
}
