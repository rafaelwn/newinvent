using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface.Inventario;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Services.Inventario;
using System.Linq;
using System.Text;

namespace ProjetoModeloDDD.Application.Inventario
{
    public class RelatorioFinalAppService : AppServiceBase<RelatorioFinal>, IRelatorioFinalAppService
    {
        private readonly IRelatorioFinalService _relatorioFinalService;

        public RelatorioFinalAppService(IRelatorioFinalService relatorioFinalService)
            : base(relatorioFinalService)
        {
            _relatorioFinalService = relatorioFinalService;
        }

        public IEnumerable<RelatorioFinal> Relatorio(int ControleInvetarioId)
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

            return _relatorioFinalService.QuerySQLEntity(strQuery.ToString());

        }

        public IEnumerable<RelatorioFinal> RelatorioProdutividade(int ControleInvetarioId)
        {
            StringBuilder strQuery = new StringBuilder();

            strQuery.Append("SELECT  ");
	        strQuery.Append("    ControleInventarioId, EmailUsuario,  ");
	        strQuery.Append("    SUM(Quantidade) Qtde_Total_Coletado, COUNT(CodigoEan) Qtde_Produtos_Coletado  ");
            strQuery.Append("FROM ItemControleInventario ");
            strQuery.AppendFormat("WHERE ControleInventarioId = {0} ", ControleInvetarioId);
            strQuery.Append("GROUP BY ControleInventarioId, EmailUsuario ");

            return _relatorioFinalService.QuerySQLEntity(strQuery.ToString());
        }

        public IEnumerable<RelatorioFinal> RelatorioExportTXT(int ControleInvetarioId)
        {
            StringBuilder strQuery = new StringBuilder();

            strQuery.Append("SELECT  ");
            strQuery.Append("    CodigoEan, SUM(Quantidade) AS Qtde_Total_Coletado  ");            
            strQuery.Append("FROM ItemControleInventario ");
            strQuery.AppendFormat("WHERE ControleInventarioId = {0} ", ControleInvetarioId);
            strQuery.Append("GROUP BY CodigoEan ");

            return _relatorioFinalService.QuerySQLEntity(strQuery.ToString());
        } 

        public IEnumerable<RelatorioFinal> Relatorio()
        {
            throw new System.NotImplementedException();
        }
    }
}
