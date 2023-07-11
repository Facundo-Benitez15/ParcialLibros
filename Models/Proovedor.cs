namespace ParcialLibros.Models;

public class Proovedor
{

    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<Libro>? Libros { get; set; }

}
