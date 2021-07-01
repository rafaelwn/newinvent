
using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Repositories.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Services.Inventario;

namespace ProjetoModeloDDD.Domain.Services.Inventario
{
    public class ConfiguracaoService : ServiceBase<Configuracao>, IConfiguracaoService
    {
        private readonly IConfiguracaoRepository _configuracaoRepositoty;

        public ConfiguracaoService(IConfiguracaoRepository configuracaoRepository)
            : base(configuracaoRepository)
        {
            _configuracaoRepositoty = configuracaoRepository;
        }
    }
}
