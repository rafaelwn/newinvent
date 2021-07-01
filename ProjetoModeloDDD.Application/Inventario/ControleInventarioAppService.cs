
using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface.Inventario;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Services.Inventario;
using System.Linq;

namespace ProjetoModeloDDD.Application.Inventario
{
    public class ControleInventarioAppService: AppServiceBase<ControleInventario>, IControleInventarioAppService
    {
        private readonly IControleInventarioService _controleInventarioService;

        public ControleInventarioAppService(IControleInventarioService controleInventarioService)
            : base(controleInventarioService)
        {
            _controleInventarioService = controleInventarioService;
        }

    }
}
