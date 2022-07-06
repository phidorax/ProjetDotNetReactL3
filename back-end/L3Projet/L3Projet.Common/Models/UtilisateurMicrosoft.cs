using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models {
	public class UtilisateurMicrosoft {
		[Key]
		public int ID_Microsoft { get; set; }
		public string Token { get; set; }
	}
}
