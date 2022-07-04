using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;

namespace L3Projet.Business.Implementations {
	public class BatimentParametrageService : IBatimentParametrageService {
		private readonly GameContext _gameContext;

		public BatimentParametrageService(GameContext context) {
			this._gameContext = context;
		}

		public IEnumerable<BatimentParametrage> GetAllBatimentParametrages() {
			return _gameContext.BatimentsParametrages.OrderBy(x => x.ID_Batiment_Parametrage);
		}
	}
}
