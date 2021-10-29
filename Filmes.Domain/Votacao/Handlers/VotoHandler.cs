using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Votacao.Commands.Inputs;
using Desafio.Domain.Votacao.Commands.Outputs;
using Desafio.Domain.Votacao.Entidades;
using Desafio.Domain.Votacao.Interfaces.Repositories;
using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Votacao.Handlers
{

    public class VotoHandler : ICommandHandler<AdicionarVotoCommand>, ICommandHandler<AtualizarVotoCommand>, ICommandHandler<ApagarVotoCommand>
    {
        private readonly IVotoRepository _repository;
        
        public VotoHandler(IVotoRepository repository, IUsuarioRepository repUsuario)
        {
            _repository = repository;
            
        }
        public ICommandResult Handle(AdicionarVotoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new VotoCommandResult(false, "Corrija os erros", command.Notifications);
                }
                
                long id = 0;
                long id_usuario = command.Id_Usuario;
                long id_filme = command.Id_Filme;
                

                Voto voto = new Voto(id, id_usuario, id_filme);
                id = _repository.InserirVoto(voto);
                var retorno = new VotoCommandResult(true, "Voto adicionado com sucesso", new { Id = id, IdUsuario = voto.Id_Usuario, IdFilme = voto.Id_Filme});
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(AtualizarVotoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new VotoCommandResult(false, "Corrija os erros", command.Notifications);
                }
                if (!_repository.CheckIdVoto(command.Id))
                {
                    return new VotoCommandResult(false, "Id", new Notification("Id", "Id inválido. Este id não está cadatrado"));
                }
                long id = command.Id;
                long id_usuario = command.Id_Usuario;
                long id_filme = command.Id_Filme;

                Voto voto = new Voto(id, id_usuario, id_filme);
                _repository.AtualizarVoto(voto);
                var retorno = new VotoCommandResult(true, "Voto alterado com sucesso", new { Id = id, IdUsuario = voto.Id_Usuario, IdFilme = voto.Id_Filme }); 
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(ApagarVotoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new VotoCommandResult(false, "Corrija os erros", command.Notifications);
                }
                if (!_repository.CheckIdVoto(command.Id))
                {
                    return new VotoCommandResult(false, "Id", new Notification("Id", "Id inválido. Este id não está cadatrado"));
                }
                long id = command.Id;

                _repository.ExcluirVoto(id);
                var retorno = new VotoCommandResult(true, "Voto excluido com sucesso", new { Id = id });
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
