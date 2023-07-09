namespace ParcialLibros.ViewModels;
using ParcialLibros.Models;

public class LibrosViewModel
{
    public List<Libro>? Libros { get; set; } = new List<Libro>();

    //No utilizado:Usar para listar los nombres en los campos.
    public List <Autor>? Autors { get; set; } = new List<Autor>();
    public string? NameFilter { get; set; }
}