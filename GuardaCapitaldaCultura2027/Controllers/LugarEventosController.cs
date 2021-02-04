using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuardaCapitaldaCultura2027.Models;
using GuardaCapitaldaCultura2027.Models.Context;
using GuardaCapitaldaCultura2027.Models.ViewModels;

namespace GuardaCapitaldaCultura2027.Controllers
{
    public class LugarEventosController : Controller
    {
        private readonly GuardaEventosBdContext _context;
        private readonly LugaresEvento lugaresEvento;

        public LugarEventosController(GuardaEventosBdContext context)
        {
            _context = context;
            lugaresEvento = new LugaresEvento(context);
        }

        // GET: LugarEventos
        public async Task<IActionResult> Index(int pagina = 1)
        {
            lugaresEvento.Paginacao.PaginaAtual = pagina;
            lugaresEvento.ListaLugares = await _context.LugarEventos.Skip((lugaresEvento.Paginacao.PaginaAtual - 1) * lugaresEvento.Paginacao.ElementosPorPagina).Take(5).ToListAsync();
            return View(lugaresEvento);
        }

        // GET: LugarEventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lugarEvento = await _context.LugarEventos
                .FirstOrDefaultAsync(m => m.LugarEventoId == id);
            if (lugarEvento == null)
            {
                return NotFound();
            }

            return View(lugarEvento);
        }

        // GET: LugarEventos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LugarEventos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LugarEventoId,Ocupado,NumeroCadeira")] LugarEvento lugarEvento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lugarEvento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lugarEvento);
        }

        // GET: LugarEventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lugarEvento = await _context.LugarEventos.FindAsync(id);
            if (lugarEvento == null)
            {
                return NotFound();
            }
            return View(lugarEvento);
        }

        // POST: LugarEventos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LugarEventoId,Ocupado,NumeroCadeira")] LugarEvento lugarEvento)
        {
            if (id != lugarEvento.LugarEventoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lugarEvento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LugarEventoExists(lugarEvento.LugarEventoId))
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
            return View(lugarEvento);
        }

        // GET: LugarEventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lugarEvento = await _context.LugarEventos
                .FirstOrDefaultAsync(m => m.LugarEventoId == id);
            if (lugarEvento == null)
            {
                return NotFound();
            }

            return View(lugarEvento);
        }

        // POST: LugarEventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lugarEvento = await _context.LugarEventos.FindAsync(id);
            _context.LugarEventos.Remove(lugarEvento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LugarEventoExists(int id)
        {
            return _context.LugarEventos.Any(e => e.LugarEventoId == id);
        }
    }
}
