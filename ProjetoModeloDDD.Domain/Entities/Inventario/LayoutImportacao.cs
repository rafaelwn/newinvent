using System;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Entities.Inventario
{
    public class LayoutImportacao
    {
        public int LayoutImportacaoId { get; set; }
        public string NomeCampo { get; set; }
        public string Tamanho { get; set; }
        public string Tipo { get; set; }
        public string Observacao { get; set; }

    }
}
