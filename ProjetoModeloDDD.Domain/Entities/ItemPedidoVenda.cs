using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class ItemPedidoVenda
    {
        public int ItemPedidoVendaId { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public int PedidoVendaId { get; set; }
        public PedidoVenda PedidoVenda { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
