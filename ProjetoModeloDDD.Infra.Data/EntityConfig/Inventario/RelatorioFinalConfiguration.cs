using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Infra.Data;
using ProjetoModeloDDD.Domain.Entities.Inventario;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig.Inventario
{
    public class RelatorioFinalConfiguration : EntityTypeConfiguration<RelatorioFinal>
    {
        public RelatorioFinalConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.ControleInventarioId).IsOptional(); ;
            Property(c => c.Identificador).IsOptional(); ;
            Property(c => c.ProdutoImportacaoId).IsOptional(); ;
            Property(c => c.CodigoEan).IsOptional(); ;
            Property(c => c.NomeProduto).IsOptional(); ;
            Property(c => c.Qtde_Total_Invent).IsOptional(); ;
            Property(c => c.Qtde_Total_ERP).IsOptional(); ;
            Property(c => c.Diferenca).IsOptional(); 
            Property(c => c.Qtde_Total_Coletado).IsOptional();
            Property(c => c.Qtde_Produtos_Coletado).IsOptional();
            Property(c => c.PrecoUnitario).IsOptional();
            Property(c => c.PrecoVendaUnitario).IsOptional();
            Property(c => c.EmailUsuario).IsOptional();
        }
    }
}
