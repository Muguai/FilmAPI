using FilmApi.Data_Access;
using FilmApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Data_Access
{
    internal class FilmDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterMovie> CharacterMovie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
            //optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS; Initial Catalog=PostGradDb; Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterMovie>().HasKey(pq => new { pq.CharacterId, pq.MovieId });


            modelBuilder.Entity<Franchise>().HasData(SeedHelper.GetFranchises());
            modelBuilder.Entity<Movie>().HasData(SeedHelper.GetMovies());
            modelBuilder.Entity<Character>().HasData(SeedHelper.GetCharacters());
            /*
            modelBuilder.Entity<ProfessorQualification>().HasKey(pq => new { pq.ProfessorId, pq.QualificationId });

            // Seeding domain entity tables
            modelBuilder.Entity<Professor>().HasData(SeedHelper.GetProfessorSeeds());
            modelBuilder.Entity<Qualification>().HasData(SeedHelper.GetQualificationSeeds());

            // Seeding many to many
            modelBuilder.Entity<ProfessorQualification>().HasData(SeedHelper.GetProfessorQualificationSeeds());

            //modelBuilder.Entity<Professor>()
            //    .HasMany(prof => prof.Qualifications)
            //    .WithMany(qual => qual.Professors)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "ProfessorQualifications",
            //        r => r.HasOne<Qualification>().WithMany().HasForeignKey("QualificationsId"),
            //        l => l.HasOne<Professor>().WithMany().HasForeignKey("ProfessorsId"),
            //        je =>
            //        {
            //            je.HasKey("ProfessorsId", "QualificationsId");
            //            je.HasData(SeedHelper.GetProfessorQualificationSeeds());
            //        }
            //    );
            */
        }

        private string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new()
            {
                DataSource = "localhost\\SQLEXPRESS",
                InitialCatalog = "FilmDb",
                IntegratedSecurity = true,
                TrustServerCertificate = true,
            };

            return builder.ConnectionString;
        }
    }
}

