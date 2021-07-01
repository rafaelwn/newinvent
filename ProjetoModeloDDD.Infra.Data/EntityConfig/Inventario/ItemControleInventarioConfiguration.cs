using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities.Inventario;


namespace ProjetoModeloDDD.Infra.Data.EntityConfig.Inventario
{
    public class ItemControleInventarioConfiguration : EntityTypeConfiguration<ItemControleInventario>
    {
        public ItemControleInventarioConfiguration ()
	    {
            HasKey(c => c.ItemControleInventarioId);

            Property(c => c.DepartamentoId).IsOptional();
            Property(c => c.SecaoId).IsOptional();
            Property(c => c.GrupoId).IsOptional();
            Property(c => c.SubGrupoId).IsOptional();
            Property(c => c.Contagem).IsOptional();
            Property(c => c.Status).IsOptional();

            HasRequired(c => c.ControleInventario)
                .WithMany()
                .HasForeignKey(c => c.ControleInventarioId);
        
            HasRequired(c => c.ProdutoImportacao)
                .WithMany()
                .HasForeignKey(c => c.ProdutoImportacaoId);

            Property(c => c.EmailUsuario).IsOptional();
            
            Property(c => c.IdentificadorInicial).IsOptional();
            Property(c => c.IdentificadorFinal).IsOptional();

            Property(c => c.QuantidadeInicial)
                .IsOptional()
                .HasPrecision(8, 3);

            Property(c => c.QuantidadeFinal)
                .IsOptional()
                .HasPrecision(8, 3);

            Property(c => c.CodigoEan).IsOptional();

            Property(c => c.Quantidade)
                .IsOptional()
                .HasPrecision(8, 3);

            Property(c => c.QuantidadeImp)
                .IsOptional()
                .HasPrecision(8, 3);

            Property(c => c.NomeProdutoImp)
                .IsOptional();

            Property(c => c.Identificador).IsOptional();

	    }

    }
}
