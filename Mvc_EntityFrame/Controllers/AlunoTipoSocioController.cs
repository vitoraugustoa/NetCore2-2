using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc_EntityFrame.Models;

namespace Mvc_EntityFrame.Controllers
{
    public class AlunoTipoSocioController : Controller
    {
        private AlunoContext _context;

        public AlunoTipoSocioController(AlunoContext alunoContext)
        {
            _context = alunoContext;
        }

        public IActionResult Index()
        {
            var infoAluno = _context.Alunos.Include(tp => tp.TipoSocio); // Eager Loading 
            // Podemos utilizar tambem o Lazy Loading para carregar um dado relacionado
            return View(infoAluno);
        }
    }
}