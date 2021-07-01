using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Infra.Data;
using ProjetoModeloDDD.Domain.Entities.Inventario;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig.Inventario
{
    public class ProdutoImportacaoConfiguration : EntityTypeConfiguration<ProdutoImportacao>
    {
        public ProdutoImportacaoConfiguration()
        {
            HasKey(c => c.ProdutoImportacaoId);

            Property(c => c.NumeroLoja).IsOptional();
            Property(c => c.Data).IsOptional();
            Property(c => c.CodigoEan).IsOptional();
            Property(c => c.NomeProduto).IsOptional();

            Property(c => c.PrecoUnitario)
                .IsOptional()
                .HasPrecision(7, 2);
            Property(c => c.PrecoVendaUnitario)
                .IsOptional()
                .HasPrecision(7, 2);
            Property(c => c.Quantidade)
                .IsOptional()
                .HasPrecision(11, 4);
            

            Property(c => c.DepartamentoId).IsOptional();
            Property(c => c.NomeDepartamento).IsOptional();
            Property(c => c.SecaoId).IsOptional();
            Property(c => c.NomeSecao).IsOptional();
            Property(c => c.GrupoId).IsOptional();
            Property(c => c.NomeGrupo).IsOptional();
            Property(c => c.SubGrupoId).IsOptional();
            Property(c => c.NomeSubGrupo).IsOptional();

            Property(c => c.Identificador).IsOptional();
        }
    }
}
