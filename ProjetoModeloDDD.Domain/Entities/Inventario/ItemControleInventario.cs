using System;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Entities.Inventario
{
    public class ItemControleInventario
    {
        public int ItemControleInventarioId { get; set; }
        public int DepartamentoId { get; set; }
        public int SecaoId { get; set; }
        public int GrupoId { get; set; }
        public int SubGrupoId { get; set; }
        public int Contagem { get; set; }
        public int Status { get; set; }
        public int ControleInventarioId { get; set; }
        public ControleInventario ControleInventario { get; set; }
        public int ProdutoImportacaoId { get; set; }
        public ProdutoImportacao ProdutoImportacao { get; set; }
        public string EmailUsuario { get; set; }
        public string IdentificadorInicial { get; set; }
        public string IdentificadorFinal { get; set; }
        public decimal QuantidadeInicial { get; set; }
        public decimal QuantidadeFinal { get; set; }
        public Int64 CodigoEan { get; set; }
        public decimal Quantidade { get; set; }
        public int Identificador { get; set; }
        public string NomeProdutoImp { get; set; }
        public Nullable<decimal> QuantidadeImp { get; set; }
    }
}
