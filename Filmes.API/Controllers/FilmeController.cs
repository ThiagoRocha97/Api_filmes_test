using Desafio.Domain.Commands.Inputs;
using Desafio.Domain.Handlers;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Query;
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
    public class FilmeController: ControllerBase
    {
        private readonly IFilmeRepository _repository;
        private readonly FilmeHandler _handler;

        public FilmeController(IFilmeRepository repository, FilmeHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/filmes")]
        public List<FilmeQueryResult> ListarFilmes()
        {
            return _repository.Listar();
        }

        [HttpGet]
        [Route("v1/filmes/{id}")]
        public FilmeQueryResult ObterFilmes(long id)
        {
            return _repository.Obter(id);
        }

        [HttpPost]
        [Route("v1/filmes")]
        public ICommandResult InserirFilme([FromBody] AdicionarFilmeCommand command)
        {
            var result = _handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/filmes/{id}")]
        public ICommandResult AlterarFilme(long id, [FromBody] AtualizarFilmeCommand command)
        {
            command.Id = id;
            var result = _handler.Handle(command);
            return result;
        }

        [HttpDelete]
        [Route("v1/filmes/{id}")]
        public ICommandResult ExcluirFilme(long id)
        {
            var command = new ApagarFilmeCommand() { Id = id };
            var result = _handler.Handle(command);
            return result;
        }
    }
}
