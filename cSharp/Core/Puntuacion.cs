namespace Core;

public class Puntuacion
{
    public int Id_puntuacion { get; set; }
    public int Id_jugador { get; set; } // FK -> Jugador
    public int Fecha_numero { get; set; }  // número de fecha (< 50)
    public decimal Nota { get; set; }  // del 1 al 10
}
