
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels.Inventario
{
    public class ItemControleInventarioViewModel
    {
        [Key]
        public int ItemControleInventarioId { get; set; }
        [Display(Name = "Cod. Depto")]
        public int DepartamentoId { get; set; }
        [Display(Name = "Cod. Seção")]
        public int SecaoId { get; set; }
        [Display(Name = "Cod. Grupo")]
        public int GrupoId { get; set; }
        [Display(Name = "Cod. SubGrupo")]
        public int SubGrupoId { get; set; }
        [Display(Name = "Contagem")]
        public int Contagem { get; set; }
        [Display(Name = "Status")]
        public int Status { get; set; }
        [Display(Name = "Cod. Inventário")]
        public int ControleInventarioId { get; set; }
        [Display(Name = "Cod. Produto")]
        public int ProdutoImportacaoId { get; set; }
        [Display(Name = "Usuário")]
        public string EmailUsuario { get; set; }
        [Display(Name = "Ident. Inicial")]
        public string IdentificadorInicial { get; set; }
        [Display(Name = "Ident. Fianl")]
        public string IdentificadorFinal { get; set; }
        [Display(Name = "Qtde Inicial")]
        public decimal QuantidadeInicial { get; set; }
        [Display(Name = "Qtde Final")]
        public decimal QuantidadeFinal { get; set; }
        [Display(Name = "Cod. EAN")]
        [Required(ErrorMessage = "Informe o Código do Produto")]
        public string strCodigoEan { get; set; }
        [Display(Name = "Cod. EAN")]
        public System.Int64 CodigoEan { get; set; }
        [Required(ErrorMessage = "Informe a Quantidade")]
        public decimal Quantidade { get; set; }
        [Required(ErrorMessage = "Informe o Identificador")]
        public int Identificador { get; set; }
        public ProdutoImportacaoViewModel ProdutoImportacao { get; set; }
        public string NomeProdutoImp { get; set; }
        public System.Nullable<decimal> QuantidadeImp { get; set; }
    }
}