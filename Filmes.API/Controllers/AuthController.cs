using Desafio.Domain.Usuarios.Commands.Inputs;
using Desafio.Domain.Usuarios.Handlers;
using Desafio.Infra.Interfaces.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
       
        private readonly AuthHandler _handler;
        public AuthController(AuthHandler handler)
        {
            
            _handler = handler;
        }

        [HttpPost]
        [Route("login")]
        public ICommandResult Autenticar([FromBody] AuthenticationUsuarioCommand command)
        {
            var result = _handler.Handle(command);
            return result;
        }

    }
}
