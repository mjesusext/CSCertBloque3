using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulo7
{
    public class PersonaM7
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }

        public PersonaM7(string nombre, string apellidos, string dni)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            DNI = dni;
        }

        public override string ToString()
        {
            return DNI + " - " + Apellidos + ", " + Nombre;
        }
    }
}
