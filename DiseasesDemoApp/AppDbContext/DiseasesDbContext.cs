using DiseasesDemoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiseasesDemoApp.AppDbContext
{
    public class DiseasesDbContext : DbContext
    {
        public DiseasesDbContext(DbContextOptions<DiseasesDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<PersonalDisease> DiseasesOfPerson { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<Person>().ToTable(nameof(Persons)).HasIndex(i => i.NatIdNr).IsUnique();
            builder.Entity<Disease>().ToTable(nameof(Diseases));
            builder.Entity<PersonalDisease>().ToTable(nameof(DiseasesOfPerson));
            //builder.Entity<PersonalDiseases>().HasKey(c => new { c.PersonId, c.DiseaseId });
        }
    }
}
