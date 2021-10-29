using Desafio.Domain.Entidades;
using System.Collections.Generic;
using Desafio.Domain.Query;
using Desafio.Domain.Usuarios.Query;

namespace Desafio.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        long Inserir(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Excluir(long id);
        List<UsuarioQueryResult> Listar();
        UsuarioQueryResult Obter(long id);
        bool CheckId(long id);
        string ValidarLogin(string login);
                
    }
}
