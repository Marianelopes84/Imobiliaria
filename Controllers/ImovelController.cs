using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Imobiliaria.Data;
using Imobiliaria.Models;

namespace Imobiliaria.Controllers
{
    public class ImovelController : Controller
    {
        private readonly ImobiliariaContext _context;

        public ImovelController(ImobiliariaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var imoveis = _context.Imovel.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {

                imoveis = imoveis.Where(i => i.Tipo.Contains(searchString) || i.Descricao.Contains(searchString));

            }

            return View(await imoveis.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel
                .FirstOrDefaultAsync(m => m.Id == id);

            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Descricao")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imovel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Imovel = await _context.Imovel.FindAsync(id);
            if (Imovel == null)
            {
                return NotFound();
            }
            return View(Imovel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Descricao")] Imovel imovel)
        {
            if (id != imovel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImovelExists(imovel.Id))
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
            return View(imovel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel.FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imovel = await _context.Imovel.FindAsync(id);
            if (imovel != null)
            {
                _context.Imovel.Remove(imovel);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ImovelExists(int id)
        {
            return _context.Imovel.Any(e => e.Id == id);
        }
    }
}
