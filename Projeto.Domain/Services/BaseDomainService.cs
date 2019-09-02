using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;

namespace Projeto.Domain.Services
{
    public abstract class BaseDomainService<TEntity> 
        : IBaseDomainService<TEntity>
        where TEntity : class
    {
        //atributo
        private readonly IBaseRepository<TEntity> repository;

        //construtor para injeção de dependência
        protected BaseDomainService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual void Cadastrar(TEntity obj)
        {
            repository.Insert(obj);
        }

        public virtual void Atualizar(TEntity obj)
        {
            repository.Update(obj);
        }

        public virtual void Excluir(TEntity obj)
        {
            repository.Delete(obj);
        }

        public virtual List<TEntity> ConsultarTodos()
        {
            return repository.SelectAll();
        }

        public virtual TEntity ConsultarPorId(Guid id)
        {
            return repository.SelectOne(id);
        }

        public virtual void Dispose()
        {
            repository.Dispose();
        }
    }
}
