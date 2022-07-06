using System.ComponentModel.DataAnnotations;

namespace L3Projet.Common.Models
{
    public class UtilisateurLocal
    {
        public UtilisateurLocal() { }

        public UtilisateurLocal(string hashPassword)
        {
            Password = hashPassword;
        }

        [Key]
        public Guid ID_Local { get; set; }
        public string Password { get; set; }
    }
}
