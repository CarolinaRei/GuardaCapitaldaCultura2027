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
    public class LugarEvetosController : Controller
    {
        private readonly GuardaEventosBdContext _context;

        public LugarEvetosController(GuardaEventosBdContext context)
        {
            _context = context;
        }

        // GET: LugarEvetos
        public async Task<IActionResult> Index()
        {
            return View(await _context.LugarEvetos.ToListAsync());
        }

        // GET: LugarEvetos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lugarEveto = await _context.LugarEvetos
                .FirstOrDefaultAsync(m => m.LugarEvetoId == id);
            if (lugarEveto == null)
            {
                return NotFound();
            }

            return View(lugarEveto);
        }

        // GET: LugarEvetos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LugarEvetos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LugarEvetoId,Oucupado,NumeroCadeira")] LugarEveto lugarEveto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lugarEveto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lugarEveto);
        }

        // GET: LugarEvetos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lugarEveto = await _context.LugarEvetos.FindAsync(id);
            if (lugarEveto == null)
            {
                return NotFound();
            }
            return View(lugarEveto);
        }

        // POST: LugarEvetos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LugarEvetoId,Oucupado,NumeroCadeira")] LugarEveto lugarEveto)
        {
            if (id != lugarEveto.LugarEvetoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lugarEveto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LugarEvetoExists(lugarEveto.LugarEvetoId))
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
            return View(lugarEveto);
        }

        // GET: LugarEvetos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lugarEveto = await _context.LugarEvetos
                .FirstOrDefaultAsync(m => m.LugarEvetoId == id);
            if (lugarEveto == null)
            {
                return NotFound();
            }

            return View(lugarEveto);
        }

        // POST: LugarEvetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lugarEveto = await _context.LugarEvetos.FindAsync(id);
            _context.LugarEvetos.Remove(lugarEveto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LugarEvetoExists(int id)
        {
            return _context.LugarEvetos.Any(e => e.LugarEvetoId == id);
        }
    }
}
