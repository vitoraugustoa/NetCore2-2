using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc_EntityFrame.Models;
using ReflectionIT.Mvc.Paging;

namespace Mvc_EntityFrame.Controllers
{
    
    public class TesteController : Controller
    {
        private AlunoContext _context;

        public TesteController(AlunoContext context)
        {
            _context = context;
        }

       public async Task<IActionResult> Index(int page = 1) {
            var query = _context.Alunos.AsNoTracking().OrderBy(p => p.Nome);
            var aluno = await PagingList.CreateAsync(query, 4, page);
            return View(aluno);
        }


        public IActionResult Create(){

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome,Sexo,Email,Nascimento")] Aluno aluno){

            if(ModelState.IsValid){

                _context.Add(aluno);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(aluno);
        }



        public IActionResult Edit(int? id){

            if(id == null)
                return NotFound();
            

            var aluno = _context.Alunos.SingleOrDefault(a => a.Id == id);
                
             if(aluno == null)
                 return NotFound();
             
            
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,[Bind("Id,Nome,Sexo,Email,Nascimento")]Aluno aluno){

             if(id != aluno.Id)
                return NotFound();

             if(ModelState.IsValid){
                
                try
                {
                    _context.Update<Aluno>(aluno);
                    _context.SaveChanges();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!AlunoExiste(aluno.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
             }

            return View(aluno);
        }

        public IActionResult Delete(int? id){
            
            if(id == null)
            {
                return NotFound();
            }
            else
            {
                var aluno = _context.Alunos.SingleOrDefault(a => a.Id == id);

                if(aluno == null)
                {
                    return NotFound();
                }

                return View(aluno);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirma(int? id)
        {
            var aluno = _context.Alunos.SingleOrDefault(a => a.Id == id);
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var aluno = _context.Alunos.SingleOrDefault(a => a.Id == id);

            if(aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
            
        }       

         private bool AlunoExiste(int id){
            return _context.Alunos.Any(e => e.Id == id);
        }
    }

   
}