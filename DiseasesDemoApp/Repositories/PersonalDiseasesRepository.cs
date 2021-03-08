using DiseasesDemoApp.AppDbContext;
using DiseasesDemoApp.Models;

namespace DiseasesDemoApp.Repositories
{
    public sealed class PersonalDiseasesRepository : UniqueEntityRepository<PersonalDiseases>, IPersonalDiseasesRepository
    {
        public PersonalDiseasesRepository(DiseasesDbContext c) : base(c, c.DiseasesOfPerson) { }

    }
}
