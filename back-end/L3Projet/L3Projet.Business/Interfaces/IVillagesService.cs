using L3Projet.Common.Models;

namespace L3Projet.Business.Interfaces
{
    public interface IVillagesService
    {
        IEnumerable<Village> GetAllVillages();
        bool RenameVillage(Guid ID_Village, String name, Utilisateur player);
        bool UpgradeBatiment(Guid ID_Village, Guid ID_Batiment);
    }
}
