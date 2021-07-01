using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Infra.Data;
using ProjetoModeloDDD.Domain.Entities.Inventario;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig.Inventario
{
    public class LayoutImportacaoConfiguration : EntityTypeConfiguration<LayoutImportacao>
    {
        public LayoutImportacaoConfiguration()
        {
            HasKey(c => c.LayoutImportacaoId);

            Property(c => c.NomeCampo)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.Tamanho)
                .IsRequired();

            Property(c => c.Tipo)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
