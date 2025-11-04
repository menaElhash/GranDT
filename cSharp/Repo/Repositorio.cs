using System.Data;

namespace PersistenciaDapper;

public abstract class Repositorio
{
    protected IDbConnection Conexion { get; private set; }

    protected Repositorio(IDbConnection connection) => Conexion = connection;
}