using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Application.Interface.Acesso;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System.Security.Principal;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class MenusController : Controller
    {

        private readonly IMenuAppService _menuApp;
        private readonly IPerfilGrupoAppService _perfilGrupoAppService;
        
        public MenusController(IMenuAppService menuApp, IPerfilGrupoAppService perfilgrupoAppService)
        {            
            _menuApp = menuApp;
            _perfilGrupoAppService = perfilgrupoAppService;
        }

        // GET: Menus
        [Authorize]
        public ActionResult Index()
        {
            var menuViewModel = Mapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModel>>(_menuApp.GetAll());

            return View(menuViewModel);
        }

        // GET: Menus/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {

            var menu = _menuApp.GetById(id);
            var menuViewModel = Mapper.Map<Menu, MenuViewModel>(menu);

            return View(menuViewModel);
        }

        // GET: Menus/ExibirGrupoMenu ( Porta de entrada do sistema )
        [Authorize]
        public ActionResult ExibirGrupoMenu(int id)
        {
            var IdsMenu = _perfilGrupoAppService.ConsultaPerfilGrupo(User.Identity.Name);

            var menuViewModel = Mapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModel>>(_menuApp.ControleAcesso(IdsMenu));            

            return View(menuViewModel);
        }

        // GET: Menus/Create
        [Authorize]
        public ActionResult Create()
        {            
            return View();
        }

        // POST: Menus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(MenuViewModel menu)
        {
            if (ModelState.IsValid)
            {
                var menuDomain = Mapper.Map<MenuViewModel, Menu>(menu);
                _menuApp.Add(menuDomain);

                return RedirectToAction("Index");
            }

            return View(menu);


        }

        // GET: Menus/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var menu = _menuApp.GetById(id);
            var menuViewModel = Mapper.Map<Menu, MenuViewModel>(menu);

            //ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", menuViewModel.ClienteId.ToString());

            return View(menuViewModel);
        }

        // POST: Menus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(MenuViewModel menu)
        {
            if (ModelState.IsValid)
            {
                var menuDomain = Mapper.Map<MenuViewModel, Menu>(menu);
                _menuApp.Update(menuDomain);

                return RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: Menus/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var menu = _menuApp.GetById(id);
            var menuViewModel = Mapper.Map<Menu, MenuViewModel>(menu);

            return View(menuViewModel);

        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var menu = _menuApp.GetById(id);
            _menuApp.Remove(menu);

            return RedirectToAction("Index");
        }
    }
}