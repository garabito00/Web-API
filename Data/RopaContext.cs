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
        public RopaContext(DbContextOptions<RopaContext> options): base(options)
        {

        }

        public DbSet<Ropa> Ropas { get; set; }
    }
}
