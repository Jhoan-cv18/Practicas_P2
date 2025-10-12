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

            // Prueba con Estudiante
            Estudiante estudiante = new Estudiante
            {
                Nombre = "Jhoan Castillo",
                Edad = 19,
                Carrera = "Arquitectura"
            };
            estudiante.MostrarInformacion();
            estudiante.Estudiar();

            Console.WriteLine("------------------------");

            // Prueba con ExAlumno
            ExAlumno exalumno = new ExAlumno
            {
                Nombre = "María López",
                Edad = 25,
                AnioGraduacion = 2022
            };
            exalumno.MostrarInformacion();
            exalumno.RecordarExperiencia();

            Console.WriteLine("\n✅ Pruebas completadas correctamente.");

        }
    }
}