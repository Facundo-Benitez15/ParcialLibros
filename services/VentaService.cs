using ParcialLibros.Models;
using ParcialLibros.Data;

namespace ParcialLibros.Services;

public class VentaService : IVentaService
{
    private readonly LibroContext _context;

    public VentaService(LibroContext context)
    {
        _context = context;
    }
    public void Create(Venta obj)
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

    public List<Venta> GetAll(string filter)
    {
        var query = GetQuery();

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.NombreLibro.Contains(filter));
        }

        return query.ToList();
    }

    public List<Venta> GetAll()
    {
        var query = GetQuery();
        return query.ToList();
    }

    public Venta? GetById(int id)
    {
        var Venta = GetQuery().FirstOrDefault(x => x.Id == id);

        return Venta;
    }

    public void Update(Venta obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    private IQueryable<Venta> GetQuery()
    {
        return from Venta in _context.Venta select Venta;
    }
}