using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication17.Service
{
    public interface IGenericService<T>
    {
        Task Crear(T model);
        Task<T> LeerUno(int id);
        Task Actualizar(T model);
        Task Borrar(int id);
        Task<IEnumerable<T>> Leer();
    }
}
