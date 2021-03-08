using DiseasesDemoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiseasesDemoApp.Repositories
{
    public interface IPersonRepository : IRepository<Persons>
    {
        Task<IReadOnlyCollection<PersonalDiseases>> GetDiseasesByPersonId(int id);
    }
}
