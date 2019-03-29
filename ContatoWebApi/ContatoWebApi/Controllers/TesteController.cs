using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContatoWebApi.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http;

namespace ContatoWebApi.Controllers
{
    

    public class TesteController : Controller
    {
        //https://localhost:5001/api/contatos/ Endereço Web Api.

        private readonly string BaseUrl = "https://localhost:5001/";
        public IActionResult Index()
        {
            List<Contato> contatolist = new List<Contato>();

            // **** Consumindo API GET ALL******
            using (HttpClient cliente = new HttpClient())
            {
                // Definindo o endereço base passando a minha BaseUrl
                cliente.BaseAddress = new Uri(BaseUrl);

                // Definindo que as informações que estão vindo do cabeçalho são do tipo JSON
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                cliente.DefaultRequestHeaders.Accept.Add(contentType);

                // Mandando a requisição para encontrar o recurso de serviço REST exposto pela Web Api
                // Agora do tipo GET
                HttpResponseMessage response = cliente.GetAsync("/api/contatos").Result;

                // Se a requisição foi atendida vou pegar o conteudo e ler como string que veio no cabeçalho
                if (response.IsSuccessStatusCode)
                {
                    var contatoResponse = response.Content.ReadAsStringAsync().Result;
                    // Pego a responsa e deserializo o objeto que veio como Json para objeto.

                    contatolist = JsonConvert.DeserializeObject<List<Contato>>(contatoResponse);
                }

                return View(contatolist);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Apresentar o formulário
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Contato novoContato)
        {
            Contato contatoInfo = new Contato();

            // **** Consumindo API POST CREATE ******
            using (HttpClient cliente = new HttpClient())
            {
                // Definindo o endereço base passando a minha BaseUrl
                cliente.BaseAddress = new Uri(BaseUrl);

                // Serializar os dados do objeto do contato para JSON
                string contatoSerializado = JsonConvert.SerializeObject(novoContato);

                // Definindo o formato dos dados do request para JSOI
                var conteudoDados = new StringContent(contatoSerializado , System.Text.Encoding.UTF8 , "application/json");

                // Mandando a requisição para encontrar o recurso de serviço REST exposto pela Web Api
                // Agora do tipo POST
                HttpResponseMessage response = cliente.PostAsync("/api/contatos", conteudoDados).Result;

                // Se a requisição foi atendida vou pegar o conteudo e ler como string que veio no cabeçalho
                if (response.IsSuccessStatusCode)
                {
                    // Armazena os detalhes da resposta recebidos da web api
                    var contatoResponse = response.Content.ReadAsStringAsync().Result;
                    
                    // Pego a responsa e deserializo o objeto que veio como Json para objeto.
                    contatoInfo = JsonConvert.DeserializeObject<Contato>(contatoResponse);
                }

                // Redireciona para a Action "Index"
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Contato contato = new Contato();

            using(HttpClient cliente = new HttpClient())
            {
                // Definindo o endereço base passando a minha BaseUrl
                cliente.BaseAddress = new Uri(BaseUrl);

                // Utilizando o metodo GET para buscar o contato por ID
                HttpResponseMessage response = cliente.GetAsync($"/api/contatos/{id}").Result;

                
                if (response.IsSuccessStatusCode)
                {
                    // Buscando o contato encontrado em JSON
                    var contatoResposta = response.Content.ReadAsStringAsync().Result;

                    // Deserializando o contato em JSON para objeto do tipo Contato
                    contato = JsonConvert.DeserializeObject<Contato>(contatoResposta);

                    // Retornando o contato para a View Update (POST)
                    return View(contato);
                }

                ViewBag.MessageError = "Deu ruim!";

                return View(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Contato contatoAtualizado)
        {

            // **** Consumindo API PUT UPDATE******
            using (HttpClient cliente = new HttpClient())
            {
                // Definindo o endereço base passando a minha BaseUrl
                cliente.BaseAddress = new Uri(BaseUrl);

                // Serializando o objeto para JSON
                string stringData = JsonConvert.SerializeObject(contatoAtualizado);

                // Definindo o formato dos dados do request para JSOI
                var contentData = new StringContent(stringData , System.Text.Encoding.UTF8 , "application/json");

                // Utilizando o metodo PUT para Atualizar o registro , passando o ID e o conteudo
                HttpResponseMessage response = cliente.PutAsync("/api/contatos/"+ contatoAtualizado.Id, contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;

                    // Busca o resultado em JSON
                    var contatoResposta = response.Content.ReadAsStringAsync().Result;

                    // Retorna para a Index
                    return RedirectToAction(nameof(Index));
                }

                return View(contatoAtualizado);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Contato contato = new Contato();

            using (HttpClient cliente = new HttpClient())
            {
                // Definindo o endereço base passando a minha BaseUrl
                cliente.BaseAddress = new Uri(BaseUrl);

                // Utilizando o metodo GET para buscar o contato por ID
                HttpResponseMessage response = cliente.GetAsync($"/api/contatos/{id}").Result;


                if (response.IsSuccessStatusCode)
                {
                    // Buscando o contato encontrado em JSON
                    var contatoResposta = response.Content.ReadAsStringAsync().Result;

                    // Deserializando o contato em JSON para objeto do tipo Contato
                    contato = JsonConvert.DeserializeObject<Contato>(contatoResposta);

                    // Retornando o contato para a View Update (POST)
                    return View(contato);
                }

                ViewBag.MessageError = "Deu ruim!";
                return View(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            using (HttpClient cliente = new HttpClient())
            {
                //Definindo o endereço base passando a minha BaseUrl
                cliente.BaseAddress = new Uri(BaseUrl);

                // Utilizando o metodo DELETE para deletar o contato por ID
                HttpResponseMessage response = cliente.DeleteAsync($"/api/contatos/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var contatoReponse = response.Content.ReadAsStringAsync().Result;
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Contato contato = new Contato();

            using(HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(BaseUrl);

                HttpResponseMessage response = cliente.GetAsync($"/api/contatos/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var contatoResponse = response.Content.ReadAsStringAsync().Result;
                    contato = JsonConvert.DeserializeObject<Contato>(contatoResponse);

                    return View(contato);
                }

                return RedirectToAction(nameof(Index));
            }
        }

    }

}