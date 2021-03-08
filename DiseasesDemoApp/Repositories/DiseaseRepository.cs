using DiseasesDemoApp.AppDbContext;
using DiseasesDemoApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiseasesDemoApp.Repositories
{
    public sealed class DiseaseRepository : UniqueEntityRepository<Diseases>, IDiseaseRepository
    {
        private readonly DiseasesDbContext context;

        public DiseaseRepository(DiseasesDbContext con) : base(con, con.Diseases) {
            context = con;
        }

        public async Task<IReadOnlyCollection<PersonalDiseases>> GetPersonsByDiseaseId(int diseaseId)
        {
            return await context.DiseasesOfPerson.Where(o => o.DiseaseId == diseaseId).ToListAsync();
        }
    }
}