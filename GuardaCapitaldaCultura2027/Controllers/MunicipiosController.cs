﻿using System;
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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Municipios.ToListAsync());
        }
        // GET: Municipios/IndexGestor
        public async Task<IActionResult> IndexGestor(int? id)
        {
            var municipio = await _context.Municipios
                .FirstOrDefaultAsync(m => m.MunicipioId == id);
            return View(await _context.Municipios.ToListAsync());
        }

        // GET: Municipios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipios
                .FirstOrDefaultAsync(m => m.MunicipioId == id);
            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);
        }

        // GET: Municipios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Municipios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("municipioId,Nome,ImageFile")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                //Salvar Imagem em wwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileNome = Path.GetFileNameWithoutExtension(municipio.ImageFile.FileName);
                string extencion = Path.GetExtension(municipio.ImageFile.FileName);
                municipio.ImagemNome = fileNome = fileNome + DateTime.Now.ToString("yymmssfff") + extencion;
                string path = Path.Combine(wwwRootPath + "/Image/", fileNome);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await municipio.ImageFile.CopyToAsync(fileStream);
                }


                //incerir 
                _context.Add(municipio);
                await _context.SaveChangesAsync();
                /*****Mensagem de sucesso ******/
                ViewBag.title = "Municipio criado Com Sucesso!";
                ViewBag.type = "alert-success";
                ViewBag.message = "Municipio criado!";
                ViewBag.redirect = "/Municipios/Create"; // Request.Path
                return View("Mensagem");

                
               // return RedirectToAction(nameof(Index));
            }
            return View(municipio);
        }

        // GET: Municipios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipios.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("municipioId,Nome,ImagemNome")] Municipio municipio)
        {
            if (id != municipio.MunicipioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(municipio);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            return View(municipio);
        }

        // GET: Municipios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipios
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {


            var municipio = await _context.Municipios.FindAsync(id);
            //delete image from wwwroot/image
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", municipio.ImagemNome);
            if (System.IO.File.Exists(imagePath)) 
            {
                System.IO.File.Delete(imagePath);
            }

            //delect the record
            _context.Municipios.Remove(municipio);
            await _context.SaveChangesAsync();

            /*****Mensagem de sucesso ******/
            ViewBag.title = "Municipio Deletado Sucesso!";
            ViewBag.type = "alert-warning";
            ViewBag.message = "Infelismente Foi deletado!";
            ViewBag.redirect = "/Municipios/Index"; // Request.Path
            return View("Mensagem");


            //return RedirectToAction(nameof(Index));
        }

        private bool MunicipioExists(int id)
        {
            return _context.Municipios.Any(e => e.MunicipioId == id);
        }
    }
}