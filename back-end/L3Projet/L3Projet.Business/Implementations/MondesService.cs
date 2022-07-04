using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;

namespace L3Projet.Business.Implementations {
	public class MondesService : IMondesService {
		private readonly GameContext _gameContext;

		public MondesService(GameContext context) {
			this._gameContext = context;
		}

		public IEnumerable<Monde> GetAllMondes() {
			return _gameContext.Mondes.OrderBy(x => x.ID_Monde);
		}
	}
}
