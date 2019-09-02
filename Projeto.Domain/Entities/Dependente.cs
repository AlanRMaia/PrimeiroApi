using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Entities
{
    public class Dependente
    {
        public Guid IdDependente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid IdFuncionario { get; set; }

        #region Navegabilidades

        public Funcionario Funcionario { get; set; }

        #endregion
    }
}
