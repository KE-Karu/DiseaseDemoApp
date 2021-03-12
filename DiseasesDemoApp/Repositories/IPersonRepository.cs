using DiseasesDemoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiseasesDemoApp.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<IReadOnlyCollection<PersonalDisease>> GetDiseasesByPersonId(int id);
    }
}
