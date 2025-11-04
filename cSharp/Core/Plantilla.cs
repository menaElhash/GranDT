namespace Core;

public class Plantilla
{
    public int Id_plantilla { get; set; }
    public int Id_usuario { get; set; } // FK -> Usuario
    public decimal Presupuesto { get; set; }
    public DateTime Fecha_creacion { get; set; }
}
