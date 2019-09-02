using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;

namespace Projeto.Domain.Services
{
    public class FuncionarioDomainService
        : BaseDomainService<Funcionario>, IFuncionarioDomainService
    {
        //atributo
        private readonly IFuncionarioRepository repository;

        //construtor para injeção de dependência
        public FuncionarioDomainService(IFuncionarioRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }    
}
