using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;

namespace L3Projet.Business.Implementations {
	public class ClassementsService : IClassementsService {
		private readonly GameContext _gameContext;

		public ClassementsService(GameContext context) {
			this._gameContext = context;
		}

		public IEnumerable<Classement> GetAllClassements() {
			return _gameContext.Classement; //.OrderBy(x => x.Classement_global);
		}
	}
}
