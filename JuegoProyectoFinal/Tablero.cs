using JuegoTablero;

namespace JuegoProyectoFinal
{
    public class Tablero
    {
        public Pieza[,] casillas = new Pieza[8, 8];

        public void Inicializar()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    casillas[i, j] = null;

            // Rey centrado
            casillas[7, 4] = new Pieza("Rey", ' ', 1);
            casillas[0, 4] = new Pieza("Rey", ' ', 2);

            // 2 Torres por jugador
            casillas[7, 0] = new Pieza("Torre", ' ', 1);
            casillas[7, 7] = new Pieza("Torre", ' ', 1);
            casillas[0, 0] = new Pieza("Torre", ' ', 2);
            casillas[0, 7] = new Pieza("Torre", ' ', 2);

            // 4 Soldados por jugador
            int[] cols = { 2, 3, 4, 5 };
            foreach (int j in cols)
            {
                casillas[6, j] = new Pieza("Soldado", ' ', 1);
                casillas[1, j] = new Pieza("Soldado", ' ', 2);
            }
        }
    }
}