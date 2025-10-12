using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapadeclases
{
    public class ExAlumno : MiembroDeLaComunidad
    {
        public int AnioGraduacion { get; set; }

        public void RecordarExperiencia()
        {
            Console.WriteLine($"{Nombre} se graduó en el año {AnioGraduacion}.");
        }
    }
}
