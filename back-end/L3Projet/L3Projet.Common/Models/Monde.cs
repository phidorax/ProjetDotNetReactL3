using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{
    public enum TypeMonde
    {
        PVP,
        PVE,
    }

    public class Monde
    {
        public Monde(string nom_Monde)
        {
            Nom_Monde = nom_Monde;
            Type_Monde = TypeMonde.PVP;
            Date_Creation_Monde = DateTime.Now;
            Fin_Monde = false;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID_Monde { get; set; }
        //[StringLength(50)]
        [StringLength(50, ErrorMessage = "Nom_Monde cannot be longer than 50 characters.")]
        [Column("NomMonde")]
        [Display(Name = "Nom du Monde")]
        [Required]
        public String Nom_Monde { get; set; }
        public TypeMonde Type_Monde { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date_Creation_Monde { get; set; }
        public Boolean Fin_Monde { get; set; }
        public ICollection<Mer> Liste_Mers { get; set; }
        public ICollection<Parametrage> Monde_Parametrage { get; set; }
    }
}
