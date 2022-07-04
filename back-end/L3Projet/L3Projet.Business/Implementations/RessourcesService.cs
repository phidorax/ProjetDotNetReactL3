using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;

namespace L3Projet.Business.Implementations {
	public class RessourcesService : IRessoucesService {
		private readonly GameContext _gameContext;

		public RessourcesService(GameContext context) {
			this._gameContext = context;
		}

		public IEnumerable<Ressources> GetAllRessources() {
			return _gameContext.Ressources.OrderBy(x => x.ID_Ressource);
		}
	}
}
