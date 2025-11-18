using System.Media;

namespace el_dt_by_menardi_y_tello
{
    public static class MusicaGlobal
    {
        public static SoundPlayer player;
        public static bool Iniciada = false;
        public static bool Sonando = true;

        public static void Iniciar()
        {
            if (Iniciada) return; // evita reiniciar si ya está sonando

            //   string rutaMusica = "D:\\musica\\musicap.wav";
            //  player = new SoundPlayer(rutaMusica);
            //   player.PlayLooping();
            //   Iniciada = true;
            //  Sonando = true;
        }

        public static void Detener()
        {
            player?.Stop();
            Sonando = false;
        }

        public static void Reanudar()
        {
            player?.PlayLooping();
            Sonando = true;
        }
    }
}
