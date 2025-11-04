namespace Core;

public class Usuario
{
    public int Id_usuario { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime Fecha_nacimiento { get; set; }
    public string Password { get; set; } = string.Empty; // debe ser de 64 caracteres
    public int Id_rol { get; set; } // FK -> Rol
}
