using System.Data;
using core;
using core.Persistencia;
using Dapper;

namespace PersistenciaDapper
{
    public class RepoJugador : Repositorio, IRepoJugador
    {
        public RepoJugador(IDbConnection connection) : base(connection)
        {
        }

        // --- Alta ---
       
    }
}