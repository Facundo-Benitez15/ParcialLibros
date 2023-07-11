using ParcialLibros.Data;
using ParcialLibros.Models;
using Microsoft.EntityFrameworkCore;

namespace ParcialLibros.Services;

public class LibroService : ILibroService
{

    private readonly LibroContext _context;

    public LibroService(LibroContext context)
    {
        _context = context;
    }


    public void Create(Libro libro)
    {
        _context.Add(libro);
        _context.SaveChanges();

    }

    public void Delete(int id)
    {
        var obj = GetById(id);

        if (obj != null)
        {
            _context.Remove(obj);
            _context.SaveChanges();
        }
    }

    public List<Libro> GetAll(string filter)
    {
        var query = GetQuery();

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.Nombre.Contains(filter) || x.Editorial.Contains(filter));
        }

        return query.ToList();
    }

    public List<Libro> GetAll()
    {
        var query = GetQuery();
        return query.ToList();
    }

    public Libro? GetById(int id)
    {
        var menu = GetQuery()
               .Include(x => x.Autor)
               .FirstOrDefault(m => m.Id == id);

        return menu;
    }

    public void Update(Libro libro)
    {
        _context.Update(libro);
        _context.SaveChanges();
    }

    private IQueryable<Libro> GetQuery()
    {
        return from Libro in _context.Libro select Libro;
    }

}