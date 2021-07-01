using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface.Acesso;
using ProjetoModeloDDD.Domain.Entities.Acesso;
using ProjetoModeloDDD.Domain.Interfaces.Services.Acesso;
using System.Linq;

namespace ProjetoModeloDDD.Application.Acesso
{
    public class PerfilUsuarioAppService : AppServiceBase<PerfilUsuario>, IPerfilUsuarioAppService
    {
        private readonly IPerfilUsuarioService _perfilUsuarioService;

        public PerfilUsuarioAppService(IPerfilUsuarioService perfilUsuarioService)
            :base(perfilUsuarioService)
        {
            _perfilUsuarioService = perfilUsuarioService;
        }

        public int ConsultaGrupo(string Email)
        {
            var perfilUsuarioService = _perfilUsuarioService.GetAll();

            // filtro
            if (!string.IsNullOrEmpty(Email))
            {
                perfilUsuarioService = perfilUsuarioService.Where
                        (
                            s => s.Email == Email
                        );
            }

            return perfilUsuarioService.First().GrupoId;
        }
    }
}

