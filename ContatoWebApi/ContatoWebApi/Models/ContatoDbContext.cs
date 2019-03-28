using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContatoWebApi.Models
{
    public class ContatoDbContext : DbContext
    {
        public ContatoDbContext(DbContextOptions<ContatoDbContext> options)
        :base(options)
        { }

        public DbSet<Contato> Contatos { get; set; }
    }
}
