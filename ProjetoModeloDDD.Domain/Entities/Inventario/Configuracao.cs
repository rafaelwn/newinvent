using System;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Entities.Inventario
{
    public class Configuracao
    {
        public int ConfiguracaoId { get; set; }
        public string CaminhoArquivoImportacao { get; set; }
        public string CaminhoArquivoExportacao { get; set; }
    }
}
