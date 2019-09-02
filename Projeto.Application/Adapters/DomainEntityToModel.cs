using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Projeto.Application.Models;
using Projeto.Domain.Entities;

namespace Projeto.Application.Adapters
{
    public class DomainEntityToModel : Profile
    {
        //construtor -> ctor + 2x[tab]
        public DomainEntityToModel()
        {
            CreateMap<Funcionario, FuncionarioConsultaModel>()
                .AfterMap((de, para) => para.IdFuncionario = de.IdFuncionario.ToString());

            CreateMap<Dependente, DependenteConsultaModel>()
                .AfterMap((de, para) => para.IdDependente = de.IdDependente.ToString())
                .AfterMap((de, para) => para.IdFuncionario = de.IdFuncionario.ToString());
        }
    }
}
