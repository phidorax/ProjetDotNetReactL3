using System.ComponentModel.DataAnnotations;

namespace L3Projet.Common.Models
{
    public class Classement
    {
        [Key]
        public float Classement_global
        { get; set; }

        public float Classement_mer { get; set; }
        public float Classement_ile { get; set; }
        public ICollection<Monde> ID_Monde { get; set; }
        public ICollection<Mer> ID_Mer { get; set; }
        public ICollection<Ile> ID_Ile { get; set; }

    }
}
