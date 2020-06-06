using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Artes.Data;
using Artes.Models;

namespace Artes.Controllers
{
    public class TipoObrasController : Controller
    {
        private readonly ArtesContext _context;

        public TipoObrasController(ArtesContext context)
        {
            _context = context;
        }

        // GET: TipoObras
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoObras.ToListAsync());
        }

        // GET: TipoObras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoObra = await _context.TipoObras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoObra == null)
            {
                return NotFound();
            }

            return View(tipoObra);
        }

        // GET: TipoObras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoObras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] TipoObra tipoObra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoObra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoObra);
        }

        // GET: TipoObras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoObra = await _context.TipoObras.FindAsync(id);
            if (tipoObra == null)
            {
                return NotFound();
            }
            return View(tipoObra);
        }

        // POST: TipoObras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] TipoObra tipoObra)
        {
            if (id != tipoObra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoObra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoObraExists(tipoObra.Id))
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
            return View(tipoObra);
        }

        // GET: TipoObras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoObra = await _context.TipoObras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoObra == null)
            {
                return NotFound();
            }

            return View(tipoObra);
        }

        // POST: TipoObras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoObra = await _context.TipoObras.FindAsync(id);
            _context.TipoObras.Remove(tipoObra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoObraExists(int id)
        {
            return _context.TipoObras.Any(e => e.Id == id);
        }
    }
}
