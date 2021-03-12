using DiseasesDemoApp.AppDbContext;
using DiseasesDemoApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiseasesDemoApp.Repositories
{
    public sealed class PersonRepository: UniqueEntityRepository<Person>, IPersonRepository
    {
        private readonly DiseasesDbContext context;

        public PersonRepository(DiseasesDbContext con) : base(con, con.Persons) {
            context = con;
        }

        public async Task<IReadOnlyCollection<PersonalDisease>> GetDiseasesByPersonId(int personId)
        {
            return await context.DiseasesOfPerson.Where(o => o.PersonId == personId).ToListAsync();
        }
    }
}
