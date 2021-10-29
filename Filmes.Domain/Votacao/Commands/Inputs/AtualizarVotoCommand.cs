using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Votacao.Commands.Inputs
{
    public class AtualizarVotoCommand:Notifiable, ICommandPadrao
    {
        public long Id { get; set; }
        public long Id_Usuario { get; set; }
        public long Id_Filme { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                {
                    AddNotification("Id", "Id deve ser maior que zero");
                }
                if (Id_Usuario <= 0)
                {
                    AddNotification("Id_Usuario", "Id_Usuario deve ser maior que zero");
                }
                if (Id_Filme <= 0)
                {
                    AddNotification("Id_Filme", "Id_Filme deve ser maior que zero");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Valid;
        }
    }    
}
