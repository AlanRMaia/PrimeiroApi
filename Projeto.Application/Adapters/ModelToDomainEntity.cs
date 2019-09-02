using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Projeto.Application.Models;
using Projeto.Domain.Entities;

namespace Projeto.Application.Adapters
{
    public class ModelToDomainEntity : Profile
    {
        //construtor -> ctor + 2x[tab]
        public ModelToDomainEntity()
        {
            CreateMap<FuncionarioCadastroModel, Funcionario>()
                .AfterMap((de, para) => para.IdFuncionario = Guid.NewGuid());

            CreateMap<FuncionarioEdicaoModel, Funcionario>()
                .AfterMap((de, para) => para.IdFuncionario = Guid.Parse(de.IdFuncionario));

            CreateMap<DependenteCadastroModel, Dependente>()
                .AfterMap((de, para) => para.IdDependente = Guid.NewGuid())
                .AfterMap((de, para) => para.IdFuncionario = Guid.Parse(de.IdFuncionario));

            CreateMap<DependenteEdicaoModel, Dependente>()
                .AfterMap((de, para) => para.IdDependente = Guid.Parse(de.IdDependente))
                .AfterMap((de, para) => para.IdFuncionario = Guid.Parse(de.IdFuncionario));
        }
    }
}
