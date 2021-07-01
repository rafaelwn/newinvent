using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities.Acesso;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig.Acesso
{
    public class PerfilGrupoConfiguration : EntityTypeConfiguration<PerfilGrupo>
    {

        public PerfilGrupoConfiguration()
        {
            HasKey(c => c.PerfilGrupoId);                

            Property(c => c.MenuId)
                .IsRequired();

            HasRequired(c => c.Menu)
                .WithMany()                
                .HasForeignKey(c => c.MenuId);

            HasRequired(c => c.Grupo)
                .WithMany()
                .HasForeignKey(c => c.GrupoId);

            Property(c => c.List).IsOptional();
            Property(c => c.Create).IsOptional();
            Property(c => c.Delete).IsOptional();
            Property(c => c.Edit).IsOptional();
            Property(c => c.Details).IsOptional();
        }

    }
}
