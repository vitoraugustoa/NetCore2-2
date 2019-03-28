using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosWebApi.Models
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private List<Produto> produtos = new List<Produto>();
        private int _nextId = 1;

        public ProdutoRepositorio()
        {
            Add(new Produto { Nome = "Guaraná Antartica" , Categoria = "Refrigerantes" , Preco = 4.59M });
            Add(new Produto { Nome = "Suco de Laranja Prats" , Categoria = "Sucos" , Preco = 5.75M });
            Add(new Produto { Nome = "Mostard Hammer" , Categoria = "Condimentos" , Preco = 3.90M });
            Add(new Produto { Nome = "Molho de Tomate Cepera" , Categoria = "Condimentos" , Preco = 2.99M });
            Add(new Produto { Nome = "Suco de Uva Aurora" , Categoria = "Sucos" , Preco = 6.50M });
        }

        public Produto Add(Produto novoProduto)
        {
            if(novoProduto != null)
            {
                novoProduto.Id = _nextId++;
                produtos.Add(novoProduto);
                return novoProduto;
            }
            else
            {
                throw new ArgumentException("novoProduto");
            }
        }

        public void Delete(int id)
        {
            produtos.RemoveAll(p => p.Id == id);
        }

        public Produto Get(int id)
        {
            return produtos.Find(p => p.Id == id);
        }

        public IEnumerable<Produto> GetAll()
        {
            return produtos;
        }

        public bool Update(Produto novoProduto)
        {
            if(novoProduto != null)
            {
                int index = produtos.FindIndex(p => p.Id == novoProduto.Id);
                if(index > -1)
                {
                    produtos.RemoveAt(index);
                    produtos.Add(novoProduto);
                    return true;
                }   
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentException("novoProduto");
            }
        }
    }
}
