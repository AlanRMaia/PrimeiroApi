using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Application.Models;

namespace Projeto.Application.Contracts
{
    public interface IFuncionarioApplicationService : IDisposable
    {
        void Cadastrar(FuncionarioCadastroModel model);
        void Atualizar(FuncionarioEdicaoModel model);
        void Excluir(string id);

        List<FuncionarioConsultaModel> ConsultarTodos();
        FuncionarioConsultaModel ConsultarPorId(string id);
    }
}
