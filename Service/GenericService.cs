using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication17.Repositorio;

namespace WebApplication17.Service
{
    public class GenericService<T> : IGenericService<T> where T : Models.Ropa
    {
        //Inyeccion de dependencia del repositorio
        private readonly IGenericRepository<T> _repo;
        public GenericService(IGenericRepository<T> repo)
        {
            _repo = repo;
        }
        
        //Metodo para actualizar el registro en la base de datos
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
        
        //Metodo para borrar un registro de la base de datos filtrado por ID
        public async Task Borrar(int id)
        {
            var model = await this.LeerUno(id);
            await _repo.Delete(model);             
        }
        
        //Metotodo para crear un registro en la base de datos
        public async Task Crear(T model)
        {
            await _repo.Create(model);
        }

        //Metodo para traer un registro de la base de datos filtrando por ID
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
        
        //Metodo para traer todos los registros de la base de datos
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
