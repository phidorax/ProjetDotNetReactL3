using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models {
	public class Monde {
		public Guid ID_Monde { get; set; }
		//[StringLength(50)]
		[StringLength(50, ErrorMessage = "Nom_Monde cannot be longer than 50 characters.")]
		[Column("NomMonde")]
		[Display(Name = "Nom du Monde")]
		[Required]
		public String Nom_Monde { get; set; }
		public String Type_Monde { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime Date_Creation_Monde { get; set; }
		public Boolean Fin_Monde { get; set; }
		[Display(Name = "Full Name")]
		public string FullName
		{
			get
			{
				return Nom_Monde + ", #" + ID_Monde;
			}
		}
		public ICollection<Mer> Liste_Mers { get; set; }
	}
}
