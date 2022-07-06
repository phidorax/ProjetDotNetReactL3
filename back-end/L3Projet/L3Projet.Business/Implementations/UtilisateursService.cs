using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;

namespace L3Projet.Business.Implementations
{
    public class UtilisateursService : IUtilisateursService
    {
        private readonly GameContext _gameContext;

        public UtilisateursService(GameContext context)
        {
            this._gameContext = context;
        }

        public IEnumerable<Utilisateur> GetAllUtilisateurs()
        {
            return _gameContext.Utilisateurs.OrderBy(x => x.ID_Utilisateur);
        }

        public bool AddUtilisateur(Utilisateur newUtilisateur)
        {
            var entity = _gameContext.Utilisateurs.Add(newUtilisateur);
            var nbEntitySaved = _gameContext.SaveChanges();
            return entity.State == Microsoft.EntityFrameworkCore.EntityState.Added;
        }
    }
}
