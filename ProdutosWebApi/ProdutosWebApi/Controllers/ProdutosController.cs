using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosWebApi.Models;

namespace ProdutosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepositorio _repositorio;

        public ProdutosController(IProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        // Retornando um IEnumerable no return ele vai serializar automaticamente o objeto para o formato JSON
        [HttpGet]
        public IEnumerable<Produto> GetAll()
        {
            return _repositorio.GetAll();
        }

        // O id é uma variavel que vai ser obtida pela requisição. 
        // O Name = "GetProduto" vai criar uma rota nomeada e vai permitir vincular a rota a uma resposta HTTP
        // IActionResult permite retornar diversos tipos
        [HttpGet("{id}" , Name = "GetProduto" )]
        public IActionResult GetProdutoById(int id)
        {
            Produto produto = _repositorio.Get(id);

            if(produto != null)
            {
                return new ObjectResult(produto);
            }
            else
            {
                return NotFound();
            }
        }


        // o [FromBody] esta indicando para o framework mvc , para objetar os dados no corpo da requisição.
        [HttpPost]
        public IActionResult CreateProduto([FromBody] Produto item)
        {
            if(item != null)
            {
                // vai Criar uma rota com o Nome GetProduto passando o ID do produto criado e o produto criado.
                 item = _repositorio.Add(item);
                return CreatedAtRoute("GetProduto" , new { id = item.Id } , item);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(int id ,[FromBody] Produto item)
        {
            if(item != null)
            {
                item.Id = id;
                if (_repositorio.Update(item))
                {
                    // NoContentResult significa que o procedimento foi realizado com sucesso 204 sem conteudo.
                    return new NoContentResult();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            Produto item = _repositorio.Get(id);
            if(item != null)
            {
                _repositorio.Delete(id);
                return new NoContentResult();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
