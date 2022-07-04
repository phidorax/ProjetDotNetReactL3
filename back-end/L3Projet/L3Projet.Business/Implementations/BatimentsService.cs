using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;

namespace L3Projet.Business.Implementations {
	public class BatimentsService : IBatimentsService {
		private readonly GameContext _gameContext;

		public BatimentsService(GameContext context) {
			this._gameContext = context;
		}

		public IEnumerable<Batiment> getAllBatiments() {
			return _gameContext.Batiments.OrderBy(x => x.ID_Batiment);
		}
	}
}