using ProjetoModeloDDD.Application.Interface;
using System;
using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {

        private readonly IServiceBase<TEntity> _serviceBase;
        //private IClienteService clienteService;
        //private IProdutoService produtoService;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }
       
        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _serviceBase.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public TEntity GetById(int id)
        {
            return  _serviceBase.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

    }
}
