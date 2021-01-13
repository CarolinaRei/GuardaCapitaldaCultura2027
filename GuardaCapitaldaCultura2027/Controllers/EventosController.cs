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
    public class EventosController : Controller
    {
        private readonly GuardaEventosBdContext _context;
        private readonly Eventos Eventos;

        public EventosController(GuardaEventosBdContext context)
        {
            _context = context;
            Eventos = new Eventos(context);
        }

        // GET: Eventos
        public async Task<IActionResult> Index(int pagina = 1)
        {
            Eventos.Paginacao.PaginaAtual = pagina;
            Eventos.ListaEventos = await _context.Eventos.Skip((Eventos.Paginacao.PaginaAtual - 1) * Eventos.Paginacao.ElementosPorPagina).Take(5).ToListAsync();
            return View(Eventos);
        }

        // GET: Eventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .FirstOrDefaultAsync(m => m.EventoId == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Eventos/Create
        public IActionResult Create()
        {
            ViewData["municipios"] = new SelectList(_context.Municipios, "MunicipioId", "Nome");
            return View();
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventoId,MunicipioId,Name,Descricao,Data_realizacao,Imagem,Lotacao_max,Lotacao_Ocupada")] Evento evento)
        {
            if (!string.IsNullOrWhiteSpace(Request.Form.Files["Imagem"].FileName))
            {
                var stream = Request.Form.Files["Imagem"].OpenReadStream();
                byte[] imagem = new byte[stream.Length];
                stream.Read(imagem);
                evento.Imagem = imagem;
                ModelState.Remove("Imagem");
            }

            if (ModelState.IsValid)
            {
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evento);
        }

        // GET: Eventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.Include(evt => evt.Municipio).Where(evt => evt.EventoId == id).FirstOrDefaultAsync();
            if (evento == null)
            {
                return NotFound();
            }
            return View(evento);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventoId,MunicipioId,Name,Descricao,Data_realizacao,Imagem,Lotacao_max,Lotacao_Ocupada")] Evento evento)
        {
            if (id != evento.EventoId)
            {
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(Request.Form.Files["Imagem"].FileName))
            {
                var stream = Request.Form.Files["Imagem"].OpenReadStream();
                byte[] imagem = new byte[stream.Length];
                stream.Read(imagem);
                evento.Imagem = imagem;
                ModelState.Remove("Imagem");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.EventoId))
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
            return View(evento);
        }

        // GET: Eventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .FirstOrDefaultAsync(m => m.EventoId == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.EventoId == id);
        }
    }
}
