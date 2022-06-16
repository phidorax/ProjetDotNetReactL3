using System.ComponentModel.DataAnnotations;

namespace L3Projet.Common.Models
{
    public class Mer
    {
        [Key]
        public Guid ID_Mer { get; set; }
        public float Nombre_d_ile { get; set; }
    }
}
