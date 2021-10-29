using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Commands.Inputs
{
    public class ApagarFilmeCommand : Notifiable, ICommandPadrao
    {
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
