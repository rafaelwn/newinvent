using ProjetoModeloDDD.Application;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Domain.Services;

using ProjetoModeloDDD.Application.Inventario;
using ProjetoModeloDDD.Application.Interface.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Repositories.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Services.Inventario;
using ProjetoModeloDDD.Domain.Services.Inventario;

using ProjetoModeloDDD.Application.Acesso;
using ProjetoModeloDDD.Application.Interface.Acesso;
using ProjetoModeloDDD.Domain.Interfaces.Repositories.Acesso;
using ProjetoModeloDDD.Domain.Interfaces.Services.Acesso;
using ProjetoModeloDDD.Domain.Services.Acesso;

using ProjetoModeloDDD.Infra.Data.Repositories;
using ProjetoModeloDDD.Infra.Data.Repositories.Inventario;
using ProjetoModeloDDD.Infra.Data.Repositories.Acesso;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ProjetoModeloDDD.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ProjetoModeloDDD.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace ProjetoModeloDDD.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IClienteAppService>().To<ClienteAppService>();
            kernel.Bind<IProdutoAppService>().To<ProdutoAppService>();
            kernel.Bind<IMenuAppService>().To<MenuAppService>();
            kernel.Bind<IConfiguracaoAppService>().To<ConfiguracaoAppService>();
            kernel.Bind<ILayoutImportacaoAppService>().To<LayoutImportacaoAppService>();
            kernel.Bind<IProdutoImportacaoAppService>().To<ProdutoImportacaoAppService>();
            kernel.Bind<IGrupoAppService>().To<GrupoAppService>();
            kernel.Bind<IPerfilGrupoAppService>().To<PerfilGrupoAppService>();
            kernel.Bind<IPerfilUsuarioAppService>().To<PerfilUsuarioAppService>();
            kernel.Bind<IControleInventarioAppService>().To<ControleInventarioAppService>();
            kernel.Bind<IItemControleInventarioAppService>().To<ItemControleInventarioAppService>();

            kernel.Bind<IRelatorioFinalAppService>().To<RelatorioFinalAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IClienteService>().To<ClienteService>();
            kernel.Bind<IProdutoService>().To<ProdutoService>();
            kernel.Bind<IMenuService>().To<MenuService>();
            kernel.Bind<IConfiguracaoService>().To<ConfiguracaoService>();
            kernel.Bind<ILayoutImportacaoService>().To<LayoutImportacaoService>();
            kernel.Bind<IProdutoImportacaoService>().To<ProdutoImportacaoService>();
            kernel.Bind<IGrupoService>().To<GrupoService>();
            kernel.Bind<IPerfilGrupoService>().To<PerfilGrupoService>();
            kernel.Bind<IPerfilUsuarioService>().To<PerfilUsuarioService>();
            kernel.Bind<IControleInventarioService>().To<ControleInventarioService>();
            kernel.Bind<IItemControleInventarioService>().To<ItemControleInventarioService>();

            kernel.Bind<IRelatorioFinalService>().To<RelatorioFinalService>();
            
            

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();
            kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();
            kernel.Bind<IMenuRepository>().To<MenuRepository>();
            kernel.Bind<IConfiguracaoRepository>().To<ConfiguracaoRepository>();
            kernel.Bind<ILayoutImportacaoRepository>().To<LayoutImportacaoRepository>();
            kernel.Bind<IProdutoImportacaoRepository>().To<ProdutoImportacaoRepository>();
            kernel.Bind<IGrupoRepository>().To<GrupoRepository>();
            kernel.Bind<IPerfilGrupoRepository>().To<PerfilGrupoRepository>();
            kernel.Bind<IPerfilUsuarioRepository>().To<PerfilUsuarioRepository>();
            kernel.Bind<IControleInventarioRepository>().To<ControleInventarioRepository>();
            kernel.Bind<IItemControleInventarioRepository>().To<ItemControleInventarioRepository>();

            kernel.Bind<IRelatorioFinalRepository>().To<RelatorioFinalRepository>();
           
            

        }        
    }
}
