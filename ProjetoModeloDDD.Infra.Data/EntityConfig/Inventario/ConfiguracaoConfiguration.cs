using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Infra.Data;
using ProjetoModeloDDD.Domain.Entities.Inventario;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig.Inventario
{
    public class ConfiguracaoConfiguration : EntityTypeConfiguration<Configuracao>
    {
        public ConfiguracaoConfiguration()
        {
            HasKey(c => c.ConfiguracaoId);

            Property(c => c.CaminhoArquivoExportacao)
                .IsRequired()
                .IsMaxLength();

            Property(c => c.CaminhoArquivoImportacao)
                .IsRequired()
                .IsMaxLength();       

        }
    }
}
