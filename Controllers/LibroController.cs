using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParcialLibros.Data;
using ParcialLibros.Models;
using ParcialLibros.ViewModels;
using ParcialLibros.Services;
using Microsoft.AspNetCore.Authorization;

namespace ParcialLibros.Controllers
{
    [Authorize]
    public class LibroController : Controller
    {
        private readonly ILibroService _libroService;

        private readonly LibroContext _context;

        public LibroController(ILibroService libroService,LibroContext context)
        {
            _libroService = libroService;
            _context=context;
        }

        // GET: Libro
        public async Task<IActionResult> Index(string NameFilter)
        {
            var model = new LibrosViewModel();
            model.Libros = _libroService.GetAll(NameFilter);
            return View(model);
        }


        // GET: Libro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = _libroService.GetById(id.Value);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        //GET: Libro/Create
        public IActionResult Create()
        {
            //Utilizar algo parecido para el mostrar en el listado,pero con nombres en lugar de id
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Id");
            ViewData["Proovedores"] = new SelectList(_context.Proovedor, "Id", "Nombre");
            return View();
        }

        // POST: Libro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Proovedores,AutorId,Nombre,Editorial")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _libroService.Create(libro);
                return RedirectToAction(nameof(Index));
            }

            return View(libro);
        }

        // GET: Libro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = _libroService.GetById(id.Value);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Id", libro.AutorId);
            return View(libro);
        }

        // POST: Libro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AutorId,Nombre,Editorial")] Libro libro)
        {
            if (id != libro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _libroService.Update(libro);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Id))
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
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Id", libro.AutorId);
            return View(libro);
        }

        // GET: Libro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = _libroService.GetById(id.Value);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _libroService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _libroService.GetById(id) != null;
        }
    }
}
