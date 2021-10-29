using Desafio.Infra.Interfaces.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Desafio.Domain.Commands.Inputs;
using Desafio.Domain.Handlers;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Query;
using Microsoft.AspNetCore.Authorization;

namespace Desafio.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]    
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly UsuarioHandler _handler;

        public UsuarioController(IUsuarioRepository repository, UsuarioHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/usuario")]
        public List<UsuarioQueryResult> ListarUsuarios()
        {
            return _repository.Listar();
        }

        [HttpGet]
        [Route("v1/usuario/{id}")]
        public UsuarioQueryResult ObterUsuario(long id)
        {
            return _repository.Obter(id);
        }

        [HttpPost]
        [Route("v1/usuario")]
        public ICommandResult InserirUsuario([FromBody] AdicionarUsuarioCommand command)
        {
            var result = _handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/usuario/{id}")]
        public ICommandResult AlterarUsuario(long id, [FromBody] AtualizarUsuarioCommand command)
        {
            command.Id = id;
            var result = _handler.Handle(command);
            return result;
        }

        [HttpDelete]
        [Route("v1/usuario/{id}")]
        public ICommandResult ExcluirUsuario(long id)
        {
            var command = new ApagarUsuarioCommand() { Id = id };
            var result = _handler.Handle(command);
            return result;
        }
    }
}
