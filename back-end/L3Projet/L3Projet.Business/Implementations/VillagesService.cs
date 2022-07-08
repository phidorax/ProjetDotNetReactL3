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

        public bool UpgradeBatiment(Guid ID_Village, Guid ID_Batiment)
        {
            var village = _gameContext.Villages.FirstOrDefault(x => x.ID_Village == ID_Village);
            if (village != null)
            {
                var batiment = village.Liste_Batiment.FirstOrDefault(x => x.ID_Batiment == ID_Batiment);
                if (batiment != null)
                {
                    var totalResourcesInVillage = new Dictionary<TypeRessources, uint>();
                    village.Liste_Batiment.ToList().ForEach(b => b.Liste_Stockage_Ressources.ToList().ForEach(r => totalResourcesInVillage.Add(key: r.Ressource.Nom_Ressource, value: (uint)r.Resource_Stock)));
                    if (batiment.Liste_Cout_Ressources.All(r => r.Cout_Ressource <= totalResourcesInVillage[r.id_ressource.Nom_Ressource]))
                    {
                        var RessourcesNeeds = new Dictionary<TypeRessources, uint>();
                        batiment.Liste_Cout_Ressources.ToList().ForEach(r => RessourcesNeeds.Add(r.id_ressource.Nom_Ressource, (uint)r.Cout_Ressource));
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
                            _gameContext.Update(village);
                            _gameContext.Update(batiment);
                            _gameContext.SaveChanges();
                        }));
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else { return false; }
            return false;
        }
    }
}
