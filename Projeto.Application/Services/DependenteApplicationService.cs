using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using AutoMapper;

namespace Projeto.Application.Services
{
    public class DependenteApplicationService : IDependenteApplicationService        
    {
        //atributo
        private readonly IDependenteDomainService domainService;

        //construtor para injeção de dependência
        public DependenteApplicationService(IDependenteDomainService domainService)
        {
            this.domainService = domainService;
        }

        public void Cadastrar(DependenteCadastroModel model)
        {
            var dependente = Mapper.Map<Dependente>(model);
            domainService.Cadastrar(dependente);
        }

        public void Atualizar(DependenteEdicaoModel model)
        {
            var dependente = Mapper.Map<Dependente>(model);
            domainService.Atualizar(dependente);
        }

        public void Excluir(string id)
        {
            var dependente = domainService.ConsultarPorId(Guid.Parse(id));
            domainService.Excluir(dependente);
        }

        public List<DependenteConsultaModel> ConsultarTodos()
        {
            var dependentes = domainService.ConsultarTodos();
            return Mapper.Map<List<DependenteConsultaModel>>(dependentes);
        }

        public DependenteConsultaModel ConsultarPorId(string id)
        {
            var dependente = domainService.ConsultarPorId(Guid.Parse(id));
            return Mapper.Map<DependenteConsultaModel>(dependente);
        }

        public void Dispose()
        {
            domainService.Dispose();
        }
    }
}
