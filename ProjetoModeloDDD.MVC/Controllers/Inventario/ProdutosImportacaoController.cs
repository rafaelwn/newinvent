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
using System.Web.Routing;
using System.Configuration;

namespace ProjetoModeloDDD.MVC.Controllers.Inventario
{
    public class ProdutosImportacaoController : Controller
    {

        private readonly IProdutoImportacaoAppService _produtoImportacaoApp;

        public ProdutosImportacaoController(IProdutoImportacaoAppService produtoImportacaoApp)
        {
            _produtoImportacaoApp = produtoImportacaoApp; 
        }

        // GET: ProdutosImportacao
        [Authorize]
        public ActionResult Index(string Mensagem)
        {
            var produtoImportacaoViewModel = Mapper.Map<IEnumerable<ProdutoImportacao>, IEnumerable<ProdutoImportacaoViewModel>>(_produtoImportacaoApp.GetAll().Take(50));

            if (Session["mensagem_importacao"] != null)
            {
                ViewBag.Message = Session["mensagem_importacao"].ToString();
            }

            return View(produtoImportacaoViewModel);
        }

        [Authorize]
        public ActionResult Filter(string CodigoEan)
        {  
            long valor;
            if (long.TryParse(CodigoEan, out valor))
            {
                var produtoImportacaoViewModel = Mapper.Map<IEnumerable<ProdutoImportacao>, IEnumerable<ProdutoImportacaoViewModel>>(_produtoImportacaoApp.Filter(valor));
                return PartialView(produtoImportacaoViewModel);
            }
            else
            {
                var produtoImportacaoViewModel = Mapper.Map<IEnumerable<ProdutoImportacao>, IEnumerable<ProdutoImportacaoViewModel>>(_produtoImportacaoApp.GetAll().Take(50));
                return PartialView(produtoImportacaoViewModel);
            }
        }

        [Authorize]
        public ActionResult FileUpload()
        {
            HttpPostedFileBase arquivo = Request.Files[0];
            string caminhoArquivo = string.Empty;            

            if (arquivo.ContentLength > 0)
            {
                var uploadPath = Server.MapPath("~/Content/Uploads");
                caminhoArquivo = Path.Combine(@uploadPath, Path.GetFileName(arquivo.FileName));
                
                if (!System.IO.File.Exists(caminhoArquivo))
                {
                    // SALVAR O ARQUIVO
                    arquivo.SaveAs(caminhoArquivo);
                }                
            }

            Session["mensagem_importacao"]  = Importar(caminhoArquivo);            

            return RedirectToAction( "Index", new RouteValueDictionary(
            new { controller = "ProdutosImportacao", action = "Index", Mensagem = "" }));
        }

        public string Importar(string caminhoArquivo)
        {

            if (!string.IsNullOrEmpty(caminhoArquivo))
            {
                try
                {
                    string strConexao = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    var produtoImportacaoViewModel = Mapper.Map<IEnumerable<ProdutoImportacao>, IEnumerable<ProdutoImportacaoViewModel>>(_produtoImportacaoApp.ImportarTxt(caminhoArquivo, strConexao));
                    return "Arquivo Importado com sucesso!";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }     
               
            }
            else
            {
                return null;
            }
        }
    }
}
