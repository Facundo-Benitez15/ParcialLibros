namespace ParcialLibros.ViewModels;
using ParcialLibros.Models;

public class AutorViewModel
{
    public List <Autor>? Autors { get; set; } = new List<Autor>();
    public string? NameFilter { get; set; }
}