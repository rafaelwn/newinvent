using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Infra.Data;
using ProjetoModeloDDD.Domain.Entities.Acesso;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig.Acesso
{
    public class GrupoConfiguration : EntityTypeConfiguration<Grupo>
    {

        public GrupoConfiguration()
        {
            HasKey(c => c.GrupoId);

            Property(c => c.Nome)
                .HasMaxLength(50)
                .IsRequired();
        }

    }
}