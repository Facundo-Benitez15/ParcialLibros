namespace ParcialLibros.ViewModels;
using ParcialLibros.Models;

public class ProovedoresViewModel
{
    public List <Proovedor>? Proovedores { get; set; } = new List<Proovedor>();
    public string? NameFilter { get; set; }
}