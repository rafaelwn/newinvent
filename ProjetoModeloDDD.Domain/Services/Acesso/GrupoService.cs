using ProjetoModeloDDD.Domain.Interfaces.Repositories.Acesso;
using ProjetoModeloDDD.Domain.Entities.Acesso;
using ProjetoModeloDDD.Domain.Interfaces.Services.Acesso;

namespace ProjetoModeloDDD.Domain.Services.Acesso
{
    public class GrupoService : ServiceBase<Grupo>, IGrupoService
    {
        private readonly IGrupoRepository _grupoRepository;

        public GrupoService(IGrupoRepository grupoRepository)
            : base(grupoRepository)
        {
            _grupoRepository = grupoRepository;
        }
    }
}
