using ParcialLibros.Models;
using ParcialLibros.Data;

namespace ParcialLibros.Services;
public class AutorService : IAutorService
{
    private readonly LibroContext _context;


    public AutorService(LibroContext context)
    {
        _context = context;
    }





    public void Create(Autor obj)
    {
        _context.Add(obj);
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

    public List<Autor> GetAll(string filter)
    {
        var query = GetQuery();

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.Nombre.Contains(filter));
        }

        return query.ToList();
    }

    public List<Autor> GetAll()
    {
        var query = GetQuery();
        return query.ToList();
    }

    public Autor? GetById(int id)
    {
        var autor = GetQuery().FirstOrDefault(x => x.Id == id);

        return autor;
    }

    public void Update(Autor obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    private IQueryable<Autor> GetQuery()
    {
        return from autor in _context.Autor select autor;
    }
}