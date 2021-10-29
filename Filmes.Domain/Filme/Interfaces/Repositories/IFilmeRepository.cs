using Desafio.Domain.Entidades;
using Desafio.Domain.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Interfaces.Repositories
{
    public interface IFilmeRepository
    {
        long Inserir(Filme filme);
        void Atualizar(Filme filme);
        void Excluir(long id);
        List<FilmeQueryResult> Listar();
        FilmeQueryResult Obter(long id);
        bool CheckId(long id);
    }
}
