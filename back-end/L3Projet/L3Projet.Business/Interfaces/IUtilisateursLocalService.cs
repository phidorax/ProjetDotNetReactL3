using L3Projet.Common.Models;

namespace L3Projet.Business.Interfaces
{
    public interface IUtilisateursLocalService
    {
        IEnumerable<UtilisateurLocal> GetAllUtilisateursLocal();
        UtilisateurLocal? GetUtilisateurLocal(Guid IDUtilisateurLocal);
    }
}
