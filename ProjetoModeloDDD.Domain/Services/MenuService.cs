using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class MenuService : ServiceBase<Menu>, IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
            :base(menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public IEnumerable<Menu> FiltrarPorId(int MenuId)
        {
            return _menuRepository.FiltrarPorId(MenuId);
        }

    }
}
