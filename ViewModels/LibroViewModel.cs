namespace ParcialLibros.ViewModels;
using ParcialLibros.Models;

public class LibrosViewModel
{
    public List<Libro> Libros { get; set; } = new List<Libro>();
    public string? NameFilter { get; set; }
}