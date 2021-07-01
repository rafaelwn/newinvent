
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.Domain.Entities.Acesso;
using ProjetoModeloDDD.Infra.Data.EntityConfig.Inventario;
using ProjetoModeloDDD.Infra.Data.EntityConfig.Acesso;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using System.Linq;



using System;
using ProjetoModeloDDD.Infra.Data.EntityConfig;

namespace ProjetoModeloDDD.Infra.Data.Contexto
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<PedidoVenda> PedidosVenda { get; set; }
        public DbSet<ItemPedidoVenda> ItensPedidoVenda { get; set; }
        public DbSet<TipoPagamento> TiposPagamento { get; set; }
        public DbSet<TipoPagamentoPedidoVenda> TiposPagamentoPedidosVenda { get; set; }

        public DbSet<Configuracao> Configuracoes { get; set; }
        public DbSet<LayoutImportacao> LayoutsImportacao { get; set; }
        public DbSet<ProdutoImportacao> ProdutosImportacao { get; set; }
        public DbSet<ControleInventario> ControleInventarios { get; set; }
        public DbSet<ItemControleInventario> ItensControleInventario { get; set; }

        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<PerfilGrupo> PerfilGrupos { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuarios { get; set; }

        public DbSet<RelatorioFinal> RelatoriosFinal { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            /*
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));
            */

            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());

            modelBuilder.Configurations.Add(new ConfiguracaoConfiguration());
            modelBuilder.Configurations.Add(new LayoutImportacaoConfiguration());
            modelBuilder.Configurations.Add(new ProdutoImportacaoConfiguration());
            modelBuilder.Configurations.Add(new ControleInventarioConfiguration());
            modelBuilder.Configurations.Add(new ItemControleInventarioConfiguration());

            modelBuilder.Configurations.Add(new GrupoConfiguration());
            modelBuilder.Configurations.Add(new PerfilGrupoConfiguration());
            modelBuilder.Configurations.Add(new PerfilUsuarioConfiguration());
            modelBuilder.Configurations.Add(new RelatorioFinalConfiguration());
        }

        public override int SaveChanges()
        {

            foreach(var entry in ChangeTracker.Entries()               
                .Where(x => x.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
	            {
		             entry.Property("DataCadastro").IsModified = false;
	            }
            }

            return base.SaveChanges();

        }
    }
}
