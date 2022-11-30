using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoredProc_Latt.Models;

namespace StoredProc_Latt.Data
{
    public class StoredProc_LattContext : DbContext
    {
        public StoredProc_LattContext (DbContextOptions<StoredProc_LattContext> options)
            : base(options)
        {
        }

        public DbSet<Train> Train { get; set; } 
    }
}
