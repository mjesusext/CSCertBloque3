using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulo8
{
    public class ProfesorM8
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Referencia { get; set; }
        public string Asignatura { get; set; }

        public ProfesorM8() { }

        public ProfesorM8(string nombre, string apellidos, DateTime fechanacimiento, string referencia, string asignatura)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            FechaNacimiento = fechanacimiento;
            Referencia = referencia;
            Asignatura = asignatura;
        }

        public override string ToString()
        {
            return "Datos profesor:\n" +
                "Nombre: " + Nombre + "\n" +
                "Apellidos: " + Apellidos + "\n" +
                "Fecha nacimiento: " + FechaNacimiento.ToString() + "\n" +
                "Referencia: " + Referencia + "\n" +
                "Asignatura: " + Asignatura + "\n";
        }
    }
}