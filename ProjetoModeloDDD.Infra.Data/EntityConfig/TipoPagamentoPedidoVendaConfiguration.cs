using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class TipoPagamentoPedidoVendaConfiguration : EntityTypeConfiguration<TipoPagamentoPedidoVenda>
    {
        public TipoPagamentoPedidoVendaConfiguration()
        {
            HasKey(p => p.TipoPagamentoPedidoVendaId);

            HasRequired(p => p.TipoPagamento)
                .WithMany()
                .HasForeignKey(p => p.TipoPagamentoId);

            HasRequired(p => p.PedidoVenda)
                .WithMany()
                .HasForeignKey(p => p.PedidoVendaId);

            Property(p => p.Valor)
                .IsRequired();
        }
        
    }
}
