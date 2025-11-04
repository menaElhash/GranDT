namespace Core;
public class Jugador
{
    public int Id_jugador { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string? Apodo { get; set; } // opcional
    public DateTime FechaNacimiento { get; set; }
    public decimal Cotizacion { get; set; }
    public int Id_equipo { get; set; } // FK -> Equipo
    public int Id_tipo { get; set; } // FK -> TipoJugador
    public IEnumerable<Puntuacion> Puntos { get; set; } = [];
    public decimal PuntuacionParaFecha(int nroFecha)
    {
        var puntuacionFecha = Puntos.FirstOrDefault(p => p.Fecha_numero == nroFecha);
        return puntuacionFecha is not null ? puntuacionFecha.Nota : 0;
    }
}
