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

namespace GuardaCapitaldaCultura2027.Controllers
{
    public class MuicipiosController : Controller
    {
        private readonly GuardaEventosBdContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MuicipiosController(GuardaEventosBdContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
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
        public async Task<IActionResult> Create([Bind("MuicipioId,Nome,ImageFile")] Muicipio muicipio)
        {
            if (ModelState.IsValid)
            {
                //Salvar Imagem em wwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileNome = Path.GetFileNameWithoutExtension(muicipio.ImageFile.FileName);
                string extencion = Path.GetExtension(muicipio.ImageFile.FileName);
                muicipio.ImagemNome = fileNome = fileNome + DateTime.Now.ToString("yymmssfff") + extencion;
                string path = Path.Combine(wwwRootPath + "/Image/", fileNome);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await muicipio.ImageFile.CopyToAsync(fileStream);
                }


                //incerir 
                _context.Add(muicipio);
                await _context.SaveChangesAsync();
                /*****Mensagem de sucesso ******/
                ViewBag.title = "Municipio criado Com Sucesso!";
                ViewBag.type = "alert-success";
                ViewBag.message = "Municipio criado!";
                ViewBag.redirect = "/Muicipios/Create"; // Request.Path
                return View("Mensagem");

                
               // return RedirectToAction(nameof(Index));
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
            //delete image from wwwroot/image
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", muicipio.ImagemNome);
            if (System.IO.File.Exists(imagePath)) 
            {
                System.IO.File.Delete(imagePath);
            }

            //delect the record
            _context.Muicipios.Remove(muicipio);
            await _context.SaveChangesAsync();

            /*****Mensagem de sucesso ******/
            ViewBag.title = "Municipio Deletado Sucesso!";
            ViewBag.type = "alert-warning";
            ViewBag.message = "Infelismente Foi deletado!";
            ViewBag.redirect = "/Muicipios/Index"; // Request.Path
            return View("Mensagem");


            //return RedirectToAction(nameof(Index));
        }

        private bool MuicipioExists(int id)
        {
            return _context.Muicipios.Any(e => e.MuicipioId == id);
        }
    }
}
