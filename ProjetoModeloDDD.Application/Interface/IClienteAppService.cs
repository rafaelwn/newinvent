
using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;


namespace ProjetoModeloDDD.Application.Interface
{
    //interface IClienteAppService
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {

        IEnumerable<Cliente> ObterClientesEspeciais();

    }
}
