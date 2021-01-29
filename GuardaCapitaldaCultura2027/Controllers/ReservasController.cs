using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuardaCapitaldaCultura2027.Models;
using GuardaCapitaldaCultura2027.Models.Context;
using GuardaCapitaldaCultura2027.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GuardaCapitaldaCultura2027.Controllers
{
    [Authorize]
    public class ReservasController : Controller
    {
        private readonly Reservas Reservas;
        private readonly UserManager<IdentityUser> UserManager;
        private readonly GuardaEventosBdContext _context;
        private readonly IdentityUser SignedInUser;

        public ReservasController(GuardaEventosBdContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            Reservas = new Reservas(context);
            UserManager = userManager;            
            SignedInUser = userManager.FindByNameAsync(signInManager.Context.User.Identity.Name).GetAwaiter().GetResult();
        }

        // GET: Reserva
        public ActionResult Index(int page = 1)
        {
            Reservas.Paginacao.PaginaAtual = page;
            Reservas.ListaReservas = _context.Reservas.Include(rsv => rsv.Evento).Where(rsv => rsv.PessoaId.Equals(SignedInUser.Id)).Skip((Reservas.Paginacao.PaginaAtual - 1) * Reservas.Paginacao.ElementosPorPagina).Take(Reservas.Paginacao.ElementosPorPagina).ToList();
            return View(Reservas);
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.Include(rsv => rsv.Evento)
                .FirstOrDefaultAsync(m => m.ReservaId == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reserva/Create
        public ActionResult Create(int EventoId)
        {
            return View(new Reserva() { EventoId = EventoId, PessoaId = SignedInUser.Id});
        }

        // POST: Reserva/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("ReservaId, EventoId, PessoaId, Nome, Observacao, Numero_Reserva")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // GET: Reserva/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.Include(rsv => rsv.Evento).Where(rsv => rsv.ReservaId==id).FirstOrDefaultAsync();
            
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reserva/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, [Bind("ReservaId, EventoId, PessoaId, Nome, Observacao, Numero_Reserva")] Reserva reserva)
        {
            if (id != reserva.ReservaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.ReservaId))
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
            return View(reserva);
        }

        // GET: Reserva/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(m => m.ReservaId == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, IFormCollection collection)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(r => r.ReservaId == id);
        }
    }
}
