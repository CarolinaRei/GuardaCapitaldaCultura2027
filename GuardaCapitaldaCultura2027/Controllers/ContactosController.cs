using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuardaCapitaldaCultura2027.Models;
using GuardaCapitaldaCultura2027.Models.Context;
using System.Net.Mail;


namespace GuardaCapitaldaCultura2027.Controllers
{
    public class ContactosController : Controller
    {
        private readonly GuardaEventosBdContext _context;

        public ContactosController(GuardaEventosBdContext context)
        {
            _context = context;
        }

        // GET: Contactos
        public IActionResult Index(string nome = null, int page = 1)
        {
            var pagination = new PagingInfoMunicipio
            {
                CurrentPage = page,
                PageSize = PagingInfoMunicipio.DEFAULT_PAGE_SIZE,
                TotalItems = _context.Contactos.Where(p => nome == null || p.Assunto.Contains(nome)).Count()
            };

            return View(
               new ListaContacto

               {
                   //await _context.Contactos.ToListAsync()
                   Contactos = _context.Contactos.Where(p => nome == null || p.Assunto.Contains(nome))
                                .OrderBy(p => p.Assunto)
                                .Skip((page - 1) * pagination.PageSize)
                                .Take(pagination.PageSize),
                   pagination = pagination,
                   SearchNome = nome
               }
                );
        }

        // GET: Contactos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contactos
                .FirstOrDefaultAsync(m => m.ContactoId == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // GET: Contactos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contactos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactoId,Name,Sobrenome,Email,Assunto,Mensagem")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacto);
               await _context.SaveChangesAsync();
                /*****Mensagem de sucesso ******/
                ViewBag.title = "Contacto enviado Com Sucesso!";
                ViewBag.type = "alert-success";
                ViewBag.message = "Em breve entraremos em Contacto!";
                ViewBag.redirect = "/Contactos/Create"; // Request.Path
                return View("Mensagem");
                /*return RedirectToAction(nameof(Index));*/
            }
            return View(contacto);
        }

        // GET: Contactos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        // POST: Contactos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactoId,Name,Sobrenome,Email,Assunto,Mensagem")] Contacto contacto)
        {
            if (id != contacto.ContactoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoExists(contacto.ContactoId))
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
            return View(contacto);
        }

        // GET: Contactos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contactos
                .FirstOrDefaultAsync(m => m.ContactoId == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // POST: Contactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);
            _context.Contactos.Remove(contacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactoExists(int id)
        {
            return _context.Contactos.Any(e => e.ContactoId == id);
        }


        //  Contactos/Responder
        
        public IActionResult Responder()
        {
            return View();
        }
        
    }
}
