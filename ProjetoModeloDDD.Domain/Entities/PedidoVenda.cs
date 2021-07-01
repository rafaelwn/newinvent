using System.Collections.Generic;


namespace ProjetoModeloDDD.Domain.Entities
{
    public class PedidoVenda
    {
        public int PedidoVendaId { get; set; }
        public System.DateTime Data { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<TipoPagamentoPedidoVenda> TiposPagamentoPedidosVenda { get; set; }
        public IEnumerable<ItemPedidoVenda> ItensPedidoVenda { get; set; }
        public string Observacao { get; set; }
    }
}
