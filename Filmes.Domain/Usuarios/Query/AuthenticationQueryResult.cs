using Desafio.Infra.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Usuarios.Query
{
    public class AuthenticationQueryResult
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }        
    }
}
