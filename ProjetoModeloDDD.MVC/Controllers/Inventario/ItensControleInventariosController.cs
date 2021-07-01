using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface.Inventario;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.MVC.ViewModels.Inventario;
using NPOI.HSSF.Model; // InternalWorkbook
using NPOI.HSSF.UserModel; // HSSFWorkbook, HSSFSheet
using System.IO;
using NPOI.SS.UserModel;
using System.Text;
using System.Data.Entity.Core.Objects;

namespace ProjetoModeloDDD.MVC.Controllers.Inventario
{
    public class ItensControleInventariosController : Controller
    {
        private readonly IItemControleInventarioAppService _itemControleInventarioAppService;
        private readonly IRelatorioFinalAppService _relatorioFinalAppService;

        public ItensControleInventariosController(IItemControleInventarioAppService itemControleInventarioAppService, IRelatorioFinalAppService relatorioFinalAppService)
        {
            _itemControleInventarioAppService = itemControleInventarioAppService;
            _relatorioFinalAppService = relatorioFinalAppService;
        }

        // GET: ItensControleInventarios
        public ActionResult Index()
        {
            var itemControleInventarioViewModel = Mapper.Map<IEnumerable<ItemControleInventario>, IEnumerable<ItemControleInventarioViewModel>>(_itemControleInventarioAppService.ConsultaItensInventario());

            return View(itemControleInventarioViewModel);
        }
        
        //public ActionResult Filter(int ControleInventarioId, int CodigoEan, int Quantidade, string EmailUsuario)        
        [Authorize]
        public ActionResult Filter(string CodigoEan, string EmailUsuario, string Quantidade )
        {  
            var itemControleInventarioViewModel = Mapper.Map<IEnumerable<ItemControleInventario>, IEnumerable<ItemControleInventarioViewModel>>(_itemControleInventarioAppService.ConsultaItensInventario());
            Int64 CodigoEanN = 0;
            decimal QuantidadeN = 0;


            if (!string.IsNullOrEmpty(CodigoEan))
            {
                CodigoEanN = Convert.ToInt64(String.Join("", System.Text.RegularExpressions.Regex.Split(CodigoEan, @"[^\d]")));            
            }

            if (!string.IsNullOrEmpty(CodigoEan) && !string.IsNullOrEmpty(EmailUsuario) && !string.IsNullOrEmpty(Quantidade))
            {
                // filtro      
                QuantidadeN = Convert.ToDecimal(Quantidade);            
                itemControleInventarioViewModel = itemControleInventarioViewModel.Where(
                     q => q.EmailUsuario.Contains(EmailUsuario) && q.CodigoEan.Equals(CodigoEanN) && q.Quantidade.Equals(QuantidadeN)
                    );
            }
            else if (!string.IsNullOrEmpty(CodigoEan) && !string.IsNullOrEmpty(Quantidade))
            {
                // filtro   
                QuantidadeN = Convert.ToDecimal(Quantidade);
                itemControleInventarioViewModel = itemControleInventarioViewModel.Where(
                                                  q => q.CodigoEan.Equals(CodigoEanN) && q.Quantidade.Equals(QuantidadeN)
                                                  );
            }
            else if (!string.IsNullOrEmpty(CodigoEan) && !string.IsNullOrEmpty(EmailUsuario))
            {
                // filtro                
                itemControleInventarioViewModel = itemControleInventarioViewModel.Where(
                                                  q => q.EmailUsuario.Contains(EmailUsuario) && q.CodigoEan.Equals(CodigoEanN) 
                                                  );
            }
            else if (!string.IsNullOrEmpty(EmailUsuario))
            {
                // filtro
                itemControleInventarioViewModel = itemControleInventarioViewModel.Where(
                                                  q => q.EmailUsuario.Contains(EmailUsuario)
                                                  );
            } 
            else if (!string.IsNullOrEmpty(CodigoEan) )
            {
                // filtro
                itemControleInventarioViewModel = itemControleInventarioViewModel.Where(
                                                  q => q.CodigoEan ==  CodigoEanN
                                                  );
            }       

            return PartialView(itemControleInventarioViewModel);
        }

        // GET: ItensControleInventarios/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var itemControleInventario = _itemControleInventarioAppService.GetById(id);
            var itemControleInventarioViewModel = Mapper.Map<ItemControleInventario, ItemControleInventarioViewModel>(itemControleInventario);

            return View(itemControleInventarioViewModel);
        }

