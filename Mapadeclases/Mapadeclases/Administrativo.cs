using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapadeclases
{
    public class Administrativo : Empleado
    {
        public void ProcesarDocumentos()
        {
            Console.WriteLine($"{Nombre} está procesando documentos administrativos.");
        }
    }
}