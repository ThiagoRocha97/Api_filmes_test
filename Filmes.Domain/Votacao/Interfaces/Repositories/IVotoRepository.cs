using Desafio.Domain.Votacao.Entidades;
using Desafio.Domain.Votacao.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Votacao.Interfaces.Repositories
{
    public interface IVotoRepository
    {
        long InserirVoto(Voto voto);
        void AtualizarVoto(Voto voto);
        void ExcluirVoto(long id);
        List<VotoQueryResult> ListarVoto();
        VotoQueryResult ObterVoto(long id);
        bool CheckIdVoto(long id);
    }
}
