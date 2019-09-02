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
    public class FuncionarioApplicationService : IFuncionarioApplicationService
    {
        //atributo
        private readonly IFuncionarioDomainService domainService;

        //construtor para injeção de dependência
        public FuncionarioApplicationService(IFuncionarioDomainService domainService)
        {
            this.domainService = domainService;
        }

        public void Cadastrar(FuncionarioCadastroModel model)
        {
            var funcionario = Mapper.Map<Funcionario>(model);
            domainService.Cadastrar(funcionario);
        }

        public void Atualizar(FuncionarioEdicaoModel model)
        {
            var funcionario = Mapper.Map<Funcionario>(model);
            domainService.Atualizar(funcionario);
        }

        public void Excluir(string id)
        {
            var funcionario = domainService.ConsultarPorId(Guid.Parse(id));
            domainService.Excluir(funcionario);
        }

        public List<FuncionarioConsultaModel> ConsultarTodos()
        {
            var funcionarios = domainService.ConsultarTodos();
            return Mapper.Map<List<FuncionarioConsultaModel>>(funcionarios);
        }

        public FuncionarioConsultaModel ConsultarPorId(string id)
        {
            var funcionario = domainService.ConsultarPorId(Guid.Parse(id));
            return Mapper.Map<FuncionarioConsultaModel>(funcionario);
        }

        public void Dispose()
        {
            domainService.Dispose();
        }
    }
}
