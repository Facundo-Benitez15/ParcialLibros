using ParcialLibros.Models;
namespace ParcialLibros.Services;

public interface IProovedorService
{
    void Create(Proovedor obj);

    List<Proovedor> GetAll(string filter);
    List<Proovedor> GetAll();
    void Update(Proovedor obj);
    void Delete(int id);
    Proovedor? GetById(int id);
}