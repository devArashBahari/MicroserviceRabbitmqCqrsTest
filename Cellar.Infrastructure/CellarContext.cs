using Cellar.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Infrastructure
{
    public class CellarContext : DbContext
    {
        public CellarContext(DbContextOptions<CellarContext> options) : base(options)
        {
        }

        public DbSet<CellarEntity> Cellars { get; set; }


    }
}
