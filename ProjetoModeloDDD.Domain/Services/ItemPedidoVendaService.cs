
using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class ItemPedidoVendaService  : ServiceBase<ItemPedidoVenda>, IItemPedidoVendaService
    {
        private readonly IItemPedidoVendaRepository _itemPedidoVendaRepository;

        public ItemPedidoVendaService(IItemPedidoVendaRepository itempedidovendaRepository)
            : base(itempedidovendaRepository)
        {
            _itemPedidoVendaRepository = itempedidovendaRepository;
        }
    }
}
