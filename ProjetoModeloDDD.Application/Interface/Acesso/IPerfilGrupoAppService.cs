using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities.Acesso;

namespace ProjetoModeloDDD.Application.Interface.Acesso
{
    //interface IClienteAppService
    public interface IPerfilGrupoAppService : IAppServiceBase<PerfilGrupo>
    {
        List<int> ConsultaPerfilGrupo(string Email);
    }
}