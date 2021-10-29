using Flunt.Notifications;
using System;
using Desafio.Infra.Interfaces.Commands;

namespace Desafio.Domain.Commands.Inputs
{
    public class AdicionarUsuarioCommand : Notifiable, ICommandPadrao
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public bool ValidarCommand()
        {
            try
            {
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
