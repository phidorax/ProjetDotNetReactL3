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
    }
}
