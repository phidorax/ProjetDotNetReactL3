using L3Projet.Common;
using L3Projet.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace L3Projet.DataAccess
{
    public class GameContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Mer> Mer { get; set; }
        public DbSet<Monde> Mondes { get; set; }
        public DbSet<Classement> Classement { get; set; }
        public DbSet<Batiment> Batiments { get; set; }
        public DbSet<Ile> Iles { get; set; }
        public DbSet<Ressources> Ressources { get; set; }
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
