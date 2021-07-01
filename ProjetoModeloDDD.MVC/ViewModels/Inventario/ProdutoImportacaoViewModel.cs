using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels.Inventario
{
    /*PENDENCIA: INCLUIR / ALTERAR CAMPOS SEGUNDO A NOVA VERSÃO 
      DO DOCUMENTO DE LAYOUT DE IMPOTAÇÃO !!! 26/02/2015 12:00 */
    public class ProdutoImportacaoViewModel
    {
        [Key]
        public int ProdutoImportacaoId { get; set; }
        public Nullable<int> NumeroLoja { get; set; }
        public Nullable<DateTime> Data { get; set; }
        public Nullable<Int64> CodigoEan { get; set; }
        public string NomeProduto { get; set; }
        public Nullable<decimal> PrecoUnitario { get; set; }
        public Nullable<decimal> PrecoVendaUnitario { get; set; }
        public Nullable<decimal> Quantidade { get; set; }

        public Nullable<int> DepartamentoId { get; set; }
        public string NomeDepartamento { get; set; }
        public Nullable<int> SecaoId { get; set; }
        public string NomeSecao { get; set; }
        public Nullable<int> GrupoId { get; set; }
        public string NomeGrupo { get; set; }
        public Nullable<int> SubGrupoId { get; set; }
        public string NomeSubGrupo { get; set; }

        //public int Secao { get; set; }
        public  Nullable<int> Identificador { get; set; }
    }
}