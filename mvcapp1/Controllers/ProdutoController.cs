using Microsoft.AspNetCore.Mvc;
using System;

namespace mvcapp1.Controllers
{
   
    public class ProdutoController : Controller
    {
        
        public IActionResult Index(int? pagina, string ordem){

            if(!pagina.HasValue)
                pagina = 1;
                

            if(String.IsNullOrEmpty(ordem))
                ordem = "Nome";
            
                

            return Content(String.Format("Pagina={0}&ordem={1}",pagina,ordem));

              //var https = HttpContext.Request.IsHttps;  
              //var caminho = HttpContext.Request.Path;
              //var status = HttpContext.Response.StatusCode;
              //var conexao = HttpContext.Connection.ToString();

              //return https + "\r\n" + caminho + "\r\n" + status + "\r\n" + conexao;
            //return "Este é o metodo Action padrão ";
        }

    
        public IActionResult Lista(){
            return Content("Action Lista");
        }


        public IActionResult Detalhe(){
            

            //var pessoa = new {Id = 2, Nome = "Vitor"};   
            //return new ObjectResult(pessoa);
            //return Content("arquivo PDF","application/pdf");
            //return RedirectToAction("Index","Home",new {pagina=2,ordem="Nome"});
            return View();
        }


        public IActionResult Edit(int codigo){
            return Content($"Valor do ID é igual {codigo}");
        }

        [Route("produto/lancamento/{ano:int}/{mes:range(1,12)}")]
        public IActionResult Lancamento (int ano, int mes){
            
            return Content(ano + "/" + mes);
        }

    }
}