using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;

namespace L3Projet.Business.Implementations
{
    public class IlesService : IIlesService
    {
        private readonly GameContext _gameContext;

        public IlesService(GameContext context)
        {
            this._gameContext = context;
        }

        public bool AddVillage(Ile Ile, Utilisateur Utilisateur)
        {
            var newVillage = new Village(Utilisateur.Pseudo + " Nouveau village");
            Ile.ID_Village.Add(newVillage);
            Utilisateur.ID_Liste_Villages.Add(newVillage);
            return true;
        }

        public IEnumerable<Ile> GetAllIles()
        {
            return _gameContext.Iles.OrderBy(x => x.ID_Ile);
        }
    }
}
