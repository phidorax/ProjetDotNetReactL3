﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3Projet.Common.Models
{
    public class BatimentParametrage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order=1, TypeName="serial")]
        public Guid ID_Batiment_Parametrage { get; set; }
        public String Nom_Batiment_Parametrage { get; set; }
        public float Cout_Bois_Batiment_Parametrage { get; set; }
        public float Cout_Pierre_Batiment_Parametrage { get; set; }
        public float Cout_Argent_Batiment_Parametrage { get; set; }
        public int Score_Progression_Batiment_Parametrage { get; set; }
        public ICollection<Ressources> ID_Ressource { get; set; }

    }
}
