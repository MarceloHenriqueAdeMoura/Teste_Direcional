using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste.Direcional.Dominio.Entidades;
using Teste.Direcional.Infra.Interfaces;
using Teste.Direcional.Infra.Repositorios;

namespace Teste.Direcional.Infra.Repositorios
{
    public class RepositorioContato : RepositorioBase<Contato>, IRepositorioContato
    {
        public int Salvar(Contato registro)
        {
            using (var conexao = CriarConexao())
            {
                string sql = @"IF NOT EXISTS(SELECT * FROM Contato WHERE CPF = @CPF)
                                BEGIN
                                    INSERT INTO Contato ([Nome], [CPF], [Email], [Anexo])
                                       VALUES( 
                                       @Nome, 
                                       @CPF, 
                                       @Email,
                                       @Anexo)
                                    SELECT CAST(SCOPE_IDENTITY() as int)
                                END
                                ELSE
                                 BEGIN
                                    UPDATE Contato SET
                                      Nome = @Nome, 
                                      CPF = @CPF, 
                                      Email = @Email, 
                                      Anexo = @Anexo
                                    WHERE Id = @IdContato
                                    SELECT @IdContato
                                END";

                return conexao.Query<int>(sql, new
                {
                    IdContato = registro.Id,
                    Nome = registro.Nome,
                    CPF = registro.CPF,
                    Email = registro.Email,
                    Anexo = registro.Anexo
                }).SingleOrDefault();
            }
        }
    }
}
