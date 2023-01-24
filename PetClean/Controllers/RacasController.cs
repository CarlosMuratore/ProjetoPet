using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetClean.Data;
using PetClean.Models;

namespace PetClean.Controllers
{
    public class RacasController : Controller
    {
        private readonly PetCleanContext _context;

        public RacasController(PetCleanContext context)
        {
            _context = context;
        }

        // GET: Racas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Raca.ToListAsync());
        }

        // GET: Racas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Raca == null)
            {
                return NotFound();
            }

            var raca = await _context.Raca
                .FirstOrDefaultAsync(m => m.RacaId == id);
            if (raca == null)
            {
                return NotFound();
            }

            return View(raca);
        }

        // GET: Racas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Racas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RacaId,Racas")] Raca raca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raca);
        }

        // GET: Racas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Raca == null)
            {
                return NotFound();
            }

            var raca = await _context.Raca.FindAsync(id);
            if (raca == null)
            {
                return NotFound();
            }
            return View(raca);
        }

        // POST: Racas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RacaId,Racas")] Raca raca)
        {
            if (id != raca.RacaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RacaExists(raca.RacaId))
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
            return View(raca);
        }

        // GET: Racas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Raca == null)
            {
                return NotFound();
            }

            var raca = await _context.Raca
                .FirstOrDefaultAsync(m => m.RacaId == id);
            if (raca == null)
            {
                return NotFound();
            }

            return View(raca);
        }

        // POST: Racas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Raca == null)
            {
                return Problem("Entity set 'PetCleanContext.Raca'  is null.");
            }
            var raca = await _context.Raca.FindAsync(id);
            if (raca != null)
            {
                _context.Raca.Remove(raca);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RacaExists(int id)
        {
          return _context.Raca.Any(e => e.RacaId == id);
        }
    }
}
