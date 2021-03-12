using DiseasesDemoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiseasesDemoApp.Repositories
{
    public interface IDiseaseRepository : IRepository<Disease>
    {
        Task<IReadOnlyCollection<PersonalDisease>> GetPersonsByDiseaseId(int id);
    }
}
