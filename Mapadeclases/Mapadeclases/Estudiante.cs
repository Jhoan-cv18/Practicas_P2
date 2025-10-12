using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapadeclases
{
    public class Estudiante : MiembroDeLaComunidad
    {
        public string Carrera { get; set; }

        public void Estudiar()
        {
            Console.WriteLine($"{Nombre} está estudiando la carrera de {Carrera}.");
        }
    }
}
