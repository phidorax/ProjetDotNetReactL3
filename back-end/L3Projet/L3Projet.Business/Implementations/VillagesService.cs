using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;

namespace L3Projet.Business.Implementations {
	public class VillagesService : IVillagesService {
		private readonly GameContext _gameContext;

		public VillagesService(GameContext context) {
			this._gameContext = context;
		}

		public IEnumerable<Village> GetAllVillages() {
			return _gameContext.Villages.OrderBy(x => x.ID_Village);
		}
	}
}
