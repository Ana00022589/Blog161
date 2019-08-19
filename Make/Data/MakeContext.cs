using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Make.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Make.Models
{
    public class MakeContext : IdentityDbContext<User>
    {
        public MakeContext (DbContextOptions<MakeContext> options)
            : base(options)
        {
        }

        public DbSet<User> MakeUsers { get; set; }

        public DbSet<Make.Models.Mensagem> Mensagem { get; set; }

        public DbSet<Make.Models.Comentario> Comentario { get; set; }

        public DbSet<Make.Models.Rimel> Rimel { get; set; }
    }
}
