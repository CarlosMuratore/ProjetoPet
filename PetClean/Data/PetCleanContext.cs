using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetClean.Models;

namespace PetClean.Data
{
    public class PetCleanContext : DbContext
    {
        public PetCleanContext (DbContextOptions<PetCleanContext> options)
            : base(options)
        {
        }

        public DbSet<PetClean.Models.Cadastro> Cadastro { get; set; } = default!;

        public DbSet<PetClean.Models.Raca> Raca { get; set; }
    }
}
