
using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Repositories.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Services.Inventario;
using System.IO;
using System;

namespace ProjetoModeloDDD.Domain.Services.Inventario
{
    public class RelatorioFinalService : ServiceBase<RelatorioFinal>, IRelatorioFinalService
    {
        private readonly IRelatorioFinalRepository _relatorioFinalRepository;

        public RelatorioFinalService(IRelatorioFinalRepository relatorioFinalRepository)
            : base(relatorioFinalRepository)
        {
            _relatorioFinalRepository = relatorioFinalRepository;
        }   
    }
}
