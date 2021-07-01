
using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Repositories.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Services.Inventario;

namespace ProjetoModeloDDD.Domain.Services.Inventario
{
    public class LayoutImportacaoService : ServiceBase<LayoutImportacao>, ILayoutImportacaoService
    {
        private readonly ILayoutImportacaoRepository _layoutImportacaoRepository;

        public LayoutImportacaoService(ILayoutImportacaoRepository layoutImportacaoRepository) 
            : base(layoutImportacaoRepository)
        {
            _layoutImportacaoRepository = layoutImportacaoRepository;
        }
    }
}
