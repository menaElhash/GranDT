using System.Data;
using MySqlConnector;

namespace Test;

/// <summary>
/// Provee una conexión MySql para tests de integración locales.
/// Usa la cadena por defecto o puede recibir una diferente.
/// </summary>
public class TestRepo
{
    protected readonly IDbConnection _conexion;
    private const string _cadena = "Server=localhost;User ID=5to_agbd;Password=Trigg3rs!;Database=Gran_DT;";

    public TestRepo() => _conexion = new MySqlConnection(_cadena);
    public TestRepo(string cadena) => _conexion = new MySqlConnection(cadena);
}
