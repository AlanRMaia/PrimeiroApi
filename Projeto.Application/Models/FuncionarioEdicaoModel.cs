using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Application.Models
{
    public class FuncionarioEdicaoModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string IdFuncionario { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DataAdmissao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal Salario { get; set; }
    }
}
