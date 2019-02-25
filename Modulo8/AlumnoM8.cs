using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulo8
{
    public class AlumnoM8
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Referencia { get; set; }
        public List<string> ListaAsginaturas { get; set; }
        public string Aula { get; set; }

        public AlumnoM8() { }

        public AlumnoM8(string nombre, string apellidos, DateTime fechanacimiento, string referencia, List<string> listaasignaturas , string aula)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            FechaNacimiento = fechanacimiento;
            Referencia = referencia;
            ListaAsginaturas = listaasignaturas;
            Aula = aula;
        }

        public override string ToString()
        {
            return "Datos alumno:\n" +
                "Nombre: " + Nombre + "\n" +
                "Apellidos: " + Apellidos + "\n" +
                "Fecha nacimiento: " + FechaNacimiento.ToString() + "\n" +
                "Referencia: " + Referencia + "\n" +
                "Lista asignaturas:\n" +
                string.Join("\n", ListaAsginaturas.Select((asig) => "- " + asig)) + "\n" +
                "Aula: " + Aula + "\n";
        }
    }
}