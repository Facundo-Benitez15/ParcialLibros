using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParcialLibros.Models;

namespace ParcialLibros.Data
{
    public class LibroContext : DbContext
    {
        public LibroContext (DbContextOptions<LibroContext> options)
            : base(options)
        {
        }

        public DbSet<ParcialLibros.Models.Libro> Libro { get; set; } = default!;
    }
}
