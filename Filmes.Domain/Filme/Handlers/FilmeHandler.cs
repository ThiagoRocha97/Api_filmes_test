using Desafio.Domain.Commands.Inputs;
using Desafio.Domain.Commands.Outputs;
using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Handlers
{
    public class FilmeHandler : ICommandHandler<AdicionarFilmeCommand>, ICommandHandler<ApagarFilmeCommand>, ICommandHandler<AtualizarFilmeCommand>
    {
        private readonly IFilmeRepository _repository;
        public FilmeHandler(IFilmeRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(AdicionarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new FilmeCommandResult(false, "Corrija os erros", command.Notifications);
                }
                long id = 0;
                string titulo = command.Titulo;
                string diretor = command.Diretor;

                Filme filme = new Filme(id, titulo, diretor);
                id = _repository.Inserir(filme);
                var retorno = new FilmeCommandResult(true, "Filme adicionado com sucesso", new { Id = id, Titulo = filme.Titulo, Diretor = filme.Diretor });
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ICommandResult Handle(AtualizarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new FilmeCommandResult(false, "Corrija os erros", command.Notifications);
                }
                if (!_repository.CheckId(command.Id))
                {
                    return new FilmeCommandResult(false, "Id", new Notification("Id", "Id inválido. Este id não está cadatrado"));
                }
                long id = command.Id;
                string titulo = command.Titulo;
                string diretor = command.Diretor;

                Filme filme = new Filme(id, titulo, diretor);
                _repository.Atualizar(filme);
                var retorno = new FilmeCommandResult(true, "Filme alterado com sucesso", new { Id = id, Titulo = filme.Titulo, Diretor = filme.Diretor });
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(ApagarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new FilmeCommandResult(false, "Corrija os erros", command.Notifications);
                }
                if (!_repository.CheckId(command.Id))
                {
                    return new FilmeCommandResult(false, "Id", new Notification("Id", "Id inválido. Este id não está cadatrado"));
                }
                long id = command.Id;
               
                _repository.Excluir(id);
                var retorno = new FilmeCommandResult(true, "Filme excluido com sucesso", new { Id = id});
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
