using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Entities.Acesso
{
    public class PerfilUsuario
    {
        public int PerfilUsuarioId { get; set; }
        public string Email { get; set; }
        public int GrupoId { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}
