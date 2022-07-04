using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;

namespace L3Projet.Business.Implementations {
	public class MersService : IMersService {
		private readonly GameContext _gameContext;

		public MersService(GameContext context) {
			this._gameContext = context;
		}

		public IEnumerable<Mer> GetAllMers() {
			return _gameContext.Mer.OrderBy(x => x.ID_Mer);
		}
	}
}
