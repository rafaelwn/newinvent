
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjetoModeloDDD.Domain.Entities.Acesso;

namespace ProjetoModeloDDD.MVC.ViewModels.Acesso
{
    public class PerfilUsuarioViewModel
    {
        [Key]
        public int PerfilUsuarioId { get; set; }
        [Required(ErrorMessage = "Informe um e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe um Grupo")]        
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }
    }
}