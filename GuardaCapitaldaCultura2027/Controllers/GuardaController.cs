using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GuardaCapitaldaCultura2027.Controllers
{
    public class GuardaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
