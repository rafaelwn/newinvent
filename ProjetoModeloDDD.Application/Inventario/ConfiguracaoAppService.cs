
using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface.Inventario;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Services.Inventario;
using System.Linq;

namespace ProjetoModeloDDD.Application.Inventario
{
    public class ConfiguracaoAppService: AppServiceBase<Configuracao>, IConfiguracaoAppService
    {
        private readonly IConfiguracaoService _configuracaoService;

        public ConfiguracaoAppService(IConfiguracaoService configuracaoService)
            : base(configuracaoService)
        {
            _configuracaoService = configuracaoService;
        }

        public IEnumerable<Configuracao> Filter(int Id)
        {
            var configuracao = _configuracaoService.GetAll();
            // filtro
            if (Id > 0)
            {
                configuracao = configuracao.Where
                        (
                            s => s.ConfiguracaoId == Id
                        );
            }

            return configuracao;

        }
    }
}
