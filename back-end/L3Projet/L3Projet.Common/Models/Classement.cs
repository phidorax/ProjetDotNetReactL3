using System.ComponentModel.DataAnnotations;

namespace L3Projet.Common.Models
{
    public class Classement
    {
        [Key]
        public float Classement_global
        {
            get
            {
                return 1;
            }
            set{}
        }

        public float Classement_mer { get; set; }
        public float Classement_ile { get; set; }
    }
}
