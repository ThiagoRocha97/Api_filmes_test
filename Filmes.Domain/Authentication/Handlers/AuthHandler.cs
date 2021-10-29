using Desafio.API;
using Desafio.Domain.Commands.Outputs;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Usuarios.Commands.Inputs;
using Desafio.Infra.Interfaces.Commands;
using Desafio.Infra.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Desafio.Domain.Usuarios.Handlers
{
    public class AuthHandler: ICommandHandler<AuthenticationUsuarioCommand>
    {
        private readonly IUsuarioRepository _repository;
        AppSettings _settings = new AppSettings();
        
        public AuthHandler(IUsuarioRepository repository)
        {
            _repository = repository;            
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
               
                var retorno = new UsuarioCommandResult(true, "Usuario conectado com sucesso", new { Login = login, Senha = senha, Token = GerarToken(login) });

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private object GerarToken(string login)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, login));

            var identityClaims = new ClaimsIdentity();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = Settings.Issuer,
                Audience = Settings.Audience,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(Settings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });
            var encodedToken = tokenHandler.WriteToken(token);
            return new
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(Settings.Expiration).TotalSeconds
            };
        }
        //private string GerarToken(string login)
        //{

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(Settings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Email, login.ToString())
        //        })
        //        ,
        //        Expires = DateTime.UtcNow.AddHours(Settings.Expiration),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}
    }
}

