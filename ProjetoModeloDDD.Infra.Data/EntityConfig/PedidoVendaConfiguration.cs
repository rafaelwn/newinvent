using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class PedidoVendaConfiguration : EntityTypeConfiguration<PedidoVenda>
    {
        public PedidoVendaConfiguration() 
        {
            HasKey(p => p.PedidoVendaId);

            Property(p => p.Data)
                .IsRequired();

            Property(p => p.Observacao)
                .HasMaxLength(250);

            HasRequired(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteId);
        }
    }
}