        // GET: ItensControleInventarios/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItensControleInventarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(ItemControleInventarioViewModel itemControleInventario)
        {
            if (ModelState.IsValid)
            {                
                // VALIDAR O TAMANHO DO CÓDIGO EAN
                if (itemControleInventario.strCodigoEan.Length > 13)
                {
                    ViewBag.DescricaoProduto = "Código Ean maior que 13 dígitos!";
                    return View(itemControleInventario);
                }
                // CONVERTER CODIGO EAN PARA NUMÉRICO
                itemControleInventario.CodigoEan = Convert.ToInt64(String.Join("", System.Text.RegularExpressions.Regex.Split(itemControleInventario.strCodigoEan, @"[^\d]")));

                //itemControleInventario.EmailUsuario = User.Identity.Name;                

                var itemControleInventarioDomain = Mapper.Map<ItemControleInventarioViewModel, ItemControleInventario>(itemControleInventario);
                var itemControleInventarioSalvo = _itemControleInventarioAppService.AdicionarColeta(itemControleInventarioDomain);

                ViewBag.QuantidadeColeta = itemControleInventarioSalvo.Quantidade;
                ViewBag.DescricaoProduto = itemControleInventarioSalvo.ProdutoImportacao.NomeProduto;     
            }

            return View(itemControleInventario);
        }

        // POST: ItensControleInventarios/Create
        [HttpGet]        
        public string CreateWS()
        {

            ItemControleInventarioViewModel itemControleInventario = new ItemControleInventarioViewModel();
            string retorno = string.Empty;

            string Quantidade = Request.QueryString["Quantidade"];
            string CodEAN = Request.QueryString["CodEAN"];
            string Identificador = Request.QueryString["Identificador"];
            string Usuario = Request.QueryString["Usuario"];            

            if (Identificador == "consultar_ean" && Quantidade == "0")
            {
                return ConsultarEAN(itemControleInventario, ref retorno, CodEAN);
            }
            else
            {       
                return GravarColeta(itemControleInventario, ref retorno, Quantidade, CodEAN, Identificador, Usuario);
            }         

        }

        private string ConsultarEAN(ItemControleInventarioViewModel itemControleInventario, ref string retorno, string CodEAN)
        {
            try
            {
                itemControleInventario.strCodigoEan = CodEAN;
            }
            catch (Exception ex)
            {
                return "001|Erro na conversão dos valores";
            }

            // CONVERTER CODIGO EAN PARA NUMÉRICO
            itemControleInventario.CodigoEan = Convert.ToInt64(String.Join("", System.Text.RegularExpressions.Regex.Split(itemControleInventario.strCodigoEan, @"[^\d]")));

            // VALIDAR O TAMANHO DO CÓDIGO EAN
            if (itemControleInventario.CodigoEan.ToString().Length > 13)
            {
                return "002|Código Ean maior que 13 dígitos!";
            }

            try
            {
                var itemControleInventarioDomain = Mapper.Map<ItemControleInventarioViewModel, ItemControleInventario>(itemControleInventario);
                var itemControleInventarioConsulta = _itemControleInventarioAppService.ConsultarEAN(itemControleInventarioDomain);
                retorno = "777|" + itemControleInventarioConsulta.ProdutoImportacao.NomeProduto;
            }
            catch (Exception ex)
            {
                retorno = "003|Erro ao gravar coleta";
            }

            return retorno;
        }

        private string GravarColeta(ItemControleInventarioViewModel itemControleInventario, ref string retorno, string Quantidade, string CodEAN, string Identificador, string Usuario)
        {
            try
            {
                itemControleInventario.strCodigoEan = CodEAN;
                itemControleInventario.Quantidade = Convert.ToDecimal(Quantidade);
                itemControleInventario.Identificador = Convert.ToInt32(Identificador);
            }
            catch (Exception ex)
            {
                return "001|Erro na conversão dos valores";
            }

            // CONVERTER CODIGO EAN PARA NUMÉRICO
            itemControleInventario.CodigoEan = Convert.ToInt64(String.Join("", System.Text.RegularExpressions.Regex.Split(itemControleInventario.strCodigoEan, @"[^\d]")));

            // VALIDAR O TAMANHO DO CÓDIGO EAN
            if (itemControleInventario.CodigoEan.ToString().Length > 13)
            {
                return "002|Código Ean maior que 13 dígitos!";
            }

            itemControleInventario.EmailUsuario = Usuario; //User.Identity.Name;

            try
            {
                var itemControleInventarioDomain = Mapper.Map<ItemControleInventarioViewModel, ItemControleInventario>(itemControleInventario);
                var itemControleInventarioSalvo = _itemControleInventarioAppService.AdicionarColeta(itemControleInventarioDomain);
                retorno = "888|" + itemControleInventarioSalvo.ProdutoImportacao.NomeProduto + "|" + itemControleInventarioSalvo.Quantidade;
            }
            catch (Exception ex)
            {

                return "003|Erro ao gravar coleta";
            }

            return retorno;
        }

        // GET: ItensControleInventarios/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var itemControleInvenatrio = _itemControleInventarioAppService.GetById(id);
            var itemControleInventarioViewModel = Mapper.Map<ItemControleInventario, ItemControleInventarioViewModel>(itemControleInvenatrio);

            return View(itemControleInventarioViewModel);
        }

        // POST: ItensControleInventarios/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ItemControleInventarioViewModel itemControleInventario)
        {
         
            var itemControleInventarioDomain = Mapper.Map<ItemControleInventarioViewModel, ItemControleInventario>(itemControleInventario);
            _itemControleInventarioAppService.Update(itemControleInventarioDomain);       
            return View(itemControleInventario);
        }

        // GET: ItensControleInventarios/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var itemControleInventario = _itemControleInventarioAppService.GetById(id);
            var itemControleInventarioViewModel = Mapper.Map<ItemControleInventario, ItemControleInventarioViewModel>(itemControleInventario);

            return View(itemControleInventarioViewModel);            
        }

        // POST: ItensControleInventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var itemControleInventario = _itemControleInventarioAppService.GetById(id);
            _itemControleInventarioAppService.Remove(itemControleInventario);

            ViewBag.Mensagem = "ARQUIVO EXCLUIDO!";

            var itemControleInventarioViewModel = Mapper.Map<ItemControleInventario, ItemControleInventarioViewModel>(itemControleInventario);

            return View(itemControleInventarioViewModel);
        }        

        public FileResult ExportResultadosTXT(int ControleInventarioId)
        {
            StringBuilder stb = new StringBuilder();
            MemoryStream stream = new MemoryStream();
            StreamWriter csvWriter = new StreamWriter(stream, Encoding.UTF8);
            string LogErro = string.Empty;

            try
            {
                var relatorioFinalViewModel = Mapper.Map<IEnumerable<RelatorioFinal>,
                IEnumerable<RelatorioFinalViewModel>>(
                    _relatorioFinalAppService.RelatorioExportTXT(ControleInventarioId)
                );

                string zeros_esquerda;

                foreach (RelatorioFinalViewModel obj in relatorioFinalViewModel)
                {
                    LogErro = "--- Codigo EAN: " + obj.CodigoEan.ToString() + " --- obj.Qtde_Total_Coletado.ToString(): " + obj.Qtde_Total_Coletado.ToString() + " --- obj.CodigoEan.ToString().Length: " + obj.CodigoEan.ToString().Length.ToString() + " -  obj.Qtde_Total_Coletado.ToString().Length: " + obj.Qtde_Total_Coletado.ToString().Length.ToString();
                    stb.Clear();
                    zeros_esquerda = new String('0', 13 - obj.CodigoEan.ToString().Length);
                    stb.Append(zeros_esquerda + obj.CodigoEan);
                    zeros_esquerda = new String('0', 9 - obj.Qtde_Total_Coletado.ToString().Length);
                    stb.Append(zeros_esquerda + obj.Qtde_Total_Coletado + "\n");

                    csvWriter.WriteLine(stb.ToString().Replace(",", ""));

                    csvWriter.Flush();
                }

                stream.Position = 0;

            }
            catch (Exception ex)
            {

                throw new ArgumentException("LogErro: " + LogErro + " Detalhe Erro: " + ex.StackTrace);
            }

            return File(stream, "text/plain", "ExportacaoInventarioNewInvent.txt");
        }

        public FileResult ExportRelatorioFinal(int ControleInventarioId)
        {
            var relatorioFinalViewModel = Mapper.Map<IEnumerable<RelatorioFinal>, 
                IEnumerable<RelatorioFinalViewModel>>(
                    _relatorioFinalAppService.Relatorio(ControleInventarioId)
                );

            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet("Relatorio Final");
            var headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("Cod. Inventário");
            headerRow.CreateCell(1).SetCellValue("Identificador");
           
            headerRow.CreateCell(2).SetCellValue("Cod. EAN");
            headerRow.CreateCell(3).SetCellValue("Nome Produto");
            headerRow.CreateCell(4).SetCellValue("Qtde Inicial");
            headerRow.CreateCell(5).SetCellValue("Qtde Física");
            headerRow.CreateCell(6).SetCellValue("Diferença");
            headerRow.CreateCell(7).SetCellValue("Total Custo");
            headerRow.CreateCell(8).SetCellValue("Total Venda");
            sheet.CreateFreezePane(0, 1, 0, 1);

            int rowNumber = 1;
            foreach (RelatorioFinalViewModel obj in relatorioFinalViewModel)
            {
                //var datestyle = SetCellStyle(workbook, "dd/MM/yyyy");

                var row = sheet.CreateRow(rowNumber++);
                row.CreateCell(0).SetCellValue(TNulo(obj.ControleInventarioId,false));
                row.CreateCell(1).SetCellValue(TNulo(obj.Identificador, false));
                
                row.CreateCell(2).SetCellValue(TNulo(obj.CodigoEan, false));
                row.CreateCell(3).SetCellValue(TNulo(obj.NomeProduto, false));
                row.CreateCell(4).SetCellValue(Convert.ToDouble(TNulo(obj.Qtde_Total_ERP, true)));
                row.CreateCell(5).SetCellValue(Convert.ToDouble(TNulo(obj.Qtde_Total_Invent, true)));
                row.CreateCell(6).SetCellValue(Convert.ToDouble(TNulo(obj.Diferenca, true)));
                row.CreateCell(7).SetCellValue(Convert.ToDouble(TNulo(obj.PrecoUnitario, true)));
                row.CreateCell(8).SetCellValue(Convert.ToDouble(TNulo(obj.PrecoVendaUnitario, true)));        

                //row.Cells[1].CellStyle = datestyle;
                //row.Cells[2].CellStyle = datestyle;
            }

            MemoryStream output = new MemoryStream();
            workbook.Write(output);
            return File(output.ToArray(), "application/vnd.ms-excel", "Relat_Final.xls");
        }

        public FileResult ExportRelatorioProdutividade(int ControleInventarioId)
        {
            var relatorioFinalViewModel = Mapper.Map<IEnumerable<RelatorioFinal>,
                IEnumerable<RelatorioFinalViewModel>>(
                    _relatorioFinalAppService.RelatorioProdutividade(ControleInventarioId)
                );

            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet("Relatorio de Produtividade");
            var headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("Cod. Inventário");
            headerRow.CreateCell(1).SetCellValue("Coletor");
            headerRow.CreateCell(2).SetCellValue("Qtde. Total Coletado");
            headerRow.CreateCell(3).SetCellValue("Qtde. Produtos Coletado");
            sheet.CreateFreezePane(0, 1, 0, 1);

            int rowNumber = 1;
            foreach (RelatorioFinalViewModel obj in relatorioFinalViewModel)
            {
                //var datestyle = SetCellStyle(workbook, "dd/MM/yyyy");

                var row = sheet.CreateRow(rowNumber++);
                row.CreateCell(0).SetCellValue(TNulo(obj.ControleInventarioId, false));
                row.CreateCell(1).SetCellValue(TNulo(obj.EmailUsuario, false));
                row.CreateCell(2).SetCellValue(Convert.ToDouble(TNulo(obj.Qtde_Total_Coletado, true)));
                row.CreateCell(3).SetCellValue(Convert.ToDouble(TNulo(obj.Qtde_Produtos_Coletado, true)));

                //row.Cells[1].CellStyle = datestyle;
                //row.Cells[2].CellStyle = datestyle;
            }

            MemoryStream output = new MemoryStream();
            workbook.Write(output);
            return File(output.ToArray(), "application/vnd.ms-excel", "Relat_Produtiviadade.xls");
        }

        private ICellStyle SetCellStyle(HSSFWorkbook workbook, string format)
        {
            ICellStyle cellStyle = workbook.CreateCellStyle();            
            IDataFormat dataFormatCustom = workbook.CreateDataFormat();
            cellStyle.DataFormat = dataFormatCustom.GetFormat(format);

            return cellStyle;                       
        }

        private string TNulo (object valor, bool Numerico)
        {
            if (Numerico)
            {
                if (valor == null)
                {
                    return "0";
                }
                else
                {
                    return valor.ToString();
                }
            }
            else
            {
                if (valor == null)
                {
                    return "";
                }
                else
                {
                    return valor.ToString();
                }
            }

        }

    }
}
