
using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities.Inventario;

namespace ProjetoModeloDDD.Domain.Interfaces.Services.Inventario
{
    public interface IItemControleInventarioService : IServiceBase<ItemControleInventario>
    {
        ItemControleInventario AdicionarColeta(ItemControleInventario itemControleInventario);
        ItemControleInventario ConsultarEAN(ItemControleInventario itemControleInventario);
        IEnumerable<ItemControleInventario> ConsultaItensInventario();
    }
}

