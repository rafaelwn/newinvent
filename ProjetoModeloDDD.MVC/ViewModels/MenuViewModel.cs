using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class MenuViewModel
    {
        [Key]
        public int MenuId { get; set; }


        public int MenuId_Pai { get; set; }
        public int MenuId_Filho { get; set; }


        [Required(ErrorMessage = "Preencha o campo Titulo")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo {0} caracteres")]
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Caminho da Imagem")]
        public string CaminhoImagem { get; set; }

        public string Link { get; set; }

        public bool Situacao { get; set; }
    }
}