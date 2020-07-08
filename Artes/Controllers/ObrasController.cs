using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Artes.Data;
using Artes.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Artes.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ObrasController : Controller
    {
        private readonly ArtesContext _context;

        private readonly IWebHostEnvironment webHostEnvironment;

        public ObrasController(ArtesContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Obras
        public async Task<IActionResult> Index()
        {
            var artesContext = _context.Obras.Include(o => o.Artista).Include(o => o.TipoObra);
            return View(await artesContext.ToListAsync());
        }

        // GET: Obras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.Obras
                .Include(o => o.Artista)
                .Include(o => o.TipoObra)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obra == null)
            {
                return NotFound();
            }
            ViewData["Caminho"] = webHostEnvironment.WebRootPath;
            return View(obra);
        }

        // GET: Obras/Create
        public IActionResult Create()
        {
            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Email");
            ViewData["TipoObraId"] = new SelectList(_context.TipoObras, "Id", "Nome");
            return View();
        }

        // POST: Obras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,TipoObraId,ArtistaId,InspiradaEm,Representa,FotoArte,DataInscricao")] Obra obra, IFormFile Foto)
        {
            if (ModelState.IsValid)
            {
                if (Foto != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images\\obras");
                    var nomeArquivo = Guid.NewGuid().ToString() + "_" + Foto.FileName;
                    string filePath = Path.Combine(uploadsFolder, nomeArquivo);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Foto.CopyToAsync(stream);
                    }

                    obra.FotoArte = "/images/obras/" + nomeArquivo;
                }
                obra.DataInscricao = DateTime.Now;
                _context.Add(obra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Email", obra.ArtistaId);
            ViewData["TipoObraId"] = new SelectList(_context.TipoObras, "Id", "Nome", obra.TipoObraId);
            return View(obra);
        }

        // GET: Obras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.Obras.FindAsync(id);
            if (obra == null)
            {
                return NotFound();
            }
            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Email", obra.ArtistaId);
            ViewData["TipoObraId"] = new SelectList(_context.TipoObras, "Id", "Nome", obra.TipoObraId);
            ViewData["Caminho"] = webHostEnvironment.WebRootPath;
            return View(obra);
        }

        // POST: Obras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,TipoObraId,ArtistaId,InspiradaEm,Representa,FotoArte,DataInscricao")] Obra obra, IFormFile Foto)
        {
            if (id != obra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Foto != null)
                    {
                        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images\\obras");
                        var nomeArquivo = Guid.NewGuid().ToString() + "_" + Foto.FileName;
                        string filePath = Path.Combine(uploadsFolder, nomeArquivo);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await Foto.CopyToAsync(stream);
                        }
                        obra.FotoArte = "/images/obras/" + nomeArquivo;
                    }
                    _context.Update(obra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObraExists(obra.Id))
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
            ViewData["Caminho"] = webHostEnvironment.WebRootPath;
            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Email", obra.ArtistaId);
            ViewData["TipoObraId"] = new SelectList(_context.TipoObras, "Id", "Nome", obra.TipoObraId);
            return View(obra);
        }

        // GET: Obras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.Obras
                .Include(o => o.Artista)
                .Include(o => o.TipoObra)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obra == null)
            {
                return NotFound();
            }

            return View(obra);
        }

        // POST: Obras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obra = await _context.Obras.FindAsync(id);
            _context.Obras.Remove(obra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObraExists(int id)
        {
            return _context.Obras.Any(e => e.Id == id);
        }
    }
}
