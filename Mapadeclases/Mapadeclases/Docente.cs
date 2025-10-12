using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mapadeclases
{
    public class Docente : Empleado
    {
        public string Materia { get; set; }

        public void Enseñar()
        {
            Console.WriteLine($"{Nombre} está enseñando {Materia}.");
        }
    }
}