using L3Projet.Common.Models;

namespace L3Projet.Business.Interfaces {
	public interface IRessoucesService {
		IEnumerable<Ressources> GetAllRessources();
	}
}
