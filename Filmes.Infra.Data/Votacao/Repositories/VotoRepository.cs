using Dapper;
using Desafio.Domain.Votacao.Entidades;
using Desafio.Domain.Votacao.Interfaces.Repositories;
using Desafio.Domain.Votacao.Query;
using Desafio.Infra.Data.DataContexts;
using Desafio.Infra.Data.Votacao.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Data.Votacao.Repositories
{
    public class VotoRepository : IVotoRepository
    {
        private readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly DataContext _dataContext;

        public VotoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AtualizarVoto(Voto voto)
        {
            try
            {
               
                _parameters.Add("Id", voto.Id, DbType.Int64);
                _parameters.Add("IdUsuario", voto.Id_Usuario, DbType.String);
                _parameters.Add("IdFilme", voto.Id_Filme, DbType.String);

                _dataContext.SqlServerConexao.Execute(VotoQueries.AtualizarVoto, _parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckIdVoto(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);

                return _dataContext.SqlServerConexao.Query<bool>(VotoQueries.CheckIdVoto, _parameters).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirVoto(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);


                _dataContext.SqlServerConexao.Execute(VotoQueries.ExcluirVoto, _parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long InserirVoto(Voto voto)
        {
            try
            {
                _parameters.Add("Id", voto.Id, DbType.Int64);
                _parameters.Add("IdUsuario", voto.Id_Usuario, DbType.String);
                _parameters.Add("IdFilme", voto.Id_Filme, DbType.String);

                return _dataContext.SqlServerConexao.ExecuteScalar<long>(VotoQueries.InserirVoto, _parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VotoQueryResult> ListarVoto()
        {
            try
            {
                var votos = _dataContext.SqlServerConexao.Query<VotoQueryResult>(VotoQueries.ListarVoto).ToList();
                return votos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VotoQueryResult ObterVoto(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);

                var voto = _dataContext.SqlServerConexao.Query<VotoQueryResult>(VotoQueries.ObterVoto, _parameters).FirstOrDefault();
                return voto;
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


                _dataContext.SqlServerConexao.Execute(VotoQueries.ExcluirVoto, _parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
