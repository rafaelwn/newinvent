using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Infra.Data;
using ProjetoModeloDDD.Domain.Entities.Inventario;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig.Inventario
{
    public class ControleInventarioConfiguration : EntityTypeConfiguration<ControleInventario>
    {
        public ControleInventarioConfiguration()
        {
            HasKey(c => c.ControleInventarioId);

            Property(c => c.Descricao)
                .HasMaxLength(150)
                .IsOptional();

            Property(c => c.DataInicio).IsOptional();            
            Property(c => c.DataFim).IsOptional();

            Property(c => c.UsuarioEmail)
                .HasMaxLength(150)
                .IsOptional();

            Property(c => c.CodigoLoja)
                .HasMaxLength(20)
                .IsOptional();

            Property(c => c.NumeroLoja).IsOptional();
            Property(c => c.Contagem).IsOptional();
            Property(c => c.FaixaIdentificadorInicial).IsOptional();
            Property(c => c.FaixaIdentificadorFianl).IsOptional();

            Property(c => c.Observacoes)
                .HasMaxLength(250)
                .IsOptional();            
        }
    }
}
