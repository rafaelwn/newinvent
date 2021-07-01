using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Entities.Acesso
{
    public class Grupo
    {
        public int GrupoId { get; set; }
        public string Nome { get; set; }
        public IEnumerable<PerfilGrupo> PerfilGrupo { get; set; }
    }
}
