using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Votacao.Commands.Inputs
{
    public class AdicionarVotoCommand : Notifiable, ICommandPadrao
    {
        private readonly IUsuarioRepository _repository;

        public AdicionarVotoCommand(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public long Id_Usuario { get; set; }
        public long Id_Filme { get; set; }

        
        public bool ValidarCommand()
        {
            try
            {
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
