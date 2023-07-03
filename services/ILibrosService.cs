using ParcialLibros.Models;
namespace ParcialLibros.Services;

public interface ILibroService
{
    void Create(Libro obj);
    List<Libro> GetAll(string filter);
    List<Libro> GetAll();
    void Update(Libro obj);
    void Delete(int id);
    Libro? GetById(int id);
}