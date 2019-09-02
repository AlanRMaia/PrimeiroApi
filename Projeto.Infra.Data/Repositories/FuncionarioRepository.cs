using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Projeto.Infra.Data.Repositories
{
    public class FuncionarioRepository
        : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        private readonly DataContext dataContext;

        public FuncionarioRepository(DataContext dataContext)
            : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public override List<Funcionario> SelectAll()
        {
            return dataContext.Funcionario.Include(f => f.Dependentes).ToList();
        }

        public override List<Funcionario> SelectAll(Func<Funcionario, bool> where)
        {
            return dataContext.Funcionario.Include(f => f.Dependentes).Where(where).ToList();
        }

        public override Funcionario SelectOne(Guid id)
        {
            return dataContext.Funcionario.Include(f => f.Dependentes)
                .SingleOrDefault(f => f.IdFuncionario.Equals(id));
        }

        public override Funcionario SelectOne(Func<Funcionario, bool> where)
        {
            return dataContext.Funcionario.Include(f => f.Dependentes)
                .SingleOrDefault(where);
        }
    }
}
