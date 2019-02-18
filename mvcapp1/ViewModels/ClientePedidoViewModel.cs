using System.Collections.Generic;
using mvcapp1.Models;

namespace mvcapp1.ViewModels
{
    public class ClientePedidoViewModel
    {
        public Cliente Cliente { get; set; }
        public List<Pedido> Pedidos { get; set; }

    }
}