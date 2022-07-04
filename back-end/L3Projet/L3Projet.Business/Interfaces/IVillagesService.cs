using L3Projet.Common.Models;

namespace L3Projet.Business.Interfaces {
	public interface IVillagesService {
		IEnumerable<Village> GetAllVillages();
	}
}
