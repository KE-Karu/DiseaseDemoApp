using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiseasesDemoApp.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Delete(int id);
        Task<T> Add(T obj);
        Task<T> Update(T obj);
    }
}
