
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ParcialLibros.Data
{
    public class LibroContext : IdentityDbContext
    {
        public LibroContext(DbContextOptions<LibroContext> options)
            : base(options)
        {
        }
        public DbSet<ParcialLibros.Models.Autor> Autor { get; set; } = default!;

        public DbSet<ParcialLibros.Models.Libro> Libro { get; set; } = default!;

        // public DbSet<ParcialLibros.Models.Autor> Autor { get; set; } = default!;


    }
}
