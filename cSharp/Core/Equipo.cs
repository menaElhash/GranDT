
namespace Core;

public class Equipo
{
    public int Id_equipo { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public required List<Jugador> Jugadores { get; set; }
}
