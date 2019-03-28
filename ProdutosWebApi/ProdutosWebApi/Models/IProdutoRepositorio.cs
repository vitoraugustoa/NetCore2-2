using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosWebApi.Models
{
    public interface IProdutoRepositorio
    {
        IEnumerable<Produto> GetAll();
        Produto Get(int id);
        Produto Add(Produto produto);
        bool Update(Produto produto);
        void Delete(int id);
    }
}
