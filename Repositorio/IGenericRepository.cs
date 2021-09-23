using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication17.Repositorio
{
    public interface IGenericRepository<T>
    {
        Task Create(T model);
        Task<T> ReadOne(int id);
        Task Update(T model);
        Task Delete(T model);
        Task<IEnumerable<T>> Read();
    }
}
