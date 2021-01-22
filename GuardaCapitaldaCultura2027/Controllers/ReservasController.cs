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
        public ActionResult Index()
        {
            Reservas.ListaReservas = _context.Reservas.Where(rsv=>rsv.PessoaId.Equals(SignedInUser.Id)).ToList();
            return View(Reservas);
        }

        // GET: Reserva/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reserva/Create
        public ActionResult Create(int EventoId)
        {
            return View(new Reserva() { EventoId = EventoId, PessoaId = SignedInUser.Id});
        }

        // POST: Reserva/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("ReservaId, EventoId, PessoaId, Nome, Numero_Reserva")] Reserva reserva)
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reserva/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Reserva/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reserva/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
