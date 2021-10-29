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
    public class ApagarUsuarioCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                {
                    AddNotification("Id", "Id deve ser maior que zero");
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
