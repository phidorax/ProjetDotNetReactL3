using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models {
	public class Utilisateur {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column(Order=1, TypeName="serial")]
		public Guid ID_Utilisateur { get; set; }
		public string Pseudo { get; set; }
		public string Email { get; set; }
		public ICollection<UtilisateurLocal> ID_Utilisateur_Local { get; set; }
		public ICollection<UtilisateurMicrosoft> ID_Utilisateur_Microsoft { get; set; }
		public ICollection<Monde> ID_Monde { get; set; }
	}
}
