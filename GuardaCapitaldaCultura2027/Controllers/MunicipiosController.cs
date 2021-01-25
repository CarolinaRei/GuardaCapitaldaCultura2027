using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuardaCapitaldaCultura2027.Models;
using GuardaCapitaldaCultura2027.Models.Context;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace GuardaCapitaldaCultura2027.Controllers
{   
    //[Authorize(Roles = "Admin, GestorEventos")]
    public class MunicipiosController : Controller
    {
        private readonly GuardaEventosBdContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

      

        public MunicipiosController(GuardaEventosBdContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Municipios
        public IActionResult Index(string nome = null, int page = 1)
        {
            var pagination = new PagingInfoMunicipio
            {
                CurrentPage = page,
                PageSize = PagingInfoMunicipio.DEFAULT_PAGE_SIZE,
                TotalItems = _context.Municipio.Where(p => nome == null || p.Nome.Contains(nome)).Count()
            };

            return View(
                    //await _context.Municipios.ToListAsync()
                    new ListaMunicipio
                    {
                        Municipios = _context.Municipio.Where(p => nome == null || p.Nome.Contains(nome))
                            .OrderBy(p => p.Nome)
                            .Skip((page - 1) * pagination.PageSize)
                            .Take(pagination.PageSize),
                        pagination = pagination,
                        SearchNome = nome
                    }
                );
        }

        // GET: Municipios
        public async Task<IActionResult> Page()
        {
            return View(await _context.Municipio.ToListAsync());
        }



        // GET: Municipios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipio
                .FirstOrDefaultAsync(m => m.MunicipioId == id);
            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);
        }

        // GET: Municipios/Create
        [Authorize(Roles = "Admin, GestorEventos")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Municipios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, GestorEventos")]
        public async Task<IActionResult> Create([Bind("MuicipioId,Nome,Data_imagem,Descricao,Desativar")] Municipio municipio, List<IFormFile> Imagem)
        {
            if (ModelState.IsValid)
            {
                //conversao da imagem para binario
                foreach (var item in Imagem)
                {
                    if (item.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await item.CopyToAsync(stream);
                            municipio.Imagem = stream.ToArray();
                        }
                    }
                }
             


                //incerir 
                _context.Add(municipio);
                await _context.SaveChangesAsync();
                /*****Mensagem de sucesso ******/
                ViewBag.title = "Municipio criado Com Sucesso!";
                ViewBag.type = "alert-success";
                ViewBag.message = "Municipio criado!";
                ViewBag.redirect = "/Municipios/Index"; // Request.Path
                return View("Mensagem");

            }
            return View(municipio);
        }

        [Authorize(Roles = "Admin, GestorEventos")]
        // GET: Municipios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipio.FindAsync(id);
            if (municipio == null)
            {
                return NotFound();
            }
            return View(municipio);
        }

        // POST: Municipios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, GestorEventos")]
        public async Task<IActionResult> Edit(int id, [Bind("MunicipioId,Nome,Data_imagem,Desativar,Descricao")] Municipio municipio, List<IFormFile> Imagem)
        {
            if (id != municipio.MunicipioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var item in Imagem)
                    {
                        if (item.Length > 0)
                        {
                            using (var stream = new MemoryStream())
                            {
                                await item.CopyToAsync(stream);
                                municipio.Imagem = stream.ToArray();
                            }
                        }
                    }

                    Municipio VerificarDados = await _context.Municipio.FindAsync(id);
                    VerificarDados.Nome = municipio.Nome;
                    VerificarDados.Descricao = municipio.Descricao;
                    VerificarDados.Desativar = municipio.Desativar;


                    municipio = VerificarDados;

                    _context.Update(municipio);
                    await _context.SaveChangesAsync();
                    ViewBag.title = "Municipio Atualizado Com Sucesso!";
                    ViewBag.type = "alert-success";
                    ViewBag.message = "Municipio Atualizado!";
                    ViewBag.redirect = "/Municipios/Index"; // Request.Path
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MunicipioExists(municipio.MunicipioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return View("Mensagem");
                //return RedirectToAction(nameof(Index));
            }
            return View(municipio);
        }

        // GET: Municipios/Delete/5
        [Authorize(Roles = "Admin, GestorEventos")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipio
                .FirstOrDefaultAsync(m => m.MunicipioId == id);
            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);
        }

        // POST: Municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, GestorEventos")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var municipio = await _context.Municipio.FindAsync(id);
            _context.Municipio.Remove(municipio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MunicipioExists(int id)
        {
            return _context.Municipio.Any(e => e.MunicipioId == id);
        }
    }
}
