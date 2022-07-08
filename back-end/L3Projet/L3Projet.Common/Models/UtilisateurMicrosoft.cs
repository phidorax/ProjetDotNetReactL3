using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{
    public class UtilisateurMicrosoft
    {
        public UtilisateurMicrosoft(string token)
        {
            Token = token;
        }

        [Key]
        public Guid ID_Microsoft { get; set; }
        public string Token { get; set; }
    }
}
