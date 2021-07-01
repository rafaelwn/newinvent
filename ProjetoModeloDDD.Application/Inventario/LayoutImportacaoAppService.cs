
using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface.Inventario;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Services.Inventario;

namespace ProjetoModeloDDD.Application.Inventario
{
    public class LayoutImportacaoAppService : AppServiceBase<LayoutImportacao>, ILayoutImportacaoAppService
    {
        private readonly ILayoutImportacaoService _layoutImportacaoService;

        public LayoutImportacaoAppService(ILayoutImportacaoService layoutImportacaoService)
            : base(layoutImportacaoService)
        {
            _layoutImportacaoService = layoutImportacaoService;
        }

    }
}
