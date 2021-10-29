using Dapper;
using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Query;
using Desafio.Infra.Data.DataContexts;
using Desafio.Infra.Data.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Data.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly DataContext _dataContext;

        public FilmeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Atualizar(Filme filme)
        {
            try
            {
                _parameters.Add("Id", filme.Id, DbType.Int64);
                _parameters.Add("Titulo", filme.Titulo, DbType.String);
                _parameters.Add("Diretor", filme.Diretor, DbType.String);

                _dataContext.SqlServerConexao.Execute(FilmeQueries.Atualizar, _parameters);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckId(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);
   
                return _dataContext.SqlServerConexao.Query<bool>(FilmeQueries.CheckId, _parameters).FirstOrDefault();
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
                

                _dataContext.SqlServerConexao.Execute(FilmeQueries.Excluir, _parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Inserir(Filme filme)
        {
            try
            {
                _parameters.Add("Id", filme.Id, DbType.Int64);
                _parameters.Add("Titulo", filme.Titulo, DbType.String);
                _parameters.Add("Diretor", filme.Diretor, DbType.String);

                return _dataContext.SqlServerConexao.ExecuteScalar<long>(FilmeQueries.Inserir, _parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FilmeQueryResult> Listar()
        {
            try
            {               
                var usuarios = _dataContext.SqlServerConexao.Query<FilmeQueryResult>(FilmeQueries.Listar).ToList();
                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FilmeQueryResult Obter(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);
                

                var filme = _dataContext.SqlServerConexao.Query<FilmeQueryResult>(FilmeQueries.Obter, _parameters).FirstOrDefault();
                return filme;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
