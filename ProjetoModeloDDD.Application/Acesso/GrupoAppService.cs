
using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface.Acesso;
using ProjetoModeloDDD.Domain.Entities.Acesso;
using ProjetoModeloDDD.Domain.Interfaces.Services.Acesso;
using System.Linq;

namespace ProjetoModeloDDD.Application.Acesso
{
    public class GrupoAppService : AppServiceBase<Grupo>, IGrupoAppService
    {
        private readonly IGrupoService _grupoService;

        public GrupoAppService(IGrupoService grupoService)
            :base(grupoService)
        {
            _grupoService = grupoService;
        }
    }
}

