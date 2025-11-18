namespace Core;

public class Plantilla
{
    public int id_plantilla { get; set; }
    public int id_usuario { get; set; } // FK -> Usuario
    public int id_equipo { get; set; } // FK -> Equipo
    public decimal presupuesto_max { get; set; }
    public DateTime fecha_creacion { get; set; }
}