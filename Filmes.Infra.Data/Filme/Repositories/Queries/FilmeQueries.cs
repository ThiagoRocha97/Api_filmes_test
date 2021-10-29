using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Data.Repositories.Queries
{
    public class FilmeQueries
    {
        public static string Inserir = @"Insert Into FilmeDados (Titulo, Diretor) Values(@Titulo, @Diretor); Select SCOPE_IDENTITY()";

        public static string Atualizar = @"Update FilmeDados Set Titulo=@Titulo, Diretor=@Diretor Where Id=@Id";

        public static string Excluir = @"Delete From FilmeDados Where Id=@Id";

        public static string Listar = @"Select Id, Titulo, Diretor From FilmeDados";

        public static string Obter = @"Select Id, Titulo, Diretor From FilmeDados Where Id=@Id";

        public static string CheckId = @"Select Id From FilmeDados Where Id=@Id";
    }

}