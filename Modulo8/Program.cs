using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulo8
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetDataFromLINQ(GetInputAlumnos1A(), GetInputProfesores1B());
            GetDataFromLINQ(GetHardcodedAlumnos1A(), GetHardcodedProfesores1B());

            Console.ReadLine();
        }

        public static List<AlumnoM8> GetInputAlumnos1A()
        {
            bool getData = true;
            bool getAsignaturas = true;
            List<AlumnoM8> AlumnoList = new List<AlumnoM8>();

            string nombre, apellidos, referencia, aula;
            DateTime fechanacimiento;
            int asigcode;
            List<string> listaasignaturas;
            
            Console.WriteLine("----- Ejercicio 1A: inicio -----");

            while (getData)
            {
                Console.WriteLine("Introducza alumnos. Para finalizar, introduzca un valor blanco en cualquier campo");

                nombre = "";
                apellidos = "";
                referencia = "";
                aula = "";
                asigcode = 0;
                fechanacimiento = DateTime.MinValue;
                listaasignaturas = new List<string>();

                while (getData)
                {
                    Console.Write("Introduzca nombre: ");
                    nombre = Console.ReadLine();
                    getData = !string.IsNullOrWhiteSpace(nombre);
                }

                while (getData)
                {
                    Console.Write("Introduzca apellidos: ");
                    apellidos = Console.ReadLine();
                    getData = !string.IsNullOrWhiteSpace(apellidos);
                }

                while (getData)
                {
                    Console.Write("Introduzca fecha nacimiento: ");
                    getData = DateTime.TryParse(Console.ReadLine(), out fechanacimiento);
                }

                while (getData)
                {
                    Console.Write("Introduzca referencia: ");
                    referencia = Console.ReadLine();
                    getData = !string.IsNullOrWhiteSpace(referencia);
                }

                getAsignaturas = getData;

                while (getAsignaturas)
                {
                    Console.Write("Introduzca asignaturas a partir del siguiente código numérico:\n0 o NAN - Salir\n1 - Mates 1\n2 - Algebra 1\n3 - Fisica 1\n4 - Electrotecnia 1\n5 - Quimica 1");

                    getAsignaturas = int.TryParse(Console.ReadLine(), out asigcode);

                    if (getAsignaturas)
                    {
                        switch (asigcode)
                        {
                            case 1:
                                listaasignaturas.Add("Mates 1");
                                break;
                            case 2:
                                listaasignaturas.Add("Algebra 1");
                                break;
                            case 3:
                                listaasignaturas.Add("Fisca 1");
                                break;
                            case 4:
                                listaasignaturas.Add("Electrotecnia 1");
                                break;
                            case 5:
                                listaasignaturas.Add("Quimica 1");
                                break;
                            case 0:
                            default:
                                getAsignaturas = false;
                                break;
                        }
                    }
                }

                while (getData)
                {
                    Console.Write("Introduzca aula: ");
                    aula = Console.ReadLine();
                    getData = !string.IsNullOrWhiteSpace(aula);
                }

                if (getData)
                {
                    AlumnoList.Add(new AlumnoM8(nombre, apellidos, fechanacimiento, referencia, listaasignaturas, aula));
                    Console.WriteLine("Alumno añadido");
                }
                else
                {
                    Console.WriteLine("Finalizada introducción alumnos");
                }

                Console.WriteLine("Cantidad en lista: " + AlumnoList.Count);
            }

            Console.WriteLine("----- Ejercicio 1A: final -----");

            return AlumnoList;
        }

        public static List<ProfesorM8> GetInputProfesores1B()
        {
            bool getData = true;
            List<ProfesorM8> ProfesorList = new List<ProfesorM8>();

            string nombre, apellidos, referencia, asignatura;
            int asigcode;
            DateTime fechanacimiento;

            Console.WriteLine("----- Ejercicio 1B: inicio -----");

            while (getData)
            {
                nombre = "";
                apellidos = "";
                referencia = "";
                asignatura = "";
                asigcode = 0;
                fechanacimiento = DateTime.MinValue;

                while (getData)
                {
                    Console.Write("Introduzca nombre: ");
                    nombre = Console.ReadLine();
                    getData = !string.IsNullOrWhiteSpace(nombre);
                }

                while (getData)
                {
                    Console.Write("Introduzca apellidos: ");
                    apellidos = Console.ReadLine();
                    getData = !string.IsNullOrWhiteSpace(apellidos);
                }

                while (getData)
                {
                    Console.Write("Introduzca fecha nacimiento: ");
                    getData = DateTime.TryParse(Console.ReadLine(), out fechanacimiento);
                }

                while (getData)
                {
                    Console.Write("Introduzca referencia: ");
                    referencia = Console.ReadLine();
                    getData = !string.IsNullOrWhiteSpace(referencia);
                }

                while (getData)
                {
                    Console.Write("Introduzca asignaturas a partir del siguiente código numérico:\n0 o NAN - Salir\n1 - Mates 1\n2 - Algebra 1\n3 - Fisica 1\n4 - Electrotecnia 1\n5 - Quimica 1");

                    getData = int.TryParse(Console.ReadLine(), out asigcode);

                    if (getData)
                    {
                        switch (asigcode)
                        {
                            case 1:
                                asignatura = "Mates 1";
                                break;
                            case 2:
                                asignatura = "Algebra 1";
                                break;
                            case 3:
                                asignatura = "Fisca 1";
                                break;
                            case 4:
                                asignatura = "Electrotecnia 1";
                                break;
                            case 5:
                                asignatura = "Quimica 1";
                                break;
                            case 0:
                            default:
                                getData = false;
                                break;
                        }
                    }
                }

                if (getData)
                {
                    ProfesorList.Add(new ProfesorM8(nombre, apellidos, fechanacimiento, referencia, asignatura));
                    Console.WriteLine("Profesor añadido");
                }
                else
                {
                    Console.WriteLine("Finalizada introducción profesores");
                }

                Console.WriteLine("Cantidad en lista: " + ProfesorList.Count);
            }
            
            Console.WriteLine("----- Ejercicio 1B: final -----");

            return ProfesorList;
        }

        public static List<AlumnoM8> GetHardcodedAlumnos1A()
        {
            List<AlumnoM8> AlumnosList = new List<AlumnoM8>()
            {
                { new AlumnoM8("Nombre A1", "Apellido A1", DateTime.Now, "Ref 1", new List<string>(){ "Mates 1" , "Algebra 1"},"Aula 1") },
                { new AlumnoM8("Nombre A2", "Apellido A2", DateTime.Now, "Ref 2", new List<string>(){ "Algebra 1", "Electrotecnia 1"},"Aula 2") }
            };

            return AlumnosList;
        }

        public static List<ProfesorM8> GetHardcodedProfesores1B()
        {
            List<ProfesorM8> ProfesoresList = new List<ProfesorM8>()
            {
                {new ProfesorM8("Nombre P1", "Apellido P1", DateTime.Now, "Ref 1", "Mates 1")},
                {new ProfesorM8("Nombre P2", "Apellido P2", DateTime.Now, "Ref 2", "Algebra 2")},
            };

            return ProfesoresList;
        }

        public static void GetDataFromLINQ(List<AlumnoM8> Alumnos, List<ProfesorM8> Profesores)
        {
            var consAlum = from alumno in Alumnos
                           select alumno;

            var consProf = from profesor in Profesores
                           select profesor;

            foreach (var alum in consAlum)
            {
                Console.WriteLine(alum.ToString());
            }

            foreach (var prof in consProf)
            {
                Console.WriteLine(prof.ToString());
            }
        }
    }
}
