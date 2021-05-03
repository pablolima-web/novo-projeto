using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ProdutoViewModel, Produto>();
        }

        public override string ProfileName
        {
            get { return "ViewModelToDomainMapping"; }
        }

        //antigo
        //protected override void Configure()
        //{
        //    // Mapper.CreateMap<ProdutoViewModel, Produto>();
        //}
    }
}