namespace Desafio.Domain.Entidades
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario(long id, string nome, string login, string senha)
        {
            Id = id;
            Nome = nome;
            Login = login;
            Senha = senha;
        }
    }
}
