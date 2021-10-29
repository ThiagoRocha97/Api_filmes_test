using Desafio.Infra.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Data.DataContexts
{
    public class DataContext : IDisposable
    {
        public SqlConnection SqlServerConexao { get; set; }

        public DataContext(AppSettings appsetings)
        {
            try
            {
                SqlServerConexao = new SqlConnection(appsetings.ConnectionString);
                SqlServerConexao.Open();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Dispose()
        {
            try
            {
                if(SqlServerConexao.State != ConnectionState.Closed)
                {
                    SqlServerConexao.Close();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
