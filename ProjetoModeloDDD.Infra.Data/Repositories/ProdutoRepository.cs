
using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class ProdutoRepository :  RepositoryBase<Produto>, IProdutoRepository
    {
        IEnumerable<Produto> IProdutoRepository.BuscarPorNome(string nome)
        {
            return Db.Produtos.Where(p => p.Nome == nome);
        }


        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
