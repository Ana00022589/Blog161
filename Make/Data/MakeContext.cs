using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Make.Models;

namespace Make.Models
{
    public class MakeContext : DbContext
    {
        public MakeContext (DbContextOptions<MakeContext> options)
            : base(options)
        {
        }

        public DbSet<Make.Models.Mensagem> Mensagem { get; set; }

        public DbSet<Make.Models.Comentario> Comentario { get; set; }

        public DbSet<Make.Models.Rimel> Rimel { get; set; }
    }
}
