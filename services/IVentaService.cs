using ParcialLibros.Models;
namespace ParcialLibros.Services;

public interface IVentaService
{
    void Create(Venta obj);

    List<Venta> GetAll(string filter);
    List<Venta> GetAll();
    void Update(Venta obj);
    void Delete(int id);
    Venta? GetById(int id);
}