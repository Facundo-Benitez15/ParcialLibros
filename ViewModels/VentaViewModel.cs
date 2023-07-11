namespace ParcialLibros.ViewModels;
using ParcialLibros.Models;

public class VentaViewModel
{
    public List <Venta>? Ventas { get; set; } = new List<Venta>();
    public string? NameFilter { get; set; }
}