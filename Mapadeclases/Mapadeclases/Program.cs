using System;

namespace Mapadeclases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // PRUEBA CON MAESTRO

            Maestro maestro = new Maestro
            {
                Nombre = "Carlos Pérez",
                Edad = 40,
                Materia = "Matemáticas"
            };

            maestro.MostrarInformacion();
            maestro.ExplicarTema();

            Console.WriteLine("------------------------");

        }
    }
}