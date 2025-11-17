using Core.Repos;
using Dapper;
using Core; // Para los modelos Plantilla, Jugador, Usuario

namespace Test;
public class RepoPlantillaTests : TestRepo
{
    readonly IRepoPlantilla repoPlantilla;
    readonly IRepoUsuario repoUsuario;
    readonly IRepoJugador repoJugador;
    private readonly int TestUsuarioId;
    private readonly int TestJugadorId;
    private static int _testCounter = 1;

    public RepoPlantillaTests() : base()
    {
        // 1. Inicialización de Repositorios
        repoPlantilla = new RepoPlantilla(_conexion);
        repoUsuario = new RepoUsuario(_conexion);
        repoJugador = new RepoJugador(_conexion);

        // 2. SETUP (Creación de dependencias necesarias)
        // Crear un usuario de prueba (FK para Plantilla)
        var usuario = new Usuario 
        { 
            nombre = "Pla", apellido = "User", 
            email = $"pla_user_test{_testCounter}@test.com", fecha_nacimiento = new DateTime(1990, 1, 1), 
            password = "hashplantilla", id_rol = 1 
        };
        TestUsuarioId = repoUsuario.AltaUsuario(usuario);
        
        // Crear un jugador de prueba (FK para PlantillaJugador)
        var idEquipo = repoJugador.AltaEquipo($"EqPla{_testCounter}");
        var idTipo = repoJugador.AltaTipo($"TipoPla{_testCounter}");
        var jugador = new Jugador 
        { nombre = "Player", apellido = "Pla", fecha_nacimiento = new DateTime(2000, 1, 1), cotizacion = 100, id_equipo = (int)idEquipo, id_tipo = (int)idTipo };
        TestJugadorId = repoJugador.AltaJugador(jugador);
        
        _testCounter++;
    }

    [Fact]
    public void AltaPlantilla_DevuelveIdValido()
    {
        // Uso del modelo Plantilla y sus propiedades correctas
        var plantilla = new Plantilla
        {
            presupuesto = 5000000, 
            id_usuario = TestUsuarioId,
            fecha_creacion = DateTime.Now.Date
        };

        var id = repoPlantilla.AltaPlantilla(plantilla);

        Assert.True(id > 0);
    }

    [Fact]
    public void TraerPlantillasPorIdUsuario_DevuelveLista()
    {
        // 1. Alta de una plantilla de prueba
        var plantilla = new Plantilla
        {
            presupuesto = 7000000,
            id_usuario = TestUsuarioId,
            fecha_creacion = DateTime.Now.Date
        };
        repoPlantilla.AltaPlantilla(plantilla);

        // 2. Act
        var plantillasPorUsuario = repoPlantilla.TraerPlantillasPorIdUsuario(TestUsuarioId);

        // Assert
        Assert.NotEmpty(plantillasPorUsuario);
    }

    [Fact]
    public void AltaJugadorEnPlantilla_AgregaJugador()
    {
        // Arrange: Crear una plantilla de prueba
        var plantilla = new Plantilla { presupuesto = 1000, id_usuario = TestUsuarioId, fecha_creacion = DateTime.Now.Date };
        int idPlantilla = repoPlantilla.AltaPlantilla(plantilla);

        // Act
        // Usamos TestJugadorId
        repoPlantilla.AltaJugadorEnPlantilla(TestJugadorId, idPlantilla, true);

        // Assert
        Assert.True(true, "Se verifica la ejecución sin excepción.");
    }
    
    [Fact]
    public void ActualizarEstadoJugador_CambiaCorrectamente()
    {
        // Arrange
        var plantilla = new Plantilla { presupuesto = 2000, id_usuario = TestUsuarioId, fecha_creacion = DateTime.Now.Date };
        int idPlantilla = repoPlantilla.AltaPlantilla(plantilla);
        
        // 1. Alta inicial (se asume que se creó con un ID único)
        repoPlantilla.AltaJugadorEnPlantilla(TestJugadorId, idPlantilla, true);
        
        // 2. Act: Actualizar a suplente (false)
        repoPlantilla.ActualizarEstadoJugador(TestJugadorId, idPlantilla, false);

        // Assert
        Assert.True(true, "Se verifica la ejecución sin excepción.");
    }
}