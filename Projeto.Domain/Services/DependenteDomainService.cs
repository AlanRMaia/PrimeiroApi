using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;

namespace Projeto.Domain.Services
{
    public class DependenteDomainService
        : BaseDomainService<Dependente>, IDependenteDomainService
    {
        //atributo
        private readonly IDependenteRepository repository;

        //construtor para injeção de dependência
        public DependenteDomainService(IDependenteRepository repository)
            : base(repository) //chamada ao construtor da superclasse
        {
            this.repository = repository;
        }
    }
}
