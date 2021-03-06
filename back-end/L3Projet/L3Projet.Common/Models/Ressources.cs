using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{
    public class Ressources
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order=1, TypeName="serial")]
        public Guid ID_Ressource { get; set; }
        public String Nom_Ressource { get; set; }
        public int Production_Naturelle_Ressource { get; set; }
    }
}
