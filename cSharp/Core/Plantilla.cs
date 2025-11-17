namespace Core;

public class Plantilla
{
    public int id_plantilla { get; set; }
    public int id_usuario { get; set; } // FK -> Usuario
    public decimal presupuesto { get; set; }
    public DateTime fecha_creacion { get; set; }
}