using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface.Acesso;
using ProjetoModeloDDD.Domain.Entities.Acesso;
using ProjetoModeloDDD.MVC.ViewModels.Acesso;
using System.Web;
using System.IO;
using ProjetoModeloDDD.MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace ProjetoModeloDDD.MVC.Controllers.Acesso
{
    public class PerfilUsuariosController : Controller
    {

        private readonly IPerfilUsuarioAppService _perfilUsuarioAppService;
        private readonly IGrupoAppService _grupoAppService;
        private ApplicationUserManager _userManager;

        public PerfilUsuariosController(IPerfilUsuarioAppService perfilUsuarioAppService, IGrupoAppService grupoAppService)
        {
            _perfilUsuarioAppService = perfilUsuarioAppService;
            _grupoAppService = grupoAppService;

        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: PerfilUsuarios
        [Authorize]
        public ActionResult Index()
        {
            var perfilUsuarioViewModel = Mapper.Map<IEnumerable<PerfilUsuario>, IEnumerable<PerfilUsuarioViewModel>>(_perfilUsuarioAppService.GetAll());

            return View(perfilUsuarioViewModel);
        }

        // GET: PerfilUsuarios/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var perfilUsuario = _perfilUsuarioAppService.GetById(id);
            var perfilUsuarioViewModel = Mapper.Map<PerfilUsuario, PerfilUsuarioViewModel>(perfilUsuario);

            return View(perfilUsuarioViewModel);
        }

        // GET: PerfilUsuarios/Create   
        [Authorize]
        public ActionResult Create()
        {
            IEnumerable<ApplicationUser> appUsers = UserManager.Users;

            ViewBag.SelectListEmail = new SelectList(appUsers, "UserName", "Email");

            ViewBag.SelectListGrupo = new SelectList(_grupoAppService.GetAll().ToList(), "GrupoId", "Nome");

            return View();
        }

        // POST: PerfilUsuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(PerfilUsuarioViewModel perfilUsuario)
        {
            if (ModelState.IsValid)
            {
                var perfilUsuarioDomain = Mapper.Map<PerfilUsuarioViewModel, PerfilUsuario>(perfilUsuario);
                _perfilUsuarioAppService.Add(perfilUsuarioDomain);

                return RedirectToAction("Index");
            }

            return View(perfilUsuario);
        }

        // GET: PerfilUsuarios/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var perfilUsuario = _perfilUsuarioAppService.GetById(id);
            var perfilUsuarioViewModel = Mapper.Map<PerfilUsuario, PerfilUsuarioViewModel>(perfilUsuario);
            IEnumerable<ApplicationUser> appUsers = UserManager.Users;

            ViewBag.SelectListEmail = new SelectList(appUsers, "UserName", "Email", perfilUsuarioViewModel.Email);

            ViewBag.SelectListGrupo = new SelectList(_grupoAppService.GetAll().ToList(), "GrupoId", "Nome", perfilUsuarioViewModel.GrupoId);

            return View(perfilUsuarioViewModel);
        }

        // POST: PerfilUsuarios/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PerfilUsuarioViewModel perfilUsuario)
        {
            if (ModelState.IsValid)
            {
                var perfilUsuarioDomain = Mapper.Map<PerfilUsuarioViewModel, PerfilUsuario>(perfilUsuario);
                _perfilUsuarioAppService.Update(perfilUsuarioDomain);

                return RedirectToAction("Index");
            }

            return View(perfilUsuario);
        }

        // GET: PerfilUsuario/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var perfilUsuario = _perfilUsuarioAppService.GetById(id);
            var perfilUsuarioViewModel = Mapper.Map<PerfilUsuario, PerfilUsuarioViewModel>(perfilUsuario);

            return View(perfilUsuarioViewModel);
        }

        // POST: PerfilUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var perfilUsuario = _perfilUsuarioAppService.GetById(id);
            _perfilUsuarioAppService.Remove(perfilUsuario);

            return RedirectToAction("Index");
        }
    }
}
