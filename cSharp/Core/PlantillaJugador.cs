namespace Core;

public class PlantillaJugador
{
    public int Id_plantilla { get; set; } // FK -> Plantilla
    public int Id_jugador { get; set; }   // FK -> Jugador
    public bool Es_titular { get; set; }  // true = titular, false = suplente
}
