
using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Infra.Data;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class MenuConfiguration : EntityTypeConfiguration<Menu>
    {
        public MenuConfiguration()
        {
            HasKey(c => c.MenuId);

            Property(c => c.Titulo)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.CaminhoImagem)
                .IsRequired();

                
        }
    }
}
