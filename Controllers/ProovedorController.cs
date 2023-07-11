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

namespace ParcialLibros.Controllers
{
    public class ProovedorController : Controller
    {
        private readonly LibroContext _context;
        private readonly IProovedorService _proovedorService;

        public ProovedorController(LibroContext context,IProovedorService service)
        {
            _context = context;
            _proovedorService = service;

        }

        // GET: Proovedor
        public async Task<IActionResult> Index()
        {
            //   return _context.Proovedor != null ? 
            //               View(await _context.Proovedor.ToListAsync()) :
            //               Problem("Entity set 'LibroContext.Proovedor'  is null.");

            var proovedores = _proovedorService.GetAll();
            return View(proovedores);
        }

        // GET: Proovedor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proovedor = _proovedorService.GetById(id.Value);

            if (proovedor == null)
            {
                return NotFound();
            }

            return View(proovedor);
        }

        // GET: Proovedor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proovedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Proovedor proovedor)
        {
            if (ModelState.IsValid)
            {
                _proovedorService.Create(proovedor);
                return RedirectToAction(nameof(Index));
            }

            return View(proovedor);
        }

        // GET: Proovedor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // if (id == null || _context.Proovedor == null)
            // {
            //     return NotFound();
            // }

            // var proovedor = await _context.Proovedor.FindAsync(id);
            // if (proovedor == null)
            // {
            //     return NotFound();
            // }
            // return View(proovedor);

            if (id == null)
            {
                return NotFound();
            }

            var libro = _proovedorService.GetById(id.Value);
            if (libro == null)
            {
                return NotFound();
            }
            //ViewData["AutorId"] = new SelectList(_context.Proovedor, "Id", "Id", libro.AutorId);
            return View(libro);
        }

        // POST: Proovedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Proovedor proovedor)
        {
            if (id != proovedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _proovedorService.Update(proovedor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProovedorExists(proovedor.Id))
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
            //PODRIA SER UTIL
            //ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Id", libro.AutorId);
            return View(proovedor);
        }

        // GET: Proovedor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proovedor == null)
            {
                return NotFound();
            }

            var proovedor = _proovedorService.GetById(id.Value);
            if (proovedor == null)
            {
                return NotFound();
            }

            return View(proovedor);
        }

        // POST: Proovedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _proovedorService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProovedorExists(int id)
        {
           return _proovedorService.GetById(id) != null;
        }
    }
}
