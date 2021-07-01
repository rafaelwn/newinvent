using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Entities.Acesso
{
    public class PerfilGrupo
    {
        public int PerfilGrupoId { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public bool List { get; set; }
        public bool Create { get; set; }
        public bool Delete { get; set; }
        public bool Edit { get; set; }
        public bool Details { get; set; }
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }
    }
}
