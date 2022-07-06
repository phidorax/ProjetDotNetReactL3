using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models {
	public class Utilisateur {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID_Utilisateur { get; set; }
		public string Pseudo { get; set; }
		public string Email { get; set; }
		public UtilisateurLocal ID_Utilisateur_Local { get; set; }
		public UtilisateurMicrosoft ID_Utilisateur_Microsoft { get; set; }
		public ICollection<Monde> ID_Monde { get; set; }
		
		public ICollection<Village> ID_Liste_Villages { get; set; }
	}
}
