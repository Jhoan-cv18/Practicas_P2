using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapadeclases
{
    public class Administrador : Docente
    {
        public void Gestionar()
        {
            Console.WriteLine($"{Nombre} está gestionando recursos en el área de {Materia}.");
        }
    }
}