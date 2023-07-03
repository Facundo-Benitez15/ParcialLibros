using ParcialLibros.Models;
namespace ParcialLibros.Services;

public interface IAutorService
{
    void Create(Autor obj);

    List<Autor> GetAll(string filter);
    List<Autor> GetAll();
    void Update(Autor obj);
    void Delete(int id);
    Autor? GetById(int id);
}