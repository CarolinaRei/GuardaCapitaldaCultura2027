using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GuardaCapitaldaCultura2027.Controllers
{
    public class GuardaController : Controller
    {
        static IList<Models.Guarda> GuardaList = new List<Models.Guarda>{
                new Models.Guarda() { GuardaId = 1,    Name = "Guarda 2020"  , Ano = 2020 } ,
                new Models.Guarda() { GuardaId = 2,    Name = "Cidade Natal" , Ano = 2020 } ,
                new Models.Guarda() { GuardaId = 3,    Name = "Guarda Futuro"  , Ano = 2021 }
            };
        public IActionResult Index()
        {
            return View(GuardaList);
        }
    }
}
