using Flunt.Notifications;
using System;
using Desafio.Domain.Commands.Inputs;
using Desafio.Domain.Commands.Outputs;
using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infra.Interfaces.Commands;
using Desafio.Domain.Usuarios.Commands.Inputs;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Desafio.API;
using Desafio.Infra.Settings;

namespace Desafio.Domain.Handlers
{
    public class UsuarioHandler : ICommandHandler<AdicionarUsuarioCommand>, ICommandHandler<ApagarUsuarioCommand>, ICommandHandler<AtualizarUsuarioCommand>, ICommandHandler<AuthenticationUsuarioCommand>
    {
        private readonly IUsuarioRepository _repository;
        private readonly AppSettings _settings;

        public UsuarioHandler(IUsuarioRepository repository, AppSettings settings)
        {
            _repository = repository;
            _settings = settings;
        }

        public ICommandResult Handle(AdicionarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new UsuarioCommandResult(false, "Corrija os erros", command.Notifications);
                }

                long id = 0;
                string nome = command.Nome;
                string login = command.Login;
                string senha = command.Senha;


                Usuario usuario = new Usuario(id, nome, login, senha);

                id = _repository.Inserir(usuario);

                var retorno = new UsuarioCommandResult(true, "Usuario cadastrado com sucesso",
                    new { Id = id, Nome = usuario.Nome, usuario.Login, usuario.Senha });
                return retorno;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(AtualizarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new UsuarioCommandResult(false, "Corrija os erros", command.Notifications);
                }

                if (!_repository.CheckId(command.Id))
                {
                    return new UsuarioCommandResult(false, "Id", new Notification("Id", "Id inválido. Este id não está cadatrado"));
                }
                long id = command.Id;
                string nome = command.Nome;
                string login = command.Login;
                string senha = command.Senha;

                Usuario usuario = new Usuario(id, nome, login, senha);

                _repository.Atualizar(usuario);

                var retorno = new UsuarioCommandResult(true, "Usuario alterado com sucesso",
                    new { Id = id, Nome = usuario.Nome, usuario.Login, usuario.Senha });
                return retorno;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(ApagarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new UsuarioCommandResult(false, "Corrija os erros", command.Notifications);
                }

                if (!_repository.CheckId(command.Id))
                {
                    return new UsuarioCommandResult(false, "Id", new Notification("Id", "Id inválido. Este id não está cadatrado"));
                }
                long id = command.Id;

                _repository.Excluir(command.Id);

                var retorno = new UsuarioCommandResult(true, "Usuario deletado com sucesso", new { Id = id });

                return retorno;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(AuthenticationUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new UsuarioCommandResult(false, "Corrija os erros", command.Notifications);
                }
                
                string login = command.Login;
                string senha = command.Senha;
                _repository.ValidarLogin(command.Login);
                var retorno = new UsuarioCommandResult(true, "Usuario conectado com sucesso", new { Login = login , Senha = senha, Token = GerarToken(login)});

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string GerarToken(string login)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, login.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
