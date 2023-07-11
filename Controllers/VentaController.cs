using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParcialLibros.Data;
using ParcialLibros.Models;
using ParcialLibros.Services;
using ParcialLibros.ViewModels;

namespace ParcialLibros.Controllers
{
    public class VentaController : Controller
    {
        private readonly LibroContext _context;
        private readonly IVentaService _ventaService;

        public VentaController(LibroContext context,IVentaService ventaService)
        {
            _context = context;
            _ventaService = ventaService;
        }

        // GET: Venta
        public async Task<IActionResult> Index(string NameFilter)
        {
            //   return _context.Venta != null ? 
            //               View(await _context.Venta.ToListAsync()) :
            //               Problem("Entity set 'LibroContext.Venta'  is null.");


            var model = new VentaViewModel();
            model.Ventas = _ventaService.GetAll(NameFilter);
            //var ventas =_ventaService.GetAll();
            return View(model);  
        }

        // GET: Venta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var venta = _ventaService.GetById(id.Value);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Venta/Create
        public IActionResult Create()
        {
            ViewData["NombreLibros"] = new SelectList(_context.Libro, "Nombre", "Nombre");
            return View();
        }

        // POST: Venta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreLibro,Cantidad")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _ventaService.Create(venta);
                return RedirectToAction(nameof(Index));
            }
            return View(venta);
        }

        // GET: Venta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewData["NombreLibros"] = new SelectList(_context.Libro, "Nombre", "Nombre");
            return View(venta);
        }

        // POST: Venta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreLibro,Cantidad")] Venta venta)
        {
            if (id != venta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   _ventaService.Update(venta);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["NombreLibros"] = new SelectList(_context.Libro, "Nombre", "Nombre");
            return View(venta);
        }

        // GET: Venta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var venta =_ventaService.GetById(id.Value);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _ventaService.Delete(id);        
           return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
          return _ventaService.GetById(id)!=null;
        }
    }
}
