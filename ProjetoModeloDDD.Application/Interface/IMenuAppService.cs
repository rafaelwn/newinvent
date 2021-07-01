
using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IMenuAppService : IAppServiceBase<Menu>
    {
        IEnumerable<Menu> FiltrarPorId(int MenuId);

        IEnumerable<Menu> ControleAcesso(List<int> IdsMenu);
    }
}
