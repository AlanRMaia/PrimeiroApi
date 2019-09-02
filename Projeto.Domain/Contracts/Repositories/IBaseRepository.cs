using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Projeto.Domain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable
        where TEntity : class
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);

        List<TEntity> SelectAll();
        List<TEntity> SelectAll(Func<TEntity, bool> where);

        TEntity SelectOne(Guid id);
        TEntity SelectOne(Func<TEntity, bool> where);

        int Count();
        int Count(Func<TEntity, bool> where);
    }
}

