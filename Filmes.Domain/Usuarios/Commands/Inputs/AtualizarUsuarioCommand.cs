using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Desafio.Infra.Interfaces.Commands;

namespace Desafio.Domain.Commands.Inputs
{
    public class AtualizarUsuarioCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                {
                    AddNotification("Id", "Id deve ser maior que zero");
                }
                if (string.IsNullOrWhiteSpace(Nome))
                {
                    AddNotification("Nome", "Nome é um campo obrigatório");
                }
                else if (Nome.Length > 50)
                {
                    AddNotification("Nome", "Nome é maior que 50 caracteres");
                }
                if (string.IsNullOrWhiteSpace(Login))
                {
                    AddNotification("Login", "Login é um campo obrigatório");
                }
                else if (Login.Length > 50)
                {
                    AddNotification("Login", "Login é maior que 50 caracteres");
                }
                if (string.IsNullOrWhiteSpace(Senha))
                {
                    AddNotification("Senha", "Senha é um campo obrigatório");
                }
                else if (Senha.Length > 50)
                {
                    AddNotification("Senha", "Senha é maior que 50 caracteres");
                }
                return Valid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
