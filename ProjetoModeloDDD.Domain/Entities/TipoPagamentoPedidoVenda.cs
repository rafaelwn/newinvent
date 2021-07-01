

namespace ProjetoModeloDDD.Domain.Entities
{
    public class TipoPagamentoPedidoVenda
    {
        public int TipoPagamentoPedidoVendaId { get; set; }
        public int TipoPagamentoId { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public int PedidoVendaId { get; set; }
        public PedidoVenda PedidoVenda { get; set; }
        public double Valor { get; set; }
        
    }
}