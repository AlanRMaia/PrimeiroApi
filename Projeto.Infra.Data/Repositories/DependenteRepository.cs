using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Context;

namespace Projeto.Infra.Data.Repositories
{
    public class DependenteRepository 
        : BaseRepository<Dependente>, IDependenteRepository
    {
        //atributo
        private readonly DataContext dataContext;

        //construtor para injeção de dependência
        public DependenteRepository(DataContext dataContext)
            : base(dataContext) //construtor da superclasse
        {
            this.dataContext = dataContext;
        }
    }
}
