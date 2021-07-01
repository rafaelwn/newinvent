
using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface.Inventario;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Services.Inventario;
using System.Linq;
using System.Text;

namespace ProjetoModeloDDD.Application.Inventario
{
    public class ItemControleInventarioAppService: AppServiceBase<ItemControleInventario>, IItemControleInventarioAppService
    {
        private readonly IItemControleInventarioService _itemControleInventarioService;

        public ItemControleInventarioAppService(IItemControleInventarioService itemControleInventarioService)
            : base(itemControleInventarioService)
        {
            _itemControleInventarioService = itemControleInventarioService;
        }

        public ItemControleInventario AdicionarColeta(ItemControleInventario itemControleInventario)
        {
            return _itemControleInventarioService.AdicionarColeta(itemControleInventario);
        }


        public ItemControleInventario ConsultarEAN(ItemControleInventario itemControleInventario)
        {
            return _itemControleInventarioService.ConsultarEAN(itemControleInventario);
        }

        public IEnumerable<ItemControleInventario> Relatorio(int ControleInvetarioId)
        {
            StringBuilder strQuery = new StringBuilder();

            strQuery.Append("SELECT ");
            strQuery.Append(" 0 as Id, i.ControleInventarioId, p.Identificador, i.CodigoEan, ISNULL(p.NomeProduto,'Não Localizado') as NomeProduto,  ");
            strQuery.Append("	SUM(i.Quantidade) Qtde_Total_Invent, p.Quantidade as Qtde_Total_ERP  ");
            strQuery.Append("	, SUM(i.Quantidade) - p.Quantidade as Diferenca, ");
            strQuery.Append("	(SUM(p.PrecoVendaUnitario)* SUM(i.Quantidade)) PrecoVendaUnitario, ");
            strQuery.Append("   (SUM(p.PrecoUnitario) * SUM(i.Quantidade)) PrecoUnitario  ");
            strQuery.Append("FROM ItemControleInventario i ");
            strQuery.Append("LEFT JOIN ProdutoImportacao p on p.CodigoEan = i.CodigoEan ");
            strQuery.AppendFormat("WHERE i.ControleInventarioId = {0} ", ControleInvetarioId);
            strQuery.Append("GROUP BY i.ControleInventarioId, p.Identificador, i.CodigoEan, p.ProdutoImportacaoId, p.NomeProduto, p.Quantidade ");
            strQuery.Append("ORDER BY i.ControleInventarioId desc ");

            return _itemControleInventarioService.QuerySQLEntity(strQuery.ToString());

        }


        public IEnumerable<ItemControleInventario> ConsultaItensInventario()
        {
            return _itemControleInventarioService.ConsultaItensInventario();
        }
    }
}
