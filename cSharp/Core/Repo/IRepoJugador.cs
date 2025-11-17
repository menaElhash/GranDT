namespace Core.Repos;

public interface IRepoJugador
{

    int AltaJugador(Jugador jugador);
    IEnumerable<Jugador> TraerJugadoresBasicoXTipoXEquipo(uint idTipo, uint idEquipo);
    int AltaPuntuacion(Puntuacion puntuacion, int idJugador);
    uint AltaTipo(string descripcion); // Cambiado a AltaTipo para usar el SP 'altaTipo'
    
    uint AltaEquipo(string nombre);
    IEnumerable<Equipo> TraerEquipo();
}