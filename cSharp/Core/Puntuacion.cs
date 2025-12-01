namespace Core;

public class Puntuacion
{
    public int id_puntuacion { get; set; }
    public int id_jugador { get; set; } // FK -> Jugador
    public int fecha_numero { get; set; }  // número de fecha (< 50)
    public decimal nota { get; set; }  // del 1 al 10
}
