
using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface.Acesso;
using ProjetoModeloDDD.Domain.Entities.Acesso;
using ProjetoModeloDDD.Domain.Interfaces.Services.Acesso;
using System.Linq;

namespace ProjetoModeloDDD.Application.Acesso
{
    public class PerfilGrupoAppService : AppServiceBase<PerfilGrupo>, IPerfilGrupoAppService
    {
        private readonly IPerfilGrupoService _perfilGrupoService;
        private readonly IPerfilUsuarioAppService _perfilUsuarioAppService;

        public PerfilGrupoAppService(IPerfilGrupoService perfilGrupoService, IPerfilUsuarioAppService perfilUsuarioAppService)
            :base(perfilGrupoService)
        {
            _perfilGrupoService = perfilGrupoService;
            _perfilUsuarioAppService = perfilUsuarioAppService;
        }

        public List<int> ConsultaPerfilGrupo(string Email)
        {            
            int GrupoId = _perfilUsuarioAppService.ConsultaGrupo(Email);

            var perfilGrupoService = _perfilGrupoService.GetAll();    

            // filtro PerfilGrupo
            if (GrupoId > 0)
            {
                perfilGrupoService = perfilGrupoService.Where
                        (
                            s => s.GrupoId == GrupoId
                        );
            }            

            var itemIds = perfilGrupoService.Select(x => x.MenuId).ToArray();

            return itemIds.ToList();
        }

    }
}

