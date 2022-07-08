using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;

namespace L3Projet.Business.Implementations
{
    public class VillagesService : IVillagesService
    {
        private readonly GameContext _gameContext;

        public VillagesService(GameContext context)
        {
            this._gameContext = context;
        }

        public IEnumerable<Village> GetAllVillages()
        {
            return _gameContext.Villages.OrderBy(x => x.ID_Village);
        }

        public bool RenameVillage(Guid ID_Village, String name, Utilisateur player)
        {
            if (player.ID_Liste_Villages != null)
            {
                var village = player.ID_Liste_Villages.FirstOrDefault(village => village.ID_Village == ID_Village);
                if (village == null) { return false; }
                village.Nom_Village = name;
                _gameContext.Villages.Update(village);
                return _gameContext.SaveChanges() == 1;
            }
            else { return false; }
        }

        public Dictionary<TypeRessources, ulong>? GetRessources(Guid ID_Village, Utilisateur player)
        {
            var village = player.ID_Liste_Villages.FirstOrDefault(village => village.ID_Village == ID_Village);
            if (village == null) { return null; }
            var dictionary = new Dictionary<TypeRessources, ulong>();
            village.Liste_Batiment.ToList().ForEach(b => b.Liste_Stockage_Ressources.ToList().ForEach(sr =>
            {
                if (dictionary.ContainsKey(sr.Ressource.Nom_Ressource))
                {
                    dictionary[sr.Ressource.Nom_Ressource] += sr.Resource_Stock;
                }
                else
                {
                    dictionary.Add(sr.Ressource.Nom_Ressource, sr.Resource_Stock);
                }
            }));
            return dictionary;
        }
        public bool UpdateRessources(StockageRessources stockageRessources)
        {
            DateTime now = DateTime.Now;
            TimeSpan diffTime = now - stockageRessources.LastUpdate;
            var addedStock = stockageRessources.Ressource.Production_Naturelle_Ressource * diffTime.TotalSeconds;
            if (stockageRessources.Resource_Stock + addedStock <= stockageRessources.Max_Stock)
            {
                stockageRessources.Resource_Stock += (ulong)addedStock;
            }
            else
            {
                stockageRessources.Resource_Stock = stockageRessources.Max_Stock;
            }
            stockageRessources.LastUpdate = now;
            _gameContext.StockageRessources.Update(stockageRessources);
            return _gameContext.SaveChanges() == 1;

        }

        public bool UpgradeBatiment(Guid ID_Village, Guid ID_Batiment)
        {
            var village = _gameContext.Villages.FirstOrDefault(x => x.ID_Village == ID_Village);
            if (village != null)
            {
                var batiment = village.Liste_Batiment.FirstOrDefault(x => x.ID_Batiment == ID_Batiment);
                if (batiment != null)
                {
                    // Récupération de tous les ressources du village
                    var totalResourcesInVillage = new Dictionary<TypeRessources, uint>();
                    village.Liste_Batiment.ToList().ForEach(b => b.Liste_Stockage_Ressources.ToList().ForEach(r =>
                    {
                        UpdateRessources(r);
                        totalResourcesInVillage[r.Ressource.Nom_Ressource] += ((uint)r.Resource_Stock);
                    }));
                    // On vérifie si on a les resources pour effectuer l'upgrade
                    if (batiment.Liste_Cout_Ressources.All(r => r.Cout_Ressource <= totalResourcesInVillage[r.id_ressource.Nom_Ressource]))
                    {
                        // On déduit la resssource des bâtiments du village
                        var RessourcesNeeds = new Dictionary<TypeRessources, uint>();
                        batiment.Liste_Cout_Ressources.ToList().ForEach(r => RessourcesNeeds[r.id_ressource.Nom_Ressource] += (uint)r.Cout_Ressource);
                        village.Liste_Batiment.ToList().ForEach(b => b.Liste_Stockage_Ressources.ToList().ForEach(r =>
                        {
                            if (r.Resource_Stock <= RessourcesNeeds[r.Ressource.Nom_Ressource])
                            {
                                RessourcesNeeds[r.Ressource.Nom_Ressource] -= (uint)r.Resource_Stock;
                                r.Resource_Stock = 0;
                            }
                            else
                            {
                                r.Resource_Stock -= RessourcesNeeds[r.Ressource.Nom_Ressource];
                                RessourcesNeeds[r.Ressource.Nom_Ressource] = 0;
                            }
                        }));
                        //On augment le niveau du batiment
                        batiment.Niveau_Batiment += 1;

                        // On augment le score du village
                        village.Score_Village += 10 * batiment.Niveau_Batiment;

                        // On augment le score du batiment
                        batiment.Score_Total_Batiment += 10 * batiment.Niveau_Batiment;

                        //On augment le cout d'upgrade du batiment
                        batiment.Liste_Cout_Ressources.ToList().ForEach(cr => cr.Cout_Ressource = (int)(cr.Cout_Ressource * 1.5));

                        //On augment la production par seconde pour ce batiment et la capacité max du batiment
                        batiment.Liste_Stockage_Ressources.ToList().ForEach(sr =>
                        {
                            sr.Ressource.Production_Naturelle_Ressource = (int)(sr.Ressource.Production_Naturelle_Ressource * 1.5);
                            sr.Max_Stock = (ulong)(sr.Max_Stock * 1.5);
                        });

                        // On change la date de fin de construction -> le batiment est de nouveau en construction
                        batiment.Fin_Construction = DateTime.Now.AddMinutes(5 + batiment.Niveau_Batiment);

                        // On update sur la base
                        _gameContext.Update(village);
                        _gameContext.Update(batiment);
                        _gameContext.SaveChanges();
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else { return false; }
        }
    }
}
