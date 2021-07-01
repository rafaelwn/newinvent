
using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities.Inventario;


namespace ProjetoModeloDDD.Application.Interface.Inventario
{
    public interface IItemControleInventarioAppService : IAppServiceBase<ItemControleInventario>
    {
        ItemControleInventario AdicionarColeta(ItemControleInventario itemControleInventario);
        ItemControleInventario ConsultarEAN(ItemControleInventario itemControleInventario);
        IEnumerable<ItemControleInventario> ConsultaItensInventario();
    }
}
