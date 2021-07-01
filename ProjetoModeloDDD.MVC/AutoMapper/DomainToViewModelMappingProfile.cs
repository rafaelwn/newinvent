using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.Domain.Entities.Acesso;
using ProjetoModeloDDD.MVC.ViewModels;
using ProjetoModeloDDD.MVC.ViewModels.Inventario;
using ProjetoModeloDDD.MVC.ViewModels.Acesso;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings"; 
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<ProdutoViewModel, Produto>();

            Mapper.CreateMap<MenuViewModel, Menu>();
            Mapper.CreateMap<ConfiguracaoViewModel, Configuracao>();
            Mapper.CreateMap<ProdutoImportacaoViewModel, ProdutoImportacao>();

            Mapper.CreateMap<PerfilUsuarioViewModel, PerfilUsuario>();
            Mapper.CreateMap<ControleInventarioViewModel, ControleInventario>();
            Mapper.CreateMap<ItemControleInventarioViewModel, ItemControleInventario>();

            Mapper.CreateMap<RelatorioFinalViewModel, RelatorioFinal>();

        }
    }
}