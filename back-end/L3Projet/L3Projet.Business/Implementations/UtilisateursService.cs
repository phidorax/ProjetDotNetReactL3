using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;
using Microsoft.EntityFrameworkCore;

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
            return _gameContext.Utilisateurs.Include(x => x.ID_Utilisateur_Local).Include(x => x.ID_Liste_Villages).ThenInclude(x => x.Liste_Batiment).ThenInclude(x => x.Liste_Stockage_Ressources).OrderBy(x => x.ID_Utilisateur);
        }

        public bool AddUtilisateur(Utilisateur newUtilisateur)
        {
            var entity = _gameContext.Utilisateurs.Add(newUtilisateur);
            var nbEntitySaved = _gameContext.SaveChanges();
            return entity.State == EntityState.Added;
        }

        public bool UpdateUtilisateur(Utilisateur utilisateur)
        {
            var entity = _gameContext.Utilisateurs.Update(utilisateur);
            var nbEntitySaved = _gameContext.SaveChanges();
            return entity.State == EntityState.Modified;
        }

        public int CountUtilisateurs()
        {
            return _gameContext.Utilisateurs.Count();
        }
    }
}
