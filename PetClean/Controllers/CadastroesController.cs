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
    public class CadastroesController : Controller
    {
        private readonly PetCleanContext _context;

        public CadastroesController(PetCleanContext context)
        {
            _context = context;
        }

        // GET: Cadastroes
        public async Task<IActionResult> Index()
        {
            var petCleanContext = _context.Cadastro.Include(c => c.Racas);
            return View(await petCleanContext.ToListAsync());
        }

        // GET: Cadastroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cadastro == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastro
                .Include(c => c.Racas)
                .FirstOrDefaultAsync(m => m.CadastroId == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // GET: Cadastroes/Create
        public IActionResult Create()
        {
            ViewData["RacaId"] = new SelectList(_context.Raca, "RacaId", "RacaId");
            return View();
        }

        // POST: Cadastroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CadastroId,Nome,NomePet,Endereço,Email,Telefone,RacaId")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RacaId"] = new SelectList(_context.Raca, "RacaId", "RacaId", cadastro.RacaId);
            return View(cadastro);
        }

        // GET: Cadastroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cadastro == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastro.FindAsync(id);
            if (cadastro == null)
            {
                return NotFound();
            }
            ViewData["RacaId"] = new SelectList(_context.Raca, "RacaId", "RacaId", cadastro.RacaId);
            return View(cadastro);
        }

        // POST: Cadastroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CadastroId,Nome,NomePet,Endereço,Email,Telefone,RacaId")] Cadastro cadastro)
        {
            if (id != cadastro.CadastroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroExists(cadastro.CadastroId))
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
            ViewData["RacaId"] = new SelectList(_context.Raca, "RacaId", "RacaId", cadastro.RacaId);
            return View(cadastro);
        }

        // GET: Cadastroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cadastro == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastro
                .Include(c => c.Racas)
                .FirstOrDefaultAsync(m => m.CadastroId == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // POST: Cadastroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cadastro == null)
            {
                return Problem("Entity set 'PetCleanContext.Cadastro'  is null.");
            }
            var cadastro = await _context.Cadastro.FindAsync(id);
            if (cadastro != null)
            {
                _context.Cadastro.Remove(cadastro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroExists(int id)
        {
          return _context.Cadastro.Any(e => e.CadastroId == id);
        }
    }
}
