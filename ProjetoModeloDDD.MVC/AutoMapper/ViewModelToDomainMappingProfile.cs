﻿using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
        }

        public override string ProfileName
        {
            get { return "DomainToViewModelMapping"; }
        }

        //antigo
        //protected override void Configure()
        //{
        //    //Mapper.CreateMap<Cliente, ClienteViewModel>();
        //    //Mapper.CreateMap<Produto, ProdutoViewModel>();
        //}
    }
}