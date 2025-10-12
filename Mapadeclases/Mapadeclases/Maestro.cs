using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapadeclases
{
    public class Maestro : Docente
    {
        public void ExplicarTema()
        {
            Console.WriteLine($"{Nombre} está explicando el tema de {Materia}.");
        }
    }
}