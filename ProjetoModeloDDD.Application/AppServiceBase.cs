
using System;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {

        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);

        }

        public TEntity GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public System.Collections.Generic.IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }


        public System.Collections.Generic.IEnumerable<TEntity> QuerySQLEntity(string query)
        {
            return _serviceBase.QuerySQLEntity(query);
        }

        public System.Collections.Generic.IEnumerable<TEntity> QuerySQL(string query, object[] Parametros)
        {
            return _serviceBase.QuerySQL(query, Parametros);
        }
    }
}
