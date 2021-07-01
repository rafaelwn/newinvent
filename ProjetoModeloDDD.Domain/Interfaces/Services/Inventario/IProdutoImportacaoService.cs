using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities.Inventario;

namespace ProjetoModeloDDD.Domain.Interfaces.Services.Inventario
{
    public interface IProdutoImportacaoService : IServiceBase<ProdutoImportacao>
    {
        IEnumerable<ProdutoImportacao> ImportarTxt(string CaminhoArquivoImportacao, string strConnection);
    }
}
