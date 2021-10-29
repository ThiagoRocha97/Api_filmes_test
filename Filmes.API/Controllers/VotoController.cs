using Desafio.Domain.Votacao.Commands.Inputs;
using Desafio.Domain.Votacao.Handlers;
using Desafio.Domain.Votacao.Interfaces.Repositories;
using Desafio.Domain.Votacao.Query;
using Desafio.Infra.Interfaces.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    public class VotoController: ControllerBase
    {
        private readonly IVotoRepository _repository;
        private readonly VotoHandler _handler;
        public VotoController(IVotoRepository repository, VotoHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/voto")]
        public List<VotoQueryResult> ListarVotos()
        {
            return _repository.ListarVoto();
        }

        [HttpGet]
        [Route("v1/voto/{id}")]
        public VotoQueryResult ObterVoto(long id)
        {
            return _repository.ObterVoto(id);
        }

        [HttpPost]
        [Route("v1/voto")]
        public ICommandResult InserirFilme([FromBody] AdicionarVotoCommand command)
        {
            var result = _handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/voto/{id}")]
        public ICommandResult AtualizarVoto(long id, [FromBody] AtualizarVotoCommand command)
        {
            command.Id = id;
            var result = _handler.Handle(command);
            return result;
        }

        [HttpDelete]
        [Route("v1/voto/{id}")]
        public ICommandResult ExcluirVoto(long id)
        {
            var command = new ApagarVotoCommand() { Id = id };
            var result = _handler.Handle(command);
            return result;
        }
    }
}
