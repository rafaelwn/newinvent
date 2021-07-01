

using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IMenuService : IServiceBase<Menu>
    {
        IEnumerable<Menu> FiltrarPorId(int MenuId);
    }
}
