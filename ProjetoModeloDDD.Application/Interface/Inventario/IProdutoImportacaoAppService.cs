
using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities.Inventario;


namespace ProjetoModeloDDD.Application.Interface.Inventario
{
    public interface IProdutoImportacaoAppService : IAppServiceBase<ProdutoImportacao>
    {
        IEnumerable<ProdutoImportacao> ImportarTxt(string CaminhoArquivoImportacao, string strConnection);

        IEnumerable<ProdutoImportacao> Filter(long CodigoEan);
    }
}
