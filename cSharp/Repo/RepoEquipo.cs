using System.Data;
using core;
using core.Persistencia;
using Dapper;

namespace PersistenciaDapper
{
    public class RepoEquipo : Repositorio, IRepoEquipo
    {
        public RepoEquipo(IDbConnection connection) : base(connection)
        {
        }

    }
}
