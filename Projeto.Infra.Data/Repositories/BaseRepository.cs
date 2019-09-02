using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Infra.Data.Context;
using Projeto.Domain.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Projeto.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        //atributo
        private readonly DataContext dataContext;

        //construtor para injeção de dependência
        protected BaseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public virtual void Insert(TEntity obj)
        {
            dataContext.Entry(obj).State = EntityState.Added;
            dataContext.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            dataContext.Entry(obj).State = EntityState.Modified;
            dataContext.SaveChanges();
        }

        public virtual void Delete(TEntity obj)
        {
            dataContext.Entry(obj).State = EntityState.Deleted;
            dataContext.SaveChanges();
        }

        public virtual List<TEntity> SelectAll()
        {
            return dataContext.Set<TEntity>().ToList();
        }

        public virtual List<TEntity> SelectAll(Func<TEntity, bool> where)
        {
            return dataContext.Set<TEntity>().Where(where).ToList();
        }

        public virtual TEntity SelectOne(Guid id)
        {
            return dataContext.Set<TEntity>().Find(id);
        }

        public virtual TEntity SelectOne(Func<TEntity, bool> where)
        {
            return dataContext.Set<TEntity>().SingleOrDefault(where);
        }

        public virtual int Count()
        {
            return dataContext.Set<TEntity>().Count();
        }

        public virtual int Count(Func<TEntity, bool> where)
        {
            return dataContext.Set<TEntity>().Count(where);
        }

        //destrutor
        public virtual void Dispose()
        {
            dataContext.Dispose();
        }
    }
}
