using System.Data;
using core;
using core.Persistencia;
using Dapper;

namespace PersistenciaDapper;

public class RepoUsuario : Repositorio, IRepoUsuario
{
    public RepoUsuario(IDbConnection connection) : base(connection)
    {
    }

}
