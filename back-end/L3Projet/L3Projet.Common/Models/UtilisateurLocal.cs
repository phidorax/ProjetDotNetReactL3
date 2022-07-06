using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models {
	public class UtilisateurLocal {
		[Key]
		public int ID_Local { get; set; }
		public string Password { get; set; }
	}
}
