
using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Repositories.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Services.Inventario;

namespace ProjetoModeloDDD.Domain.Services.Inventario
{
    public class ControleInventarioService : ServiceBase<ControleInventario>, IControleInventarioService
    {
        private readonly IControleInventarioRepository _controleInventarioRepositoty;

        public ControleInventarioService(IControleInventarioRepository controleInventarioRepositoty)
            : base(controleInventarioRepositoty)
        {
            _controleInventarioRepositoty = controleInventarioRepositoty;
        }
    }
}

