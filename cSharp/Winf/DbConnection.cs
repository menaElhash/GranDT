using System.Data;
using MySqlConnector;

namespace el_dt_by_menardi_y_tello
{
    /// <summary>
    /// Proporciona la conexión a la base de datos MySQL.
    /// Se replica desde TestRepo para usar en los formularios.
    /// </summary>
    public class DbConnection
    {
        private const string _cadena = "Server=localhost;User ID=5to_agbd;Password=Trigg3rs!;Database=Gran_DT;";

        public static IDbConnection GetConnection()
        {
            return new MySqlConnection(_cadena);
        }
    }
}
