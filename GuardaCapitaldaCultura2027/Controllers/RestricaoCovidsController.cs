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
    public class RestricaoCovidsController : Controller
    {
        private readonly GuardaEventosBdContext _context;
        private readonly RestricoesCovid restricoesCovid;

        public RestricaoCovidsController(GuardaEventosBdContext context)
        {
            _context = context;
            restricoesCovid = new RestricoesCovid(context);
        }

        // GET: RestricaoCovids
        public async Task<IActionResult> Index(int pagina = 1)
        {
            restricoesCovid.Paginacao.PaginaAtual = pagina;
            restricoesCovid.ListaRestricoes = await _context.RestricaoCovid.Skip((restricoesCovid.Paginacao.PaginaAtual - 1) * restricoesCovid.Paginacao.ElementosPorPagina).Take(7).ToListAsync();
            return View(restricoesCovid);
        }

        // GET: RestricaoCovids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restricaoCovid = await _context.RestricaoCovid
                .FirstOrDefaultAsync(m => m.RestricaoCovidId == id);
            if (restricaoCovid == null)
            {
                return NotFound();
            }

            return View(restricaoCovid);
        }

        // GET: RestricaoCovids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RestricaoCovids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RestricaoCovidId,Descricao,DataInicio,DataFim")] RestricaoCovid restricaoCovid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restricaoCovid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restricaoCovid);
        }

        // GET: RestricaoCovids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restricaoCovid = await _context.RestricaoCovid.FindAsync(id);
            if (restricaoCovid == null)
            {
                return NotFound();
            }
            return View(restricaoCovid);
        }

        // POST: RestricaoCovids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RestricaoCovidId,Descricao,DataInicio,DataFim")] RestricaoCovid restricaoCovid)
        {
            if (id != restricaoCovid.RestricaoCovidId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restricaoCovid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestricaoCovidExists(restricaoCovid.RestricaoCovidId))
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
            return View(restricaoCovid);
        }

        // GET: RestricaoCovids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restricaoCovid = await _context.RestricaoCovid
                .FirstOrDefaultAsync(m => m.RestricaoCovidId == id);
            if (restricaoCovid == null)
            {
                return NotFound();
            }

            return View(restricaoCovid);
        }

        // POST: RestricaoCovids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restricaoCovid = await _context.RestricaoCovid.FindAsync(id);
            _context.RestricaoCovid.Remove(restricaoCovid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestricaoCovidExists(int id)
        {
            return _context.RestricaoCovid.Any(e => e.RestricaoCovidId == id);
        }
    }
}
