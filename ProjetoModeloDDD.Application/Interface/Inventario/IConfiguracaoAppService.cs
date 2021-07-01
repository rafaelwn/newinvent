
using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities.Inventario;


namespace ProjetoModeloDDD.Application.Interface.Inventario
{
    public interface IConfiguracaoAppService : IAppServiceBase<Configuracao>
    {
        IEnumerable<Configuracao> Filter(int Id);
    }
}
