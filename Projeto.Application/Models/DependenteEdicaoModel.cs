using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations; //validações

namespace Projeto.Application.Models
{
    public class DependenteEdicaoModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string IdDependente { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string IdFuncionario { get; set; }
    }
}
