using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;

namespace L3Projet.Business.Implementations {
	public class UtilisateursLocalService : IUtilisateursLocalService {
		private readonly GameContext _gameContext;

		public UtilisateursLocalService(GameContext context) {
			this._gameContext = context;
		}

		public IEnumerable<UtilisateurLocal> GetAllUtilisateursLocal() {
			return _gameContext.UtilisateursLocal.OrderBy(x => x.ID_Local);
		}
	}
}
