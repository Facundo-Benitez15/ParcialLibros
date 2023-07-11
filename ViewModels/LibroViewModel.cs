namespace ParcialLibros.ViewModels;
using ParcialLibros.Models;

public class LibrosViewModel
{
    public List<Libro>? Libros { get; set; } = new List<Libro>();

    public List<Autor>? Autors { get; set; } = new List<Autor>();

    public List<Proovedor>? Proovedors { get; set; } = new List<Proovedor>();
    public string? NameFilter { get; set; }
}