using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Mvc_BO.Models;

namespace Mvc_BO.Controllers
{
    public class HomeController : Controller
    {
        // Injeção e dependencia da interface IAluno 
        private IAluno alunoBll;
        public HomeController (IAluno IngecaoAlunoBll)
        {
            alunoBll = IngecaoAlunoBll;   
        }


        public IActionResult Index()
        {
            // AlunoBLL _aluno = new AlunoBLL();
            List<Aluno> alunos = alunoBll.GetAlunos();

            return View("Lista",alunos);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Create(){

            return View();
        }

        [HttpPost]
        public IActionResult Create(Aluno aluno){
            
               /*  Verificando dados utilizando model state
               
               if(string.IsNullOrEmpty(aluno.Nome))
                    ModelState.AddModelError("Nome","O nome é obrigatório.");

                if(string.IsNullOrEmpty(aluno.Sexo))
                    ModelState.AddModelError("Sexo","O nome é obrigatório.");

                if(string.IsNullOrEmpty(aluno.Email))
                    ModelState.AddModelError("Email","O nome é obrigatório.");

                if(aluno.Nascimento <= DateTime.Now.AddYears(-10))
                    ModelState.AddModelError("Nascimento","Data de Nascimento Invalida."); */

                
                if(!ModelState.IsValid){

                    return View();
                }else{

                    // AlunoBLL _aluno = new AlunoBLL();
                    alunoBll.SetAluno(aluno);

                    return RedirectToAction("Index");

                }
                             
        }



        [HttpGet]
        public IActionResult Edit(int id){

            // AlunoBLL alunoBll = new AlunoBLL();
            Aluno aluno = alunoBll.GetAlunos().Single(x => x.Id == id);
            return View(aluno);
        }

        [HttpPost]
        public IActionResult Edit([Bind(nameof(Aluno.Id), nameof(Aluno.Sexo), nameof(Aluno.Email), 
        nameof(Aluno.Nascimento), nameof(Aluno.Nome)) ]Aluno aluno){

            if(ModelState.IsValid){
                // AlunoBLL alunoBll = new AlunoBLL();
                alunoBll.UpdateAluno(aluno);
                return RedirectToAction("Index");
            }else{

                return View(aluno);
            }
            
        }


        /* //Get
        public IActionResult Delete(int id){
            
            Aluno aluno = alunoBll.GetAlunos().Single(a => a.Id == id);

            return View(aluno);
        } */


        [HttpPost]
        public IActionResult Delete(int id){
            
            alunoBll.DeleteAluno(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id){
            Aluno aluno = alunoBll.GetAlunos().Single(a => a.Id == id);

            return View(aluno);
        }

        public IActionResult Procurar(string procurarPor, string criterio){

            if(procurarPor == "Email"){

                Aluno aluno = alunoBll.GetAlunos().SingleOrDefault(a => a.Email == criterio);
                return View(aluno);
            }else{

                Aluno aluno = alunoBll.GetAlunos().SingleOrDefault(a => a.Nome == criterio);
                return View(aluno);
            }

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
