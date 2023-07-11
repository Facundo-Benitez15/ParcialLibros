using ParcialLibros.Models;
using ParcialLibros.Data;

namespace ParcialLibros.Services;
public class ProovedorService : IProovedorService
{
    private readonly LibroContext _context;


    public ProovedorService(LibroContext context)
    {
        _context = context;
    }

    public void Create(Proovedor obj)
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

    public List<Proovedor> GetAll(string filter)
    {
        var query = GetQuery();

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.Nombre.Contains(filter));
        }

        return query.ToList();
    }

    public List<Proovedor> GetAll()
    {
        var query = GetQuery();
        return query.ToList();
    }

    public Proovedor? GetById(int id)
    {
        var Proovedor = GetQuery().FirstOrDefault(x => x.Id == id);

        return Proovedor;
    }

    public void Update(Proovedor obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    private IQueryable<Proovedor> GetQuery()
    {
        return from Proovedor in _context.Proovedor select Proovedor;
    }
}