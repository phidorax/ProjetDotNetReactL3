using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;

namespace L3Projet.Business.Implementations {
	public class UtilisateursMicrosoftService : IUtilisateursMicrosoftService {
		private readonly GameContext _gameContext;

		public UtilisateursMicrosoftService(GameContext context) {
			this._gameContext = context;
		}

		public IEnumerable<UtilisateurMicrosoft> GetAllUtilisateursMicrosoft() {
			return _gameContext.UtilisateursMicrosoft.OrderBy(x => x.ID_Microsoft);
		}
	}
}
