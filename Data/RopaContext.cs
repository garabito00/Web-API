using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication17.Models;

namespace WebApplication17.Data
{
    public class RopaContext: DbContext
    {
        //Inyeccion de dependencia de la conexion a base de datos
        public RopaContext(DbContextOptions<RopaContext> options): base(options)
        {

        }
        
        //DBset para crear la tabla en la base de datos
        public DbSet<Ropa> Ropas { get; set; }
    }
}
