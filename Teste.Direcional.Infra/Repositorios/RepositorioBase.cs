using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Teste.Direcional.Dominio.Properties;
using Teste.Direcional.Infra.Interfaces;

namespace Teste.Direcional.Infra.Repositorios
{
    public abstract class RepositorioBase<TClasse> : IRepositorioBase<TClasse> where TClasse : class, new()
    {
        protected IDbConnection CriarConexao()
        {
            string connection = string.Empty;
#if DEBUG
            connection = Settings.Default.ConnectionString;
#else
            connection = Settings.Default.ConnectionString;
#endif
            var conexao = new SqlConnection(connection);

            conexao.Open();
            return conexao;
        }
    }
}