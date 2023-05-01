namespace ParcialLibros.Models;

public class Libro
{

    public int Id { get; set; }
    public int AutorId { get; set; }
    public string Nombre { get; set; }
    public string Editorial { get; set; }
    public virtual Autor? Autor { get; set; }

}
