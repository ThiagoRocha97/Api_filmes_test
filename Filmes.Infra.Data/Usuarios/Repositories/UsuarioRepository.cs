using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Query;
using Desafio.Infra.Data.DataContexts;
using Desafio.Infra.Data.Repositories.Queries;
using Desafio.Domain.Usuarios.Query;

namespace Desafio.Infra.Data.Repositories
{

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly DataContext _dataContext;
        

        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Atualizar(Usuario usuario)
        {
            try
            {
                _parameters.Add("Id", usuario.Id, DbType.Int64);
                _parameters.Add("Nome", usuario.Nome, DbType.String);
                _parameters.Add("Login", usuario.Login, DbType.String);
                _parameters.Add("Senha", usuario.Senha, DbType.String);

                _dataContext.SqlServerConexao.Execute(UsuarioQueries.Atualizar, _parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckId(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);

                return _dataContext.SqlServerConexao.Query<bool>(UsuarioQueries.CheckId, _parameters).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);

                _dataContext.SqlServerConexao.Execute(UsuarioQueries.Excluir, _parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Inserir(Usuario usuario)
        {
            try
            {

                _parameters.Add("Nome", usuario.Nome, DbType.String);
                _parameters.Add("Login", usuario.Login, DbType.String);
                _parameters.Add("Senha", usuario.Senha, DbType.String);

                return _dataContext.SqlServerConexao.ExecuteScalar<long>(UsuarioQueries.Inserir, _parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UsuarioQueryResult> Listar()
        {
            try
            {
                var usuarios = _dataContext.SqlServerConexao.Query<UsuarioQueryResult>(UsuarioQueries.Listar).ToList();
                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UsuarioQueryResult Obter(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);

                var usuario = _dataContext.SqlServerConexao.Query<UsuarioQueryResult>(UsuarioQueries.Obter, _parameters).FirstOrDefault();
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ValidarLogin(string login)
        {
            try
            {
                _parameters.Add("Login", login, DbType.String);

                return _dataContext.SqlServerConexao.Query<string>(UsuarioQueries.CheckLogin, _parameters).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}