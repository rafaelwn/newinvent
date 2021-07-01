
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels.Inventario
{
    public class ConfiguracaoViewModel
    {
        [Key]
        public int ConfiguracaoId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Caminho Arquivo Importacao")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string CaminhoArquivoImportacao { get; set; }
        [Required(ErrorMessage = "Preencha o campo Caminho Arquivo Exportacao")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string CaminhoArquivoExportacao { get; set; }
    }
}