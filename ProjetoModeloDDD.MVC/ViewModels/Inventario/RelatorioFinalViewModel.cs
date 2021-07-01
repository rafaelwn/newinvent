using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ProjetoModeloDDD.MVC.ViewModels.Inventario
{
    public class RelatorioFinalViewModel
    {
        [Key]
        public Nullable<int> Id { get; set; }
        public Nullable<int> ControleInventarioId { get; set; }
        public Nullable<int> Identificador { get; set; }
        public Nullable<int> ProdutoImportacaoId { get; set; }
        public Nullable<Int64> CodigoEan { get; set; }
        public string NomeProduto { get; set; }
        public Nullable<decimal> Qtde_Total_Invent { get; set; }
        public Nullable<decimal> Qtde_Total_ERP { get; set; }
        public Nullable<decimal> Diferenca { get; set; }
        public Nullable<decimal> Qtde_Total_Coletado { get; set; }
        public Nullable<Int32> Qtde_Produtos_Coletado { get; set; }
        public Nullable<decimal> PrecoUnitario { get; set; }
        public Nullable<decimal> PrecoVendaUnitario { get; set; }
        public string EmailUsuario { get; set; }
    }
}