
using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class PedidoVendaService : ServiceBase<PedidoVenda>, IPedidoVendaService
    {
        private readonly IPedidoVendaRepository _pedidoVendaRepository;

        public PedidoVendaService(IPedidoVendaRepository pedidoVendaRepository)
            : base(pedidoVendaRepository)
        {
            _pedidoVendaRepository = pedidoVendaRepository;
        }
    }
}
