
using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class TipoPagamentoPedidoVendaService  : ServiceBase<TipoPagamentoPedidoVenda>, ITipoPagamentoPedidoVendaService
    {
        private readonly ITipoPagamentoPedidoVendaRepository _tipoPagamentoPedidoVendaRepository;

        public TipoPagamentoPedidoVendaService(ITipoPagamentoPedidoVendaRepository tipoPagamentoPedidoVendaRepository)
            : base(tipoPagamentoPedidoVendaRepository)
        {
            _tipoPagamentoPedidoVendaRepository = tipoPagamentoPedidoVendaRepository;
        }
    }
}
