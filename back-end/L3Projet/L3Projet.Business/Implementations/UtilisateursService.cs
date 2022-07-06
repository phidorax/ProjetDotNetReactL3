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
            return _gameContext.Utilisateurs.Include(x => x.ID_Utilisateur_Local).OrderBy(x => x.ID_Utilisateur);
        }

        public bool AddUtilisateur(Utilisateur newUtilisateur)
        {
            var entity = _gameContext.Utilisateurs.Add(newUtilisateur);
            var nbEntitySaved = _gameContext.SaveChanges();
            return entity.State == Microsoft.EntityFrameworkCore.EntityState.Added;
        }

        public bool UpdateUtilisateur(Utilisateur utilisateur)
        {
            var entity = _gameContext.Utilisateurs.Update(utilisateur);
            var nbEntitySaved = _gameContext.SaveChanges();
            return entity.State == Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
