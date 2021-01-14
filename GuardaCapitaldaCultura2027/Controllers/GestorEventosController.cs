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
    public class GestorEventosController : Controller
    {
        private readonly GuardaEventosBdContext _context;

        public GestorEventosController(GuardaEventosBdContext context)
        {
            _context = context;
        }

        // GET: GestorEventos
        public async Task<IActionResult> Index()
        {
            return View(await _context.GestorEventos.ToListAsync());
        }

        // GET: GestorEventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestorEventos = await _context.GestorEventos
                .FirstOrDefaultAsync(m => m.GestorEventosId == id);
            if (gestorEventos == null)
            {
                return NotFound();
            }

            return View(gestorEventos);
        }

        // GET: GestorEventos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GestorEventos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GestorEventosId,Nome,Apelido,Contacto,NIF,Email,Password")] GestorEventos gestorEventos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gestorEventos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gestorEventos);
        }

        // GET: GestorEventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestorEventos = await _context.GestorEventos.FindAsync(id);
            if (gestorEventos == null)
            {
                return NotFound();
            }
            return View(gestorEventos);
        }

        // POST: GestorEventos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GestorEventosId,Nome,Apelido,Contacto,NIF,Email,Password")] GestorEventos gestorEventos)
        {
            if (id != gestorEventos.GestorEventosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gestorEventos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GestorEventosExists(gestorEventos.GestorEventosId))
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
            return View(gestorEventos);
        }

        // GET: GestorEventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestorEventos = await _context.GestorEventos
                .FirstOrDefaultAsync(m => m.GestorEventosId == id);
            if (gestorEventos == null)
            {
                return NotFound();
            }

            return View(gestorEventos);
        }

        // POST: GestorEventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gestorEventos = await _context.GestorEventos.FindAsync(id);
            _context.GestorEventos.Remove(gestorEventos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GestorEventosExists(int id)
        {
            return _context.GestorEventos.Any(e => e.GestorEventosId == id);
        }
    }
}
