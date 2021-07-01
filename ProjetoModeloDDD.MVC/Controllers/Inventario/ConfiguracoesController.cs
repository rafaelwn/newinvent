using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface.Inventario;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.MVC.ViewModels.Inventario;
using System.Web;
using System.IO;

namespace ProjetoModeloDDD.MVC.Controllers.Inventario
{
    public class ConfiguracoesController : Controller
    {
        private readonly IConfiguracaoAppService _configuracaoAppService;

        public ConfiguracoesController(IConfiguracaoAppService configuracaoAppService)
        {
            _configuracaoAppService = configuracaoAppService;
        }

        // GET: Configuracoes
        [Authorize]
        public ActionResult Index()
        {
            var configuracaViewModel = Mapper.Map<IEnumerable<Configuracao>, IEnumerable<ConfiguracaoViewModel>>(_configuracaoAppService.GetAll());

            return View(configuracaViewModel);
        }

        [Authorize]
        public ActionResult Filter(int Id)
        {
            var configuracaoViewModel = Mapper.Map<IEnumerable<Configuracao>, IEnumerable<ConfiguracaoViewModel>>(_configuracaoAppService.Filter(Id));

            return PartialView(configuracaoViewModel);

        }

        // GET: Configuracoes/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var configuracao = _configuracaoAppService.GetById(id);
            var configuracaoViewModel = Mapper.Map<Configuracao, ConfiguracaoViewModel>(configuracao);

            return View(configuracaoViewModel);
        }

        // GET: Configuracoes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Configuracoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(ConfiguracaoViewModel configuracao)
        {

            if (ModelState.IsValid)
            {
                var configuracaoDomain = Mapper.Map<ConfiguracaoViewModel, Configuracao>(configuracao);
                _configuracaoAppService.Add(configuracaoDomain);

                return RedirectToAction("Index");
            }

            return View(configuracao);
        }

        // GET: Configuracoes/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var configuracao = _configuracaoAppService.GetById(id);
            var configuracaoViewModel = Mapper.Map<Configuracao, ConfiguracaoViewModel>(configuracao);

            return View(configuracaoViewModel);
        }

        // POST: Configuracoes/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConfiguracaoViewModel configuracao)
        {
            if (ModelState.IsValid)
            {
                var configuracaoDomain = Mapper.Map<ConfiguracaoViewModel, Configuracao>(configuracao);
                _configuracaoAppService.Update(configuracaoDomain);

                return RedirectToAction("Index");
            }

            return View(configuracao);
        }

        // GET: Configuracoes/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var configuracao = _configuracaoAppService.GetById(id);
            var configuracaoViewModel = Mapper.Map<Configuracao, ConfiguracaoViewModel>(configuracao);

            return View(configuracaoViewModel);
        }

        // POST: Configuracoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var configuracao = _configuracaoAppService.GetById(id);
            _configuracaoAppService.Remove(configuracao);

            return RedirectToAction("Index");
        }
    }
}
