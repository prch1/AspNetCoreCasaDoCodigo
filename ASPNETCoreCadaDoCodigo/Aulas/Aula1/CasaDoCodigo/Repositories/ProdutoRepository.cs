using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        
        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {

        }

        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }

        public void SaveProdutos(List<Livro> livros)
        {
            foreach (var i in livros)
            {
                if (!dbSet.Where(x => x.Codigo == i.Codigo).Any())
                {
                  
                    dbSet.Add(new Produto(i.Codigo, i.Nome, i.Preco));
                }
            }

            contexto.SaveChanges();
        }
    }
}
