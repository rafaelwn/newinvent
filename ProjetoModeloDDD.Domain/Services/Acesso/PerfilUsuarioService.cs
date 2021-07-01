using ProjetoModeloDDD.Domain.Entities.Acesso;
using System.Collections.Generic;

using ProjetoModeloDDD.Domain.Interfaces.Repositories.Acesso;
using ProjetoModeloDDD.Domain.Interfaces.Services.Acesso;

namespace ProjetoModeloDDD.Domain.Services.Acesso
{
    public class PerfilUsuarioService : ServiceBase<PerfilUsuario>, IPerfilUsuarioService
    {
        private readonly IPerfilUsuarioRepository _perfilUsuarioRepository;

        public PerfilUsuarioService(IPerfilUsuarioRepository perfilUsuarioRepository)
            : base(perfilUsuarioRepository)
        {
            _perfilUsuarioRepository = perfilUsuarioRepository;
        }

    }
}