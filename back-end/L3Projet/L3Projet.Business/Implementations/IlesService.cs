using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;

namespace L3Projet.Business.Implementations {
	public class IlesService : IIlesService {
		private readonly GameContext _gameContext;

		public IlesService(GameContext context) {
			this._gameContext = context;
		}

		public IEnumerable<Ile> GetAllIles() {
			return _gameContext.Iles.OrderBy(x => x.ID_Ile);
		}
	}
}
