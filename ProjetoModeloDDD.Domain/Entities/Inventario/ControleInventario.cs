using System;
using System.Collections.Generic;
 
namespace ProjetoModeloDDD.Domain.Entities.Inventario
{
    public class ControleInventario
    {
        public int ControleInventarioId { get; set; }
        public string Descricao { get; set; }
        public Nullable<DateTime> DataInicio { get; set; }
        public Nullable<DateTime> DataFim { get; set; }
        public string UsuarioEmail { get; set; }
        public string CodigoLoja { get; set; }
        public int NumeroLoja { get; set; }
        public int Contagem { get; set; }
        public int FaixaIdentificadorInicial { get; set; }
        public int FaixaIdentificadorFianl { get; set; }
        public string Observacoes { get; set; }
        public IEnumerable<ItemControleInventario> ItensControleInventario { get; set; }
    }
}
