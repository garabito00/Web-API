using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication17.Data;

namespace WebApplication17.Repositorio
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Models.Ropa
    {
        private readonly RopaContext _db;
        public GenericRepository(RopaContext db)
        {
            _db = db;
        }
        public async Task Create(T model)
        {
            _db.Set<T>().Add(model);
           await _db.SaveChangesAsync();
        }

        public async Task Delete(T model)
        {
            _db.Set<T>().Remove(model);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Read()
        {
            return await _db.Set<T>().ToListAsync();
        }


        public async Task<T> ReadOne(int id)
        {
            
            return await _db.Set<T>().FindAsync(id);
            
        }

        public async Task Update(T model)
        {
            _db.ChangeTracker.Clear();
            _db.Set<T>().Update(model);
            await _db.SaveChangesAsync();
            
        }
    }
}
