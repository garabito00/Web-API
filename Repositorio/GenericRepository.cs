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
        //Inyeccion de dependencia del contexto para comunicar el repositorio con la base de datos.
        private readonly RopaContext _db;
        public GenericRepository(RopaContext db)
        {
            _db = db;
        }
        
        //Metodo para crear el registro en base de datos.
        public async Task Create(T model)
        {
            _db.Set<T>().Add(model);
           await _db.SaveChangesAsync();
        }

        //Metodo para borrar un registro en la base de datos.
        public async Task Delete(T model)
        {
            _db.Set<T>().Remove(model);
            await _db.SaveChangesAsync();
        }
        
        //Metodo para traer todos los registros de la base de datos.
        public async Task<IEnumerable<T>> Read()
        {
            return await _db.Set<T>().ToListAsync();
        }

        //Metodo para traer un solo registro de la base de datos
        public async Task<T> ReadOne(int id)
        {
            
            return await _db.Set<T>().FindAsync(id);
            
        }
        
        //Metodo para actualizar un registro en la base de datos.
        public async Task Update(T model)
        {
            _db.ChangeTracker.Clear();
            _db.Set<T>().Update(model);
            await _db.SaveChangesAsync();
            
        }
    }
}
