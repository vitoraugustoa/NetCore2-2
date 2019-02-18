using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EfCore_DbFirst.Models;

namespace EfCore_DbFirst.Controllers
{
    public class HomeController : Controller
    {
        private DemoDbContext _context;

        public HomeController(DemoDbContext contexto)
        {
            _context = contexto;
        }

        public IActionResult Index()
        {
            var aluno = _context.Alunos.ToList();
            return View(aluno);
        }

        public IActionResult Privacy()
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
