using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAngular.Models
{
    public class EstudoContext : DbContext
    {
        public virtual DbSet<Cliente> Clientes { get; set; }

        public EstudoContext(DbContextOptions<EstudoContext> options)
        : base(options)
        { }

    }
}
