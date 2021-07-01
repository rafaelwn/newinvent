
using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Repositories.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Services.Inventario;
using System;
using System.Text;

namespace ProjetoModeloDDD.Domain.Services.Inventario
{
    public class ItemControleInventarioService : ServiceBase<ItemControleInventario>, IItemControleInventarioService
    {
        private readonly IItemControleInventarioRepository _itemcontroleInventarioRepositoty;
        private readonly IControleInventarioRepository _controleInventarioRepository;
        private readonly IProdutoImportacaoRepository _produtoImportacaoRepository;

        public ItemControleInventarioService(IItemControleInventarioRepository itemcontroleInventarioRepositoty
            , IControleInventarioRepository controleInventarioRepository 
            , IProdutoImportacaoRepository produtoImportacaoRepository)
            : base(itemcontroleInventarioRepositoty)
        {
            _itemcontroleInventarioRepositoty = itemcontroleInventarioRepositoty;
            _controleInventarioRepository = controleInventarioRepository;
            _produtoImportacaoRepository = produtoImportacaoRepository;
        }

        public ItemControleInventario AdicionarColeta(ItemControleInventario itemControleInventario)
        {
             
            StringBuilder strQuery = new StringBuilder();            

            strQuery.Append("SELECT TOP 1 ");
            strQuery.Append(" *  ");
            strQuery.Append("FROM ControleInventario  ");
            strQuery.Append("WHERE DataInicio is not null AND DataFim is null ");
            strQuery.Append("ORDER BY ControleInventarioId DESC ");

            List<ControleInventario> inventarioAtivo = _controleInventarioRepository.QuerySQLEntity(strQuery.ToString()).ToList();

            strQuery.Clear();
            strQuery.Append("SELECT ");
            strQuery.Append(" *  ");
            strQuery.Append("FROM ProdutoImportacao  ");
            strQuery.AppendFormat("WHERE CodigoEan = {0} ", itemControleInventario.CodigoEan);            

            List<ProdutoImportacao> produtoImportacao = _produtoImportacaoRepository.QuerySQLEntity(strQuery.ToString()).ToList();

            if (inventarioAtivo.Count() > 0 && produtoImportacao.Count() > 0)
            {
                itemControleInventario.ControleInventarioId = inventarioAtivo.First().ControleInventarioId;
                
                itemControleInventario.ProdutoImportacaoId = produtoImportacao.First().ProdutoImportacaoId;
                itemControleInventario.ProdutoImportacao = null;
                itemControleInventario.Contagem = inventarioAtivo.First().Contagem;
                
                _itemcontroleInventarioRepositoty.Add(itemControleInventario);
                
                itemControleInventario.ProdutoImportacao = produtoImportacao.First();
            }
            else if (inventarioAtivo.Count() == 0)
            {
                throw new ArgumentException("CADASTRE UM INVENTÁRIO !");
            }
            else if (inventarioAtivo.Count() > 0 && produtoImportacao.Count() == 0)
	        {
                itemControleInventario.ControleInventarioId = inventarioAtivo.First().ControleInventarioId;

                // Carregar Produto Não Localizado
                ProdutoImportacao produtoNaoLocalizado = ProdutoNaoLocalizado();

                itemControleInventario.ProdutoImportacaoId = produtoNaoLocalizado.ProdutoImportacaoId;
                itemControleInventario.ProdutoImportacao = null;
                itemControleInventario.Contagem = inventarioAtivo.First().Contagem;

                _itemcontroleInventarioRepositoty.Add(itemControleInventario);
                
                itemControleInventario.ProdutoImportacao = produtoNaoLocalizado;		 
	        }


            return itemControleInventario;
        }

        public ItemControleInventario ConsultarEAN(ItemControleInventario itemControleInventario)
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.Clear();
            strQuery.Append("SELECT ");
            strQuery.Append(" *  ");
            strQuery.Append("FROM ProdutoImportacao  ");
            strQuery.AppendFormat("WHERE CodigoEan = {0} ", itemControleInventario.CodigoEan);

