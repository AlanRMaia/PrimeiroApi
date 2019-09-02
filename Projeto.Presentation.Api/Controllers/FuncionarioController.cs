using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        //atributo (SOLID / DIP -> Principio de inversão de dependência)
        private readonly IFuncionarioApplicationService funcionarioApplication;

        //construtor para fazer funcionar a 'injeção de dependência'
        public FuncionarioController(IFuncionarioApplicationService funcionarioApplication)
        {
            this.funcionarioApplication = funcionarioApplication;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(500, Type = typeof(string))]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] FuncionarioCadastroModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    funcionarioApplication.Cadastrar(model);
                    return Ok($"Funcionário {model.Nome}, cadastrado com sucesso.");
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(500, Type = typeof(string))]
        [ProducesResponseType(400)]
        public IActionResult Put([FromBody] FuncionarioEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    funcionarioApplication.Atualizar(model);
                    return Ok($"Funcionário {model.Nome}, atualizado com sucesso.");
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(500, Type = typeof(string))]
        public IActionResult Delete(string id)
        {
            try
            {
                funcionarioApplication.Excluir(id);
                return Ok("Funcionário excluído com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<FuncionarioConsultaModel>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public IActionResult Get()
        {
            try
            {
                var result = funcionarioApplication.ConsultarTodos();
                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(FuncionarioConsultaModel))]
        [ProducesResponseType(500, Type = typeof(string))]
        public IActionResult Get(string id)
        {
            try
            {
                var result = funcionarioApplication.ConsultarPorId(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}