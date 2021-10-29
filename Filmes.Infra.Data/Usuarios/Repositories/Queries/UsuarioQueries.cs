
namespace Desafio.Infra.Data.Repositories.Queries
{
    public static class UsuarioQueries
    {
        public static string Inserir = @"Insert Into UsuarioDados(Nome, Login, Senha) Values (@Nome, @Login, @Senha); 
Select SCOPE_IDENTITY();";

        public static string Atualizar = @"Update UsuarioDados Set Nome=@Nome, Login=@Login, Senha=@Senha Where Id=@Id";

        public static string Excluir = @"Delete from UsuarioDados Where Id=@Id";

        public static string Listar = @"Select Id, Nome, Login, Senha From UsuarioDados";

        public static string Obter = @"Select Id, Nome, Login, Senha From UsuarioDados Where Id=@Id";

        public static string CheckId = @"Select Id From UsuarioDados Where Id=@Id";

        public static string CheckLogin = @"Select Login, Senha From UsuarioDados Where Login=@Login";
    }
}