using DiseasesDemoApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiseasesDemoApp.Repositories
{
    public abstract class BaseRepository<TData> : IRepository<TData>
        where TData : UniqueEntityData, new()
    {
        protected internal DbContext db;
        protected internal DbSet<TData> dbSet;
        protected BaseRepository(DbContext con, DbSet<TData> s)
        {
            db = con;
            dbSet = s;
        }


        public async Task<TData> Add(TData obj)
        {
            if (obj is null) return null;
            if (IsInDatabase(obj)) await Update(obj);
            else await dbSet.AddAsync(obj);
            await db.SaveChangesAsync();
            return obj;
        }

        public async Task Delete(int id)
        {
            if (id.ToString() is null) return;
            var v = await GetData(id);
            if (v is null) return;
            dbSet.Remove(v);
            await db.SaveChangesAsync();
        }

        public async Task<TData> Update(TData obj)
        {
            db.Update(obj);
            await db.SaveChangesAsync();
            return obj;
        }
        public async Task<TData> GetById(int id)
        {
            if (id.ToString() is null) return null;
            //return await dbSet.AsNoTracking().SingleOrDefaultAsync(o => o.Id.Equals(id));
            return await GetData(id);
        }
        public async Task<List<TData>> GetAll()
        {
            var query = CreateSqlQuery();
            var set = await RunSqlQueryAsync(query);
            return set;
        }

        protected internal virtual IQueryable<TData> CreateSqlQuery()
        {
            var query = from s in dbSet select s;
            return query;
        }
        internal static async Task<List<TData>> RunSqlQueryAsync(IQueryable<TData> query) =>
            await query.AsNoTracking().ToListAsync();

        protected abstract Task<TData> GetData(int id);
        protected abstract TData GetDataById(TData d);
        protected bool IsInDatabase(TData d) => GetDataById(d) != null;
    }
}
