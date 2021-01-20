using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste.Direcional.Dominio.Entidades;
using Teste.Direcional.Infra.Interfaces;

namespace Teste.Direcional.Infra.Repositorios
{
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        public Usuario ObterPorLogin(string cpf)
        {
            using (var conexao = CriarConexao())
            {
                string sql = @"SELECT * FROM Usuario WHERE Login = @Login";

                return conexao.Query<Usuario>(sql, new
                {
                    Login = cpf
                }).FirstOrDefault();
            }
        }

        public int Salvar(Usuario registro)
        {
            using (var conexao = CriarConexao())
            {
                string sql = @"IF NOT EXISTS(SELECT * FROM Usuario WHERE Login = @Login)
                                BEGIN
                                    INSERT INTO Usuario ([Login], [Senha])
                                       VALUES( 
                                       @Login, 
                                       @Senha)
                                    SELECT CAST(SCOPE_IDENTITY() as int)
                                END
                                ELSE
                                 BEGIN
                                    UPDATE Usuario SET
                                      Login = @Login, 
                                      Senha = @Senha                                      
                                    WHERE Id = @IdUsuario
                                    SELECT @IdUsuario
                                END";

                return conexao.Query<int>(sql, new
                {
                    IdUsuario = registro.Id,                    
                    Login = registro.Login,
                    Senha = registro.Senha
                }).SingleOrDefault();
            }
        }
    }
}
