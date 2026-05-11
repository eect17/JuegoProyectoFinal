using System;

namespace JuegoTablero
{
    public class Menu
    {
        public int Mostrar()
        {
            Console.Clear();
            Console.WriteLine("===== JUEGO DE TABLERO =====");
            Console.WriteLine("1. Iniciar partida");
            Console.WriteLine("2. Ver reglas");
            Console.WriteLine("3. Ver mejor puntaje");
            Console.WriteLine("4. Salir");

            Console.Write("Opción: ");
            int opcion;
            int.TryParse(Console.ReadLine(), out opcion);

            return opcion;
        }

        public void MostrarReglas()
        {
            Console.Clear();
            Console.WriteLine("REGLAS:");
            Console.WriteLine("- Rey: 1 casilla en cualquier dirección");
            Console.WriteLine("- Torre: línea recta sin saltar piezas");
            Console.WriteLine("- Soldado: avanza 1 y ataca en diagonal");
            Console.ReadLine();
        }
    }
}