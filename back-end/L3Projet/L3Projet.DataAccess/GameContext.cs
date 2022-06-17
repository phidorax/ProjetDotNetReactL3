using L3Projet.Common;
using L3Projet.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace L3Projet.DataAccess
{
    public class GameContext : DbContext
    {
        public DbSet<Batiment> Batiments { get; set; }
        public DbSet<BatimentParametrage> BatimentsParametrages { get; set; }
        public DbSet<Classement> Classement { get; set; }
        public DbSet<Ile> Iles { get; set; }
        public DbSet<Mer> Mer { get; set; }
        public DbSet<Monde> Mondes { get; set; }
        public DbSet<Parametrage> Table_Parametrages { get; set; }
        public DbSet<Ressources> Ressources { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<UtilisateurLocal> UtilisateursLocal { get; set; }
        public DbSet<UtilisateurMicrosoft> UtilisateursMicrosoft { get; set; }
        public DbSet<Village> Villages { get; set; }

        private readonly string SqlConnectionString;

        public GameContext(IOptions<AppSettings> settings)
        {
            SqlConnectionString = settings.Value.SqlConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
                 => options.UseNpgsql(SqlConnectionString);
    }
}
