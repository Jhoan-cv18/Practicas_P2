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
           
            // Prueba con Administrador
            Administrador admin = new Administrador
            {
                Nombre = "Laura Gómez",
                Edad = 35,
                Materia = "Informática"
            };
            admin.MostrarInformacion();
            admin.Gestionar();

            Console.WriteLine("------------------------");

            // Prueba con Administrativo
            Administrativo adm = new Administrativo
            {
                Nombre = "Pedro Ramírez",
                Edad = 29,
                Cargo = "Secretario",
                Salario = 25000
            };
            adm.MostrarInformacion();
            adm.ProcesarDocumentos();

            Console.WriteLine("------------------------");

        }
    }
}