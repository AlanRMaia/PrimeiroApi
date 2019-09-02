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
    public class DependenteController : ControllerBase
    {
        //atributo (SOLID / DIP -> Principio de inversão de dependência)
        private readonly IDependenteApplicationService dependenteApplication;

        //construtor para fazer funcionar a 'injeção de dependência'
        public DependenteController(IDependenteApplicationService dependenteApplication)
        {
            this.dependenteApplication = dependenteApplication;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(500, Type = typeof(string))]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] DependenteCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    dependenteApplication.Cadastrar(model);
                    return Ok($"Dependente {model.Nome}, cadastrado com sucesso.");
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

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(500, Type = typeof(string))]
        [ProducesResponseType(400)]
        public IActionResult Put([FromBody] DependenteEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    dependenteApplication.Atualizar(model);
                    return Ok($"Dependente {model.Nome}, atualizado com sucesso.");
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
                dependenteApplication.Excluir(id);
                return Ok("Dependente excluído com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<DependenteConsultaModel>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public IActionResult Get()
        {
            try
            {
                var result = dependenteApplication.ConsultarTodos();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(DependenteConsultaModel))]
        [ProducesResponseType(500, Type = typeof(string))]
        public IActionResult Get(string id)
        {
            try
            {
                var result = dependenteApplication.ConsultarPorId(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}