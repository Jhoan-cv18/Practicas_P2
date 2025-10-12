namespace Mapadeclases
{
    public class Empleado : MiembroDeLaComunidad
    {
        public string Cargo { get; set; }
        public decimal Salario { get; set; }

        public void MostrarDatosEmpleado()
        {
            Console.WriteLine($"Empleado: {Nombre}, Cargo: {Cargo}, Salario: {Salario}");
        }
    }
}

