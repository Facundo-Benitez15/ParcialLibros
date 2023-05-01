namespace ParcialLibros.Models;

public class Autor
{

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public virtual ICollection<Libro>? Libros { get; set; }

}
