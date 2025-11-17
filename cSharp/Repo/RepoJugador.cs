using System.Data;
using Core;
using Core.Repos;
using Dapper;

namespace Dapper
{
    public class RepoJugador : Repo, IRepoJugador
    {
        public RepoJugador(IDbConnection connection) : base(connection){}
        private static readonly string spAltaJugador = "altaJugador"; // Antes: altaFutbolista
        private static readonly string spTraerJugadoresBasico = "traerJugadoresBasicoXTipoXEquipo"; // Antes: traerFutbolistasBasico...
        private static readonly string spAltaTipo = "altaTipo";
        private static readonly string spAltaEquipo = "altaEquipo";
        private static readonly string spTraerEquipo = "traerEquipo";
        private static readonly string spAltaPuntuacion = "altaPuntuacion";

        // --- Operaciones de Jugador ---

        public int AltaJugador(Jugador jugador)
        {
            var p = new DynamicParameters();

            // Parámetros de entrada (IN) - Usando prefijos Un... como en los SP de MySQL
            p.Add("UnNombre", jugador.nombre);
            p.Add("UnApellido", jugador.apellido);
            p.Add("UnApodo", jugador.apodo);
            p.Add("UnFechaNacimiento", jugador.fecha_nacimiento);
            p.Add("UnCotizacion", jugador.cotizacion);
            p.Add("UnidTipo", jugador.id_tipo);
            p.Add("UnidEquipo", jugador.id_equipo);

            // Parámetro de salida (OUT)
            p.Add("AIidJugador", dbType: DbType.Int32, direction: ParameterDirection.Output); // AIidFutbolista -> AIidJugador

            _conexion.Execute(spAltaJugador, p, commandType: CommandType.StoredProcedure);

            // Retorna el ID generado
            return p.Get<int>("AIidJugador");
        }

        public IEnumerable<Jugador> TraerJugadoresBasicoXTipoXEquipo(uint idTipo, uint idEquipo)
        {
            var p = new DynamicParameters();
            p.Add("UnIdTipo", idTipo);
            p.Add("UnIdEquipo", idEquipo);

            return _conexion.Query<Jugador>(
                spTraerJugadoresBasico,
                p,
                commandType: CommandType.StoredProcedure
            ).ToList();
        }

        // --- Operaciones de Puntuación ---

        public int AltaPuntuacion(Puntuacion puntuacion, int idJugador)
        {
            var p = new DynamicParameters();
            p.Add("UnidJugador", idJugador);
            p.Add("UnNota", puntuacion.nota);
            p.Add("UnFechaNumero", puntuacion.fecha_numero);
            p.Add("AIidPuntuacion", dbType: DbType.Int32, direction: ParameterDirection.Output);

            _conexion.Execute(spAltaPuntuacion, p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("AIidPuntuacion");
        }

        // --- Operaciones de Tipo Jugador (Posición) ---

        public uint AltaTipo(string descripcion)
        {
            var p = new DynamicParameters();
            p.Add("UnDescripcion", descripcion);
            p.Add("AIidTipo", dbType: DbType.Int32, direction: ParameterDirection.Output);

            _conexion.Execute(spAltaTipo, p, commandType: CommandType.StoredProcedure);
            return (uint)p.Get<int>("AIidTipo");
        }

        // --- Operaciones de Equipo ---

        public uint AltaEquipo(string nombre)
        {
            var p = new DynamicParameters();
            p.Add("UnNombre", nombre);
            p.Add("AIidEquipo", dbType: DbType.Int32, direction: ParameterDirection.Output);

            _conexion.Execute(spAltaEquipo, p, commandType: CommandType.StoredProcedure);
            return (uint)p.Get<int>("AIidEquipo");
        }

        public IEnumerable<Equipo> TraerEquipo()
        {
            return _conexion.Query<Equipo>(
                spTraerEquipo,
                commandType: CommandType.StoredProcedure
            ).ToList();
        }

    } 
}