using DiseasesDemoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiseasesDemoApp.AppDbContext
{
    public class DiseasesDbContext : DbContext
    {
        public DiseasesDbContext(DbContextOptions<DiseasesDbContext> options) : base(options) { }

        public DbSet<Persons> Persons { get; set; }
        public DbSet<Diseases> Diseases { get; set; }
        public DbSet<PersonalDiseases> DiseasesOfPerson { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<Persons>().ToTable(nameof(Persons)).HasIndex(i => i.NatIdNr).IsUnique();
            builder.Entity<Diseases>().ToTable(nameof(Diseases));
            builder.Entity<PersonalDiseases>().ToTable(nameof(DiseasesOfPerson));
            //builder.Entity<PersonalDiseases>().HasKey(c => new { c.PersonId, c.DiseaseId });
        }
    }
}
