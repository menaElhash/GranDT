
namespace Core;

public class Equipo
{
    public int id_equipo { get; set; }
    public string nombre { get; set; } = string.Empty;
    public required List<Jugador> jugadores { get; set; }
}
