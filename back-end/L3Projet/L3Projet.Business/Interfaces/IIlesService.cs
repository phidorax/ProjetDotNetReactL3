using L3Projet.Common.Models;

namespace L3Projet.Business.Interfaces
{
    public interface IIlesService
    {
        IEnumerable<Ile> GetAllIles();
        bool AddVillage(Ile ID_Iles, Utilisateur ID_Utilisateur);

    }
}
