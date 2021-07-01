using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class ItemPedidoVendaConfiguration : EntityTypeConfiguration<ItemPedidoVenda>
    {
        public ItemPedidoVendaConfiguration()
        {
            HasKey(p => p.ItemPedidoVendaId);

            HasRequired(p => p.PedidoVenda)
                .WithMany()
                .HasForeignKey(p => p.PedidoVendaId);

            HasRequired(p => p.Produto)
                .WithMany()
                .HasForeignKey(p => p.ProdutoId);

            Property(p => p.Quantidade)
                .IsRequired();

            Property(p => p.Valor)
                .IsRequired();
        }
    }
}
