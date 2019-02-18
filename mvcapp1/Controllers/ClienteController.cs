using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mvcapp1.Models;
using mvcapp1.ViewModels;

namespace mvcapp1.Controllers
{
    [Route("[Controller]/[Action]")]
    public class ClienteController : Controller
    {
        public IActionResult Detalhe(){

            Cliente cliente = new Cliente{
              ClienteId = 1,
              Nome = "Vitor Lopes",
              Email = "vitoraugustoa@hotmail.com"
            };

            List<Pedido> pedidos = new List<Pedido>{
                new Pedido  { PedidoId = 1,  Nome = "Pedido 1"},
                new Pedido {PedidoId = 2 , Nome = "Pedido 2"}
            };

            ClientePedidoViewModel viewModel = new ClientePedidoViewModel
            {
                Cliente = cliente,
                Pedidos = pedidos
            };

            return View(viewModel);
        }
    }
}