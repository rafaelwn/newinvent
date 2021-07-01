using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class TipoPagamentoConfiguration : EntityTypeConfiguration<TipoPagamento>
    {
        public TipoPagamentoConfiguration()
        {
            HasKey(p => p.TipoPagamentoId);

            Property(p => p.Taxa)
                .IsRequired();

            Property(p => p.Descricao)
                .IsRequired();
        }
    }
}
