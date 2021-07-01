using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.MVC.ViewModels.Inventario;
using ProjetoModeloDDD.Domain.Entities.Acesso;
using ProjetoModeloDDD.MVC.ViewModels.Acesso;
namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<Produto, ProdutoViewModel>();

            Mapper.CreateMap<Menu, MenuViewModel>();
            Mapper.CreateMap<Configuracao, ConfiguracaoViewModel>();
            Mapper.CreateMap<ProdutoImportacao, ProdutoImportacaoViewModel>();

            Mapper.CreateMap<PerfilUsuario, PerfilUsuarioViewModel>();
            Mapper.CreateMap<ControleInventario, ControleInventarioViewModel>();
            Mapper.CreateMap<ItemControleInventario, ItemControleInventarioViewModel>();

            Mapper.CreateMap<RelatorioFinal, RelatorioFinalViewModel>();
        }
    }
}