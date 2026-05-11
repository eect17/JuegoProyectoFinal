using JuegoTablero;
using System;

namespace JuegoProyectoFinal
{
    public class Juego
    {
        public Tablero tablero = new Tablero();
        public Jugador j1;
        public Jugador j2;
        public int turno = 1;

        public int puntosJ1 = 0;
        public int puntosJ2 = 0;

        public static int mejorPuntaje = 0;
        public static string mejorJugador = "";

        public int filaSeleccionada = -1;
        public int colSeleccionada = -1;
        public bool haySeleccion = false;

        public void Iniciar(string nombreJ1, string nombreJ2)
        {
            j1 = new Jugador(1, nombreJ1);
            j2 = new Jugador(2, nombreJ2);
            tablero.Inicializar();
            turno = 1;
            puntosJ1 = 0;
            puntosJ2 = 0;
            haySeleccion = false;
        }

        public string IntentarMover(int fila, int col)
        {
            if (!haySeleccion)
            {
                Pieza p = tablero.casillas[fila, col];
                if (p == null) return "No hay pieza en esa casilla.";
                if (p.jugador != turno) return "Esa pieza no es tuya.";

                filaSeleccionada = fila;
                colSeleccionada = col;
                haySeleccion = true;
                return null;
            }
            else
            {
                int f1 = filaSeleccionada;
                int c1 = colSeleccionada;
                int f2 = fila;
                int c2 = col;

                haySeleccion = false;
                filaSeleccionada = -1;
                colSeleccionada = -1;

                if (f1 == f2 && c1 == c2) return "Selección cancelada.";

                Pieza pieza = tablero.casillas[f1, c1];

                if (tablero.casillas[f2, c2] != null && tablero.casillas[f2, c2].jugador == turno)
                {
                    filaSeleccionada = f2;
                    colSeleccionada = c2;
                    haySeleccion = true;
                    return "Nueva pieza seleccionada.";
                }

                if (!MovimientoValido(pieza, f1, c1, f2, c2))
                    return "Movimiento inválido para " + pieza.tipo + ".";

                string mensaje = "";

                if (tablero.casillas[f2, c2] != null)
                {
                    Pieza comida = tablero.casillas[f2, c2];
                    int puntos = 10;
                    string extra = "";

                    if (comida.tipo == "Rey")
                    {
                        puntos += 50;
                        extra = " ¡Capturaste el REY! +60 pts";
                    }

                    if (turno == 1) puntosJ1 += puntos;
                    else puntosJ2 += puntos;

                    mensaje = "¡Captura!" + extra;
                }

                tablero.casillas[f2, c2] = pieza;
                tablero.casillas[f1, c1] = null;

                string ganador = VerificarGanador();
                if (ganador != null)
                {
                    int pts = (ganador == j1.nombre) ? puntosJ1 : puntosJ2;
                    if (pts > mejorPuntaje)
                    {
                        mejorPuntaje = pts;
                        mejorJugador = ganador;
                    }
                    return "GANADOR:" + ganador;
                }

                turno = (turno == 1) ? 2 : 1;
                return mensaje == "" ? null : mensaje;
            }
        }

        public bool MovimientoValido(Pieza p, int f1, int c1, int f2, int c2)
        {
            int df = f2 - f1;
            int dc = c2 - c1;

            if (p.tipo == "Soldado")
            {
                if (p.jugador == 1 && df == -1 && dc == 0 && tablero.casillas[f2, c2] == null)
                    return true;
                if (p.jugador == 2 && df == 1 && dc == 0 && tablero.casillas[f2, c2] == null)
                    return true;
                if (Math.Abs(dc) == 1 && Math.Abs(df) == 1 && tablero.casillas[f2, c2] != null
                    && tablero.casillas[f2, c2].jugador != p.jugador)
                    return true;
                return false;
            }

            if (p.tipo == "Torre")
            {
                if (df == 0 || dc == 0)
                    return CaminoLibre(f1, c1, f2, c2);
                return false;
            }

            if (p.tipo == "Rey")
            {
                return Math.Abs(df) <= 1 && Math.Abs(dc) <= 1;
            }

            return false;
        }

        public bool CaminoLibre(int f1, int c1, int f2, int c2)
        {
            int pasoF = Math.Sign(f2 - f1);
            int pasoC = Math.Sign(c2 - c1);
            int f = f1 + pasoF;
            int c = c1 + pasoC;

            while (f != f2 || c != c2)
            {
                if (tablero.casillas[f, c] != null) return false;
                f += pasoF;
                c += pasoC;
            }
            return true;
        }

        public string VerificarGanador()
        {
            bool hayPiezasJ1 = false;
            bool hayPiezasJ2 = false;
            bool rey1 = false;
            bool rey2 = false;

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    Pieza p = tablero.casillas[i, j];
                    if (p == null) continue;
                    if (p.jugador == 1) { hayPiezasJ1 = true; if (p.tipo == "Rey") rey1 = true; }
                    else { hayPiezasJ2 = true; if (p.tipo == "Rey") rey2 = true; }
                }

            if (!rey2 || !hayPiezasJ2) return j1.nombre;
            if (!rey1 || !hayPiezasJ1) return j2.nombre;
            return null;
        }
    }
}