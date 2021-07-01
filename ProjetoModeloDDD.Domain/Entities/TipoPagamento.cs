using System.Collections.Generic;


namespace ProjetoModeloDDD.Domain.Entities
{
    public class TipoPagamento
    {
        public int TipoPagamentoId { get; set; }
        public string Descricao { get; set; }
        public decimal Taxa { get; set; }
        public IEnumerable<TipoPagamentoPedidoVenda> TiposPagamentoPedidosVenda { get; set; }

    }
}