using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Infra.Data;
using ProjetoModeloDDD.Domain.Entities.Acesso;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig.Acesso
{
    public class PerfilUsuarioConfiguration : EntityTypeConfiguration<PerfilUsuario>
    {

        public PerfilUsuarioConfiguration()
        {
            HasKey(c => c.PerfilUsuarioId);

            HasRequired(c => c.Grupo)
                .WithMany()
                .HasForeignKey(c => c.GrupoId);

            Property(c => c.Email)
                .IsRequired()                
                .HasMaxLength(150)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Email_Unique", 1) { IsUnique = true }));
                
        }

    }
}
