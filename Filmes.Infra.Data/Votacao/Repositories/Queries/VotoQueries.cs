using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Data.Votacao.Repositories.Queries
{
    public class VotoQueries
    {
        public static string AtualizarVoto = @"Update VotoDados Set IdUsuario=@IdUsuario, IdFilme=@IdFilme Where VotoDados.Id=@Id";
        public static string CheckIdVoto = @"Select Id From VotoDados Where Id=@Id";
        public static string ExcluirVoto = @"Delete From VotoDados Where VotoDados.Id=@Id";
        public static string InserirVoto = @"Insert Into VotoDados(IdUsuario, IdFilme) Values(@IdUsuario, @IdFilme);Select SCOPE_IDENTITY()";
        public static string ListarVoto = @"SELECT VotoDados.Id as IdVoto, FilmeDados.Id as IdFilme, FilmeDados.Titulo, FilmeDados.Diretor, 
                                            UsuarioDados.Id as IdUsuario, UsuarioDados.Nome, UsuarioDados.Login, UsuarioDados.Senha from VotoDados 
                                            INNER JOIN FilmeDados 
                                            ON VotoDados.IdFilme = FilmeDados.Id 
                                            INNER Join UsuarioDados
                                            ON VotoDados.IdUsuario = UsuarioDados.Id";
        public static string ObterVoto = @"SELECT VotoDados.Id as IdVoto, FilmeDados.Id as IdFilme, FilmeDados.Titulo, FilmeDados.Diretor, 
                                            UsuarioDados.Id as IdUsuario, UsuarioDados.Nome, UsuarioDados.Login, UsuarioDados.Senha from VotoDados 
                                            INNER JOIN FilmeDados 
                                            ON VotoDados.IdFilme = FilmeDados.Id 
                                            INNER Join UsuarioDados
                                            ON VotoDados.IdUsuario = UsuarioDados.Id 
                                            Where VotoDados.Id=@Id";
    }
}
