using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Application.Models;

namespace Projeto.Application.Contracts
{
    public interface IDependenteApplicationService : IDisposable
    {
        void Cadastrar(DependenteCadastroModel model);
        void Atualizar(DependenteEdicaoModel model);
        void Excluir(string id);

        List<DependenteConsultaModel> ConsultarTodos();
        DependenteConsultaModel ConsultarPorId(string id);
    }
}
