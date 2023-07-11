
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ParcialLibros.Models;

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

        public DbSet<ParcialLibros.Models.Venta> Venta { get; set; } = default!;
        public DbSet<ParcialLibros.Models.Proovedor> Proovedor { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
           modelBuilder.Entity<Libro>()
           .HasMany(p=>p.Proovedores)
           .WithMany(p => p.Libros)
           .UsingEntity("LibrosProovedores");

            base.OnModelCreating(modelBuilder);
        } 

    }
}
