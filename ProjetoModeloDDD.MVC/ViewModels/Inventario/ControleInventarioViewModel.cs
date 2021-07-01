using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels.Inventario
{
    public class ControleInventarioViewModel
    {
        [Key]
        public int ControleInventarioId { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Data Início")]
        public Nullable<DateTime> DataInicio { get; set; }
        [Display(Name = "Data Fim")]
        public Nullable<DateTime> DataFim { get; set; }
        [Display(Name = "Usuário")]
        public string UsuarioEmail { get; set; }
        [Display(Name = "Cod. Loja")]
        public string CodigoLoja { get; set; }
        [Display(Name = "Num. Loja")]
        public int NumeroLoja { get; set; }
        [Display(Name = "Contagem")]
        public int Contagem { get; set; }
        [Display(Name = "F. Ident. Inicial")]
        public int FaixaIdentificadorInicial { get; set; }
        [Display(Name = "F. Ident. Final")]
        public int FaixaIdentificadorFianl { get; set; }
        [Display(Name = "Observações")]
        public string Observacoes { get; set; }   
        public IEnumerable<ItemControleInventarioViewModel> ItensControleInventario { get; set; }
    }
}