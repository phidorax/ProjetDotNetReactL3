using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{
    public class Parametrage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID_Parametrage { get; set; }
        public String Nom_Parametrage { get; set; }
        public DateTime Lancement_Evolution_Parametrage { get; set; }
        public float Temps_Evolution_Parametrage { get; set; }
        public int Vitesse_Evolution_Parametrage { get; set; }
    }
}
