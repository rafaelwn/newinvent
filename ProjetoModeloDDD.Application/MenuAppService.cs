
using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Linq;

namespace ProjetoModeloDDD.Application
{
    public class MenuAppService : AppServiceBase<Menu>, IMenuAppService
    {
        private readonly IMenuService _menuService;

        public MenuAppService(IMenuService menuService)
            : base(menuService)
        {
            _menuService = menuService;
        }

        public IEnumerable<Menu> FiltrarPorId(int MenuId)
        {
            return _menuService.FiltrarPorId(MenuId);
        }

        public IEnumerable<Menu> ControleAcesso(List<int> IdsMenu)
        {
            var menuService = _menuService.GetAll();

            // filtro PerfilGrupo
            if (IdsMenu.Count > 0)
            {               
                var consultaMenus = menuService.Where(x => IdsMenu.Contains(x.MenuId));

                return consultaMenus;                 
            }

            return menuService;
        }
    }
}
