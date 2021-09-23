using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication17.Repositorio;

namespace WebApplication17.Service
{
    public class GenericService<T> : IGenericService<T> where T : Models.Ropa
    {
        private readonly IGenericRepository<T> _repo;
        public GenericService(IGenericRepository<T> repo)
        {
            _repo = repo;
        }
        public async Task Actualizar(T model)
        {
            if (!(await this.LeerUno(model.ID) == null))
            {
                await _repo.Update(model);
            }
            else
            {
                throw new Exception("No se encontro el registro en la Base de Datos");
            }
            
        }

        public async Task Borrar(int id)
        {
            var model = await this.LeerUno(id);
            await _repo.Delete(model);             
        }

        public async Task Crear(T model)
        {
            await _repo.Create(model);
        }


        public async Task<T> LeerUno(int id)
        {
            var model = await _repo.ReadOne(id);
            if(!(model == null))
            {
                return model;
            } else
            {
                throw new Exception("Recurso no existe en Base de datos");
            }
            
        }
        
        public async Task<IEnumerable<T>> Leer()
        {
            var modelos = await _repo.Read();
            if (!(modelos.Count() == 0))
            {
                return modelos;
            }
            else
            {
                throw new Exception("La base de datos no tiene datos");
            }
        }
    }
}
