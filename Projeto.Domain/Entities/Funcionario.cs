using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Entities
{
    public class Funcionario
    {
        public Guid IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataAdmissao { get; set; }

        #region Navegabilidades

        public ICollection<Dependente> Dependentes { get; set; }

        #endregion
    }
}
