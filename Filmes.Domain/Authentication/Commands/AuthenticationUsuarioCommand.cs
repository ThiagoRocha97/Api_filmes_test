using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Usuarios.Commands.Inputs
{
    public class AuthenticationUsuarioCommand : Notifiable, ICommandPadrao
    {
        public string Login { get; set; }
        public string Senha { get; set; }
                        
        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Login))
                {
                    AddNotification("Login", "Login é um campo obrigatório.");
                }
                if (string.IsNullOrEmpty(Login))
                {
                    AddNotification("Senha", "Senha é um campo obrigatório.");
                }

                return Valid;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
