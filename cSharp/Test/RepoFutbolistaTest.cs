using Core.Repos;
using Dapper;
using Core; // Para los modelos Jugador, Equipo, TipoJugador, Puntuacion

namespace Test;

public class RepoJugadorTests : TestRepo
{
    readonly IRepoJugador repoJugador;
    private const uint TestEquipoId = 1; // Asumimos que existe
    private const uint TestTipoId = 1;   // Asumimos que existe
    private static int _jugadorCounter = 1;

    public RepoJugadorTests() : base()
        => repoJugador = new RepoJugador(_conexion);

    // Método auxiliar para crear un jugador y obtener su ID
    private int CrearJugadorDePrueba(string apellidoBase)
    {
        var jugador = new Jugador 
        {
            nombre = "Test",
            apellido = $"{apellidoBase}{_jugadorCounter++}",
            apodo = "TJ",
            fecha_nacimiento = new DateTime(2000, 1, 1),
            cotizacion = 1000,
            id_equipo = (int)TestEquipoId,
            id_tipo = (int)TestTipoId
        };
        return repoJugador.AltaJugador(jugador);
    }
    
    [Fact]
    public void AltaFutbolista_DevuelveIdValido()
    {
        var id = CrearJugadorDePrueba("Futb");
        Assert.True(id > 0, "El ID devuelto debe ser mayor que cero.");
    }

    [Fact]
    public void AltaPuntuacion_DevuelveIdValido()
    {
        // 1. Crear un jugador de prueba
        int idJugador = CrearJugadorDePrueba("Puntua");
        
        // 2. Alta de Puntuación (propiedades corregidas: nota, fecha_numero)
        var puntuacion = new Puntuacion
        {
            nota = 8.5m, 
            fecha_numero = new DateTime(2025, 11, 17)
        };

        var id = repoJugador.AltaPuntuacion(puntuacion, idJugador);
        Assert.True(id > 0, "El ID de la puntuación devuelto debe ser mayor que cero.");
    }

    [Fact]
    public void TraerJugadoresBasicoXTipoXEquipo_DevuelveListaCorrecta()
    {
        // 1. Alta de un jugador que coincida con los IDs fijos
        CrearJugadorDePrueba("Buscado");

        // 2. Act: Ejecutar el método con los IDs de prueba
        var futbolistas = repoJugador.TraerJugadoresBasicoXTipoXEquipo(TestTipoId, TestEquipoId);

        Assert.NotNull(futbolistas);
        Assert.NotEmpty(futbolistas);
        Assert.Contains(futbolistas, f => f.apellido.StartsWith("Buscado")); 
    }
    
    [Fact]
    public void AltaEquipo_DevuelveIdValido()
    {
        string nombreEquipo = $"Equipo Test {_jugadorCounter++}";
        var id = repoJugador.AltaEquipo(nombreEquipo);
        Assert.True(id > 0, "El ID del equipo debe ser mayor que cero.");
    }

    [Fact]
    public void TraerEquipo_DevuelveListaNoVacia()
    {
        // Aseguramos que haya al menos uno
        repoJugador.AltaEquipo($"Equipo Lista {_jugadorCounter++}");
        
        var equipos = repoJugador.TraerEquipo();
        Assert.NotNull(equipos);
        Assert.NotEmpty(equipos);
    }
    
    [Fact]
    public void AltaTipo_DevuelveIdValido()
    {
        string descripcionTipo = $"Tipo Test {_jugadorCounter++}";
        var id = repoJugador.AltaTipo(descripcionTipo);
        Assert.True(id > 0, "El ID del tipo de jugador debe ser mayor que cero.");
    }
}