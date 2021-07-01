using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities.Acesso;

namespace ProjetoModeloDDD.Application.Interface.Acesso
{
    //interface IClienteAppService
    public interface IPerfilUsuarioAppService : IAppServiceBase<PerfilUsuario>
    {
        int ConsultaGrupo(string Email);
    }
}