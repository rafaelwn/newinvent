using ProjetoModeloDDD.Domain.Interfaces.Services.Acesso;
using ProjetoModeloDDD.Domain.Interfaces.Repositories.Acesso;
using ProjetoModeloDDD.Domain.Entities.Acesso;


namespace ProjetoModeloDDD.Domain.Services.Acesso
{
    public class PerfilGrupoService : ServiceBase<PerfilGrupo>, IPerfilGrupoService
    {
        private readonly IPerfilGrupoRepository _perfilGrupoRepository;

        public PerfilGrupoService(IPerfilGrupoRepository perfilGrupoRepository)
            : base(perfilGrupoRepository)
        {
            _perfilGrupoRepository = perfilGrupoRepository;
        }
    }
}