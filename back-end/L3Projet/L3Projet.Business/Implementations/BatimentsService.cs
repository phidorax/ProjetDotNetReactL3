using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using L3Projet.DataAccess;
using L3Projet.DataAccess.Interfaces;

namespace L3Projet.Business.Implementations {
	public class BatimentsService : IBatimentsService {
		private readonly GameContext _gameContext;
		private readonly IBatimentDataAccess batimentsDataAccess;

		public BatimentsService(GameContext context) {
			this._gameContext = context;
		}

		public IEnumerable<Batiment> getAllBatiments() {
			return _gameContext.Batiments.OrderBy(x => x.ID_Batiment);
		}
		public async Task<Batiment?> GetById(int id)
		{
			return await batimentsDataAccess.GetById(id);
			// await _gameContext.Batiments.GetById(id);
		}
	}
}