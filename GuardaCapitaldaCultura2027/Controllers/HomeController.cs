using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using GuardaCapitaldaCultura2027.Models;
using GuardaCapitaldaCultura2027.Models.Context;
using GuardaCapitaldaCultura2027.Models.ViewModels;

namespace GuardaCapitaldaCultura2027.Controllers
{
    public class HomeController : Controller
    {
        private readonly GuardaEventosBdContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, GuardaEventosBdContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{controller=Home}/{Municipio:alpha}/{page:int?}")]
        public IActionResult Municipios(string Municipio, int? page = 1)
        {
            ViewData["NomeMunicipio"] = Municipio;
            EventosMunicipio eventosDoMunicipio = new EventosMunicipio(_context, Municipio);
            eventosDoMunicipio.Paginacao.PaginaAtual = (int)page;
            eventosDoMunicipio.ListaEventos = eventosDoMunicipio.ListaEventos.Skip(((int)page - 1) * 3).Take(3).ToList();
            return View(eventosDoMunicipio);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sobre()
        {
            return View();
        }

        public IActionResult Contactos()
        {
            return View();
        }

        public IActionResult Turista()
        {
            return View();
        }

        /*public IActionResult Aguiar()
        {
            return View();
        }   
        public IActionResult Almeida()
        {
            return View();
        }
        public  IActionResult Belmonte()
        {
            return View();
        }

        public IActionResult Celorico()
        {
            return View();
        }

        public IActionResult Covilha()
        {
            return View();
        }
        public IActionResult FCR()
        {
            return View();
        }
        public IActionResult Fornos()
        {
            return View();
        }
        public IActionResult Fundao()
        {
            return View();
        }
        public IActionResult Gouveia()
        {
            return View();
        }
        public IActionResult Guarda()
        {
            return View();
        }
        public IActionResult Manteigas()
        {
            return View();
        }
        public IActionResult Meda()
        {
            return View();
        }
        public IActionResult Pinhel()
        {
            return View();
        }
        public IActionResult Sabugal()
        {
            return View();
        }

        public IActionResult Seia()
        {
            return View();
        }

        public IActionResult Trancoso()
        {
            return View();
        }

        public IActionResult VNFC()
        {
            return View();
        }*/
        public IActionResult Erro()
        {
            return View();
        }

        public IActionResult Covid()

        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }    
        
    }
}
