using L3Projet.Common.Models;

namespace L3Projet.Business.Interfaces
{
    public interface IUtilisateursService
    {
        IEnumerable<Utilisateur> GetAllUtilisateurs();
        Boolean AddUtilisateur(Utilisateur newUtilisateur);
        Boolean UpdateUtilisateur(Utilisateur utilisateur);
    }
}
