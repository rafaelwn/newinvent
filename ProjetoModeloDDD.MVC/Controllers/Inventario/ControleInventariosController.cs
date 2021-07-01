using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface.Inventario;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.MVC.ViewModels.Inventario;

namespace ProjetoModeloDDD.MVC.Controllers.Inventario
{
    public class ControleInventariosController : Controller
    {
        private readonly IControleInventarioAppService _controleInventarioAppService;
        private readonly IItemControleInventarioAppService _itemControleInventarioAppService;

        public ControleInventariosController(IControleInventarioAppService controleInventarioAppService, IItemControleInventarioAppService itemControleInventarioAppService)
        {
            _controleInventarioAppService = controleInventarioAppService;
            _itemControleInventarioAppService = itemControleInventarioAppService;
        }

        // GET: ControleInventarios
        [Authorize]
        public ActionResult Index()
        {
            var controleInventarioViewModel = Mapper.Map<IEnumerable<ControleInventario>, IEnumerable<ControleInventarioViewModel>>(_controleInventarioAppService.GetAll());
            controleInventarioViewModel = controleInventarioViewModel.OrderByDescending(c => c.ControleInventarioId);

            return View(controleInventarioViewModel);
        }

        [Authorize]
        public ActionResult Filter(string ControleInventarioId)
        {
            int valor;
            if (Int32.TryParse(ControleInventarioId, out valor))
            {
                var controleInventarioViewModel = Mapper.Map<IEnumerable<ControleInventario>, IEnumerable<ControleInventarioViewModel>>(_controleInventarioAppService.GetAll());
                controleInventarioViewModel = controleInventarioViewModel.Where
                    (
                        s => s.ControleInventarioId == valor
                    )
                    .OrderByDescending(c => c.ControleInventarioId);                
                return PartialView(controleInventarioViewModel);
            }
            else
            {
                var controleInventarioViewModel = Mapper.Map<IEnumerable<ControleInventario>, IEnumerable<ControleInventarioViewModel>>
                    (
                        _controleInventarioAppService.GetAll()
                    );
                controleInventarioViewModel = controleInventarioViewModel
                    .OrderByDescending(c => c.ControleInventarioId);
                
                return PartialView(controleInventarioViewModel);
            }     

        }

        // GET: ControleInventarios/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var controleInventario = _controleInventarioAppService.GetById(id);
            var controleInventarioViewModel = Mapper.Map<ControleInventario, ControleInventarioViewModel>(controleInventario);

            return View(controleInventarioViewModel);
        }

        // GET: ControleInventarios/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ControleInventarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(ControleInventarioViewModel controleInventario)
        {
            if (ModelState.IsValid)
            {
                var controleInventarioDomain = Mapper.Map<ControleInventarioViewModel, ControleInventario>(controleInventario);
                controleInventarioDomain.DataInicio = DateTime.Now;
                _controleInventarioAppService.Add(controleInventarioDomain);

                return RedirectToAction("Index");
            }

            return View(controleInventario);
        }

        // GET: ControleInventarios/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var controleInvenatrio = _controleInventarioAppService.GetById(id);
            var controleInventarioViewModel = Mapper.Map<ControleInventario, ControleInventarioViewModel>(controleInvenatrio);
            var itemControleInventarioViewModel = Mapper.Map<IEnumerable<ItemControleInventario>, IEnumerable<ItemControleInventarioViewModel>>(_itemControleInventarioAppService.GetAll());

            // filtro
            if (id > 0)
            {
                itemControleInventarioViewModel = itemControleInventarioViewModel.Where
                        (
                            s => s.ControleInventarioId.Equals(id)
                        )
                        .OrderByDescending(c => c.ItemControleInventarioId);
                controleInventarioViewModel.ItensControleInventario = itemControleInventarioViewModel;
            }

            return View(controleInventarioViewModel);
        }

        // POST: ControleInventarios/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ControleInventarioViewModel controleInventario)
        {
            if (ModelState.IsValid)
            {
                var controleInventarioDomain = Mapper.Map<ControleInventarioViewModel, ControleInventario>(controleInventario);
                _controleInventarioAppService.Update(controleInventarioDomain);

                return RedirectToAction("Index");
            }

            return View(controleInventario);
        }

        [Authorize]
        public ActionResult Finalizar(int id)
        {
            var controleInventario = _controleInventarioAppService.GetById(id);
            controleInventario.DataFim = DateTime.Now;
            _controleInventarioAppService.Update(controleInventario);
            var controleInventarioViewModel = Mapper.Map<ControleInventario, ControleInventarioViewModel>(controleInventario);

            return RedirectToAction("Index");
        }

        [Authorize]
        public int ConsultarStatus(int id)
        {
            var controleInventario = _controleInventarioAppService.GetById(id);
            if (controleInventario.DataFim == null)
	        {
                return 0;
	        }
            else
            {
                return 1;
            }
        }

        // GET: ControleInventarios/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var controleInventario = _controleInventarioAppService.GetById(id);
            var controleInventarioViewModel = Mapper.Map<ControleInventario, ControleInventarioViewModel>(controleInventario);

            return View(controleInventarioViewModel);
        }

        // POST: ControleInventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var controleInventario = _controleInventarioAppService.GetById(id);
            _controleInventarioAppService.Remove(controleInventario );

            return RedirectToAction("Index");
        }
    }
}
