using System;

namespace JuegoTablero
{
    public class Login
    {
        public bool IniciarSesion()
        {
            Console.Write("Usuario: ");
            string user = Console.ReadLine();

            Console.Write("Contraseña: ");
            string pass = Console.ReadLine();

            if (user == "admin" && pass == "123456789")
                return true;

            Console.WriteLine("Datos incorrectos");
            Console.ReadLine();
            return false;
        }
    }
}