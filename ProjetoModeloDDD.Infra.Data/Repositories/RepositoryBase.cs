
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Infra.Data.Contexto;
using System.Data.Linq;
using System.Data.SqlClient;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity :  class 
    {
        protected ProjetoModeloContext Db = new ProjetoModeloContext();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void RemoveAll()
        {
            Db.Set<TEntity>().RemoveRange(Db.Set<TEntity>().ToList());
            Db.SaveChanges();
        }

        void IRepositoryBase<TEntity>.Dispose()
        {
            Db.Dispose();
        }

        void IDisposable.Dispose()
        {
            Db.Dispose();
        }

        public IEnumerable<TEntity> QuerySQLEntity(string query)
        {            
            DataContext dtc = new DataContext(Db.Database.Connection.ConnectionString);            
            return dtc.ExecuteQuery<TEntity>(@query);
        }

        public IEnumerable<TEntity> QuerySQL(string query, object[] Parametros)
        {
            query = string.Format(query, Parametros);

            return Db.Database.SqlQuery<TEntity>(query);
        }

        public string StringConexao()
        {
            return Db.Database.Connection.ConnectionString.ToString();
        }

        public void ExecuteSqlCommand(string query)
        {
            Db.Database.ExecuteSqlCommand(query);
        }
    }
}
