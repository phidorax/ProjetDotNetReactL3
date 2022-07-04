using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;

namespace L3Projet.Business.Implementations {
	public class ParametragesService : IParametragesService {
		private readonly GameContext _gameContext;

		public ParametragesService(GameContext context) {
			this._gameContext = context;
		}

		public IEnumerable<Parametrage> GetAllParametrages() {
			return _gameContext.Table_Parametrages.OrderBy(x => x.ID_Parametrage);
		}
	}
}
