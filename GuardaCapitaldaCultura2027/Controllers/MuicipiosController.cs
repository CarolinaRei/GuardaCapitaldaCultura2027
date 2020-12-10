using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuardaCapitaldaCultura2027.Models;
using GuardaCapitaldaCultura2027.Models.Context;

namespace GuardaCapitaldaCultura2027.Controllers
{
    public class MuicipiosController : Controller
    {
        private readonly GuardaEventosBdContext _context;

        public MuicipiosController(GuardaEventosBdContext context)
        {
            _context = context;
        }

        // GET: Muicipios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Muicipios.ToListAsync());
        }

        // GET: Muicipios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muicipio = await _context.Muicipios
                .FirstOrDefaultAsync(m => m.MuicipioId == id);
            if (muicipio == null)
            {
                return NotFound();
            }

            return View(muicipio);
        }

        // GET: Muicipios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Muicipios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MuicipioId,Nome,ImagemNome")] Muicipio muicipio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(muicipio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(muicipio);
        }

        // GET: Muicipios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muicipio = await _context.Muicipios.FindAsync(id);
            if (muicipio == null)
            {
                return NotFound();
            }
            return View(muicipio);
        }

        // POST: Muicipios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MuicipioId,Nome,ImagemNome")] Muicipio muicipio)
        {
            if (id != muicipio.MuicipioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(muicipio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MuicipioExists(muicipio.MuicipioId))
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
            return View(muicipio);
        }

        // GET: Muicipios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muicipio = await _context.Muicipios
                .FirstOrDefaultAsync(m => m.MuicipioId == id);
            if (muicipio == null)
            {
                return NotFound();
            }

            return View(muicipio);
        }

        // POST: Muicipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var muicipio = await _context.Muicipios.FindAsync(id);
            _context.Muicipios.Remove(muicipio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MuicipioExists(int id)
        {
            return _context.Muicipios.Any(e => e.MuicipioId == id);
        }
    }
}
