using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface.Inventario;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Services.Inventario;
using System.Linq;



namespace ProjetoModeloDDD.Application.Inventario
{
    public class ProdutoImportacaoAppService : AppServiceBase<ProdutoImportacao>, IProdutoImportacaoAppService
    {
        private readonly IProdutoImportacaoService _produtoImportacaoService;

        public ProdutoImportacaoAppService(IProdutoImportacaoService produtoImportacaoService)
            :base(produtoImportacaoService)
        {
            _produtoImportacaoService = produtoImportacaoService;
        }

        public IEnumerable<ProdutoImportacao> ImportarTxt(string CaminhoArquivoImportacao, string strConnection)
        {
            return _produtoImportacaoService.ImportarTxt(CaminhoArquivoImportacao, strConnection);
        }


        public IEnumerable<ProdutoImportacao> Filter(long CodigoEan)
        {
            var produtoImoprtacao = _produtoImportacaoService.GetAll();

            // filtro
            if (CodigoEan > 0)
            {
                produtoImoprtacao = produtoImoprtacao.Where
                        (
                            s => s.CodigoEan == CodigoEan
                        );
            }

            return produtoImoprtacao;
        }
    }
}
