using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication17.Models;
using WebApplication17.Service;

namespace WebApplication17.Controllers
{
    [ApiController]
    [Route("api/ropa")]
    public class RopaController : Controller
    {
        private readonly IGenericService<Ropa> _service;
        public RopaController(IGenericService<Ropa> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ropa>>> GetAll()
        {
            try
            {
                var modelos = await _service.Leer();
                return modelos.ToList();

            }catch(Exception e)
            {
                return StatusCode(404, new { message = e.Message });
            }           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ropa>> GetOne(int id)
        {
            try
            {
                var model = await _service.LeerUno(id);
                return model;
            }catch (Exception e)
            {
                return StatusCode(404, new { message = e.Message});
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> CreateOne(Ropa model)
        {
            await _service.Crear(model);
            return StatusCode(201, new { message = "Se creo el registro en base la datos" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOne(int id, Ropa model)
        {
            try
            {
                model.ID = id;
                await _service.Actualizar(model);
                return StatusCode(201, new { message = "Se actualizo el registro en base de datos"});
            }
            catch (Exception e)
            {
                return StatusCode(404, new { message = e.Message });

            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOne(int id)
        {
            try
            {
                await _service.Borrar(id);
                return StatusCode(200, new { message = "Se borro el registro con exito" });
            }
            catch(Exception e)
            {
                return StatusCode(404, new { message = e.Message });
            }

            
        }
    }
}
