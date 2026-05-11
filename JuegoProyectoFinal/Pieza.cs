namespace JuegoProyectoFinal
{
    public class Pieza
    {
        public string tipo;
        public char simbolo;
        public int jugador;

        public Pieza(string tipo, char simbolo, int jugador)
        {
            this.tipo = tipo;
            this.simbolo = simbolo;
            this.jugador = jugador;
        }
    }
}