using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioWebAPI_02.Domain.DTO;
using DesafioWebAPI_02.Domain.Entity;
using DesafioWebAPI_02.Services;


namespace DesafioWebAPI_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasControllers : ControllerBase
    {
        private readonly TarefasServices tarefasServices;

        public TarefasControllers(TarefasServices tarefasServices)
        {
            this.tarefasServices = tarefasServices;
        }

        [HttpGet]
        public IEnumerable<Tarefa> Get()

        {
            return tarefasServices.ListarTodos();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var retorno = tarefasServices.PesquisaPorId(id);

            if (retorno.Sucesso)
            {
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return NotFound(retorno.Mensagem);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] TarefasCreateRequests postModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = tarefasServices.CadastrarNovo(postModel);
                if (!retorno.Sucesso)
                {
                    return BadRequest(retorno.Mensagem);
                }
                else
                {
                    return Ok(retorno);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        [HttpPut("status/{id}")]
        public IActionResult PutConc(int id, [FromBody] StatusUpdateRequest putModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = tarefasServices.EditarConcluido(id, putModel);
                if (!retorno.Sucesso)
                    return BadRequest(retorno.Mensagem);
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        [HttpPut("prioridade/{id}")]
        public IActionResult PutPrior(int id, [FromBody] PrioridadeUpdateRequest putModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = tarefasServices.EditarPrioridade(id, putModel);
                if (!retorno.Sucesso)
                    return BadRequest(retorno.Mensagem);
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var retorno = tarefasServices.Deletar(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno.Mensagem);
            return Ok();
        }
    }
}