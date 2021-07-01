
using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities.Inventario;

namespace ProjetoModeloDDD.Application.Interface.Inventario
{
    public interface IRelatorioFinalAppService : IAppServiceBase<RelatorioFinal>
    {
        IEnumerable<RelatorioFinal> Relatorio(int ControleInvetarioId);
        IEnumerable<RelatorioFinal> Relatorio();
        IEnumerable<RelatorioFinal> RelatorioProdutividade(int ControleInvetarioId);
        IEnumerable<RelatorioFinal> RelatorioExportTXT(int ControleInvetarioId);
    }
}