            List<ProdutoImportacao> produtoImportacao = _produtoImportacaoRepository.QuerySQLEntity(strQuery.ToString()).ToList();

            if (produtoImportacao.Count() > 0)
            {       
                itemControleInventario.ProdutoImportacaoId = produtoImportacao.First().ProdutoImportacaoId;
                itemControleInventario.ProdutoImportacao = produtoImportacao.First();
            }
            else if (produtoImportacao.Count() == 0)
            {               
                // Carregar Produto Não Localizado
                ProdutoImportacao produtoNaoLocalizado = ProdutoNaoLocalizado();
                itemControleInventario.ProdutoImportacaoId = produtoNaoLocalizado.ProdutoImportacaoId;
                itemControleInventario.ProdutoImportacao = produtoNaoLocalizado;
            }


            return itemControleInventario;
        }

        public IEnumerable<ItemControleInventario> ConsultaItensInventario()
        {
            StringBuilder strQuery = new StringBuilder();
           
            strQuery.Append("SELECT  [ItemControleInventarioId] ");
            strQuery.Append("      ,I.[DepartamentoId] ");
            strQuery.Append("      ,I.[SecaoId] ");
            strQuery.Append("      ,I.[GrupoId] ");
            strQuery.Append("      ,I.[SubGrupoId] ");
            strQuery.Append("      ,I.[Contagem] ");
            strQuery.Append("      ,I.[Status] ");
            strQuery.Append("      ,I.[ControleInventarioId] ");
            strQuery.Append("      ,I.[ProdutoImportacaoId] ");
            strQuery.Append("      ,I.[IdentificadorInicial] ");
            strQuery.Append("      ,I.[IdentificadorFinal] ");
            strQuery.Append("      ,I.[QuantidadeInicial] ");
            strQuery.Append("      ,I.[QuantidadeFinal] ");
            strQuery.Append("      ,I.[CodigoEan] ");
            strQuery.Append("      ,I.[Quantidade] ");
            strQuery.Append("      ,I.[Identificador] ");
            strQuery.Append("      ,I.[EmailUsuario] ");
            strQuery.Append("      ,PI.NomeProduto AS NomeProdutoImp ");
            strQuery.Append("      ,PI.Quantidade AS QuantidadeImp ");
            strQuery.Append("FROM [newinventdb].[dbo].[ItemControleInventario] I ");
            strQuery.Append("LEFT JOIN ProdutoImportacao PI ON PI.ProdutoImportacaoId = I.ProdutoImportacaoId ");
            strQuery.Append("ORDER BY I.ItemControleInventarioId DESC ");

            IEnumerable<ItemControleInventario> itensControleInventario = _itemcontroleInventarioRepositoty.QuerySQLEntity(strQuery.ToString());

            return itensControleInventario;

        }

        private ProdutoImportacao ProdutoNaoLocalizado()
        {
            var produtoImportacao = _produtoImportacaoRepository.GetAll();
            
            produtoImportacao = produtoImportacao.Where(c => c.NomeProduto == "NÃO LOCALIZADO");

            if (produtoImportacao.Count() > 0)
            {                
                return produtoImportacao.First();
            }
            else
            {
                ProdutoImportacao produtoImportacaoNovo = new ProdutoImportacao();
                produtoImportacaoNovo.NomeProduto = "NÃO LOCALIZADO";
                produtoImportacaoNovo.Data = System.DateTime.Now;
                _produtoImportacaoRepository.Add(produtoImportacaoNovo);

                produtoImportacao = _produtoImportacaoRepository.GetAll();
                produtoImportacao = produtoImportacao.Where(c => c.NomeProduto == "NÃO LOCALIZADO");
                return produtoImportacao.First();
            }
        }



   
    }
}

