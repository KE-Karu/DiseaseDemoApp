using DiseasesDemoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiseasesDemoApp.Repositories
{
    public interface IDiseaseRepository : IRepository<Diseases>
    {
        Task<IReadOnlyCollection<PersonalDiseases>> GetPersonsByDiseaseId(int id);
    }
}
