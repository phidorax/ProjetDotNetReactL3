using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;

namespace L3Projet.Business.Implementations {
	public class CoutRessoucesService : ICoutRessourcesService {
		private readonly GameContext _gameContext;

		public CoutRessoucesService(GameContext context) {
			this._gameContext = context;
		}

		public IEnumerable<CoutRessources> GetAllCoutRessources() {
			return _gameContext.CoutRessources.OrderBy(x => x.ID_Cout_Ressource);
		}
	}
}
