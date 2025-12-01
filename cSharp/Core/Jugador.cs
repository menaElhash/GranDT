using System;
using System.Collections.Generic;

namespace Core;

public class Jugador
{
    public int id_jugador { get; set; }
    public string nombre { get; set; } = string.Empty;
    public string apellido { get; set; } = string.Empty;
    public string? apodo { get; set; }
    public DateTime fecha_nacimiento { get; set; }
    public decimal cotizacion { get; set; }
    public int id_equipo { get; set; }
    public int id_tipo { get; set; } // FK -> TipoJugador
    public List<Puntuacion>? puntuaciones { get; set; }
}

