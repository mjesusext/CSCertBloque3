using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Modulo8
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetDataFromLINQ(GetInputAlumnos1A(), GetInputProfesores1B());
            //GetDataFromLINQ_QuerySyntax(GetHardcodedAlumnos1A(), GetHardcodedProfesores1B());
            GetDataFromLINQ_FluentSyntax(GetHardcodedAlumnos1A(), GetHardcodedProfesores1B());

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
                { new AlumnoM8("ANombre A1", "Apellido A1", new DateTime(1989,1,1), "Ref 1", new List<string>(){ "Mates 1" , "Algebra 1"},"Aula 1") },
                { new AlumnoM8("Nombre A2", "Apellido A2", new DateTime(1990,1,1), "Ref 2", new List<string>(){ "Algebra 1" , "Electrotecnia 1", "Mates 1", "Fisica 1"},"Aula 2") },
                { new AlumnoM8("Nombre A3", "Apellido A3", new DateTime(1991,1,1), "Ref 3", new List<string>(){ "Algebra 1" , "Electrotecnia 1"},"Aula 3") },
                { new AlumnoM8("Nombre A4", "Apellido A4", new DateTime(1992,1,1), "Ref 4", new List<string>(){ "Algebra 1" , "Electrotecnia 1"},"Aula 4") }
            };

            return AlumnosList;
        }

        public static List<ProfesorM8> GetHardcodedProfesores1B()
        {
            List<ProfesorM8> ProfesoresList = new List<ProfesorM8>()
            {
                {new ProfesorM8("Nombre P1", "Apellido P1", new DateTime(1960,1,1), "Ref 1", "Mates 1")},
                {new ProfesorM8("Nombre P2", "Apellido P2", new DateTime(1961,1,1), "Ref 2", "Algebra 1")},
                {new ProfesorM8("Nombre P3", "Apellido P3", new DateTime(1962,1,1), "Ref 3", "Electrotecnia 1")},
                {new ProfesorM8("Nombre P4", "Apellido P4", new DateTime(1963,1,1), "Ref 4", "Fisica 1")}
            };

            return ProfesoresList;
        }

        public static void GetDataFromLINQ_QuerySyntax(List<AlumnoM8> Alumnos, List<ProfesorM8> Profesores)
        {
            //Numero total de alumnos
            var cons1 = from alumno in Alumnos
                        select alumno;
            Console.WriteLine("----- EJ1: total alumnos -----");
            Console.WriteLine("Total alumnos: {0}", cons1.Count());
            
            //Alumnos que tienen mas de 3 asignaturas, ordenado por apellidos
            var cons2 = from alumno in Alumnos
                        where alumno.ListaAsignaturas.Count > 3
                        orderby alumno.Apellidos
                        select alumno;

            Console.WriteLine("----- EJ2: Alumnos que tienen mas de 3 asignaturas, ordenado por apellidos -----");
            foreach (var item in cons2)
            {
                Console.WriteLine("- {0} {1}", item.Nombre, item.Apellidos);
            }

            //Profesores y alumnos adscritos a sus clases
            var cons3 = from profesor in Profesores
                        from alumno in Alumnos
                        where alumno.ListaAsignaturas.Contains(profesor.Asignatura)
                        group alumno by profesor;

            Console.WriteLine("----- EJ3: Profesores y alumnos adscritos a sus clases -----");
            foreach (var profs in cons3)
            {
                Console.WriteLine("Alumnos pertenecientes al profesor: {0} {1}", profs.Key.Nombre, profs.Key.Apellidos);

                foreach (var alu in profs)
                {
                    Console.WriteLine("- " + alu.Nombre + " " + alu.Apellidos);
                }
            }

            //Media edad, edad maxima y minima de alumnos y profesores juntos
            var cons4 = from alumno in Alumnos
                        select new
                        {
                            Nombre = alumno.Nombre,
                            Apellidos = alumno.Apellidos,
                            Edad = DateTime.Now.Subtract(alumno.FechaNacimiento).TotalDays / 365.25
                        };

            var cons4B = cons4.Union(
                            from profesor in Profesores
                            select new
                            {
                                Nombre = profesor.Nombre,
                                Apellidos = profesor.Apellidos,
                                Edad = DateTime.Now.Subtract(profesor.FechaNacimiento).TotalDays / 365.25 }
                            );

            Console.WriteLine("----- EJ4: Edad maxima, minima y media entre profesores y alumnos -----");

            Console.WriteLine("Edad media: {0}\nEdad máxima: {1}\nEdad mínima: {2}", cons4B.Average((x) => x.Edad), cons4B.Max((x) => x.Edad), cons4B.Min((x) => x.Edad));

            //Lista completa de personas ordenada por fecha de nacimiento
            //Usar resultado de cons4 -> cons4B
            var cons5 = from persona in cons4B
                        orderby persona.Edad
                        select persona;

            Console.WriteLine("----- EJ5: lista de alumnos y profesores ordenada por edad -----");

            foreach (var item in cons5)
            {
                Console.WriteLine("- {0} {1}", item.Nombre, item.Apellidos);
            }

            //Lista asignaturas que tienen alumnos indicando alumnos totales por asignatura
            //Versionamos la consulta 3
            var cons6 = from profesor in Profesores
                        from alumno in Alumnos
                        where alumno.ListaAsignaturas.Contains(profesor.Asignatura)
                        group alumno by profesor.Asignatura;

            Console.WriteLine("----- EJ6: Asignaturas y cantidad de matriculados por cada una -----");
            foreach (var item in cons6)
            {
                Console.WriteLine("Asignatura {0} --> {1}", item.Key, item.Count());
            }

            //Mostrar alumnos cuyo nombre empiece por vocal

            Console.WriteLine("----- EJ7: Alumnos con nombre que empiece en vocal -----");
            var cons7 = from alumno in Alumnos
                        where Regex.IsMatch(alumno.Nombre, @"^[aeiouAEIOU][\w]*")
                        select alumno;

            foreach (var item in cons7)
            {
                Console.WriteLine("- {0} {1}", item.Nombre, item.Apellidos);
            }

            //Mostrar los nombres diferentes que hay entre alumnos y profesores
            Console.WriteLine("----- EJ7: Nombres de pila distintos entre profesores y alumnos -----");
            var cons8 = (from alumno in Alumnos
                         select alumno.Nombre)
                        .Union
                        (from profesor in Profesores
                         select profesor.Nombre)
                         .Distinct();

            foreach (var item in cons8)
            {
                Console.WriteLine("- {0}", item);
            }
        }

        public static void GetDataFromLINQ_FluentSyntax(List<AlumnoM8> Alumnos, List<ProfesorM8> Profesores)
        {
            //Numero total de alumnos
            var cons1 = Alumnos.Count();
            Console.WriteLine("----- EJ1: total alumnos -----");
            Console.WriteLine("Total alumnos: {0}", cons1);

            //Alumnos que tienen mas de 3 asignaturas, ordenado por apellidos
            var cons2 = Alumnos
                        .Where(x => x.ListaAsignaturas.Count > 3)
                        .OrderBy(x => x.Apellidos);

            Console.WriteLine("----- EJ2: Alumnos que tienen mas de 3 asignaturas, ordenado por apellidos -----");
            foreach (var item in cons2)
            {
                Console.WriteLine("- {0} {1}", item.Nombre, item.Apellidos);
            }

            //Profesores y alumnos adscritos a sus clases
            var cons3 = Profesores.SelectMany(prof => Alumnos, (prof, alu) => new { prof, alu })
                        .Where(x => x.alu.ListaAsignaturas.Contains(x.prof.Asignatura))
                        .GroupBy(x => x.prof, x => x.alu);

            Console.WriteLine("----- EJ3: Profesores y alumnos adscritos a sus clases -----");
            foreach (var profs in cons3)
            {
                Console.WriteLine("Alumnos pertenecientes al profesor: {0} {1}", profs.Key.Nombre, profs.Key.Apellidos);

                foreach (var alu in profs)
                {
                    Console.WriteLine("- " + alu.Nombre + " " + alu.Apellidos);
                }
            }

            //Media edad, edad maxima y minima de alumnos y profesores juntos
            var cons4B = Alumnos.Select(
                        x => new
                        {
                            Nombre = x.Nombre,
                            Apellidos = x.Apellidos,
                            Edad = DateTime.Now.Subtract(x.FechaNacimiento).TotalDays / 365.25
                        }
                        )
                        .Union(Profesores.Select
                            (
                                x => new
                                {
                                    Nombre = x.Nombre,
                                    Apellidos = x.Apellidos,
                                    Edad = DateTime.Now.Subtract(x.FechaNacimiento).TotalDays / 365.25
                                }
                            )
                        );

            Console.WriteLine("----- EJ4: Edad maxima, minima y media entre profesores y alumnos -----");

            Console.WriteLine("Edad media: {0}\nEdad máxima: {1}\nEdad mínima: {2}", cons4B.Average((x) => x.Edad), cons4B.Max((x) => x.Edad), cons4B.Min((x) => x.Edad));

            //Lista completa de personas ordenada por fecha de nacimiento
            //Usar resultado de cons4 -> cons4B
            var cons5 = cons4B.OrderBy((x) => x.Edad);
                        
            Console.WriteLine("----- EJ5: lista de alumnos y profesores ordenada por edad -----");

            foreach (var item in cons5)
            {
                Console.WriteLine("- {0} {1}", item.Nombre, item.Apellidos);
            }

            //Lista asignaturas que tienen alumnos indicando alumnos totales por asignatura
            //Versionamos la consulta 3

            var cons6 = Profesores.SelectMany(prof => Alumnos, (prof, alu) => new { prof, alu })
                        .Where(x => x.alu.ListaAsignaturas.Contains(x.prof.Asignatura))
                        .GroupBy(x => x.prof.Asignatura, x => x.alu);

            Console.WriteLine("----- EJ6: Asignaturas y cantidad de matriculados por cada una -----");
            foreach (var item in cons6)
            {
                Console.WriteLine("Asignatura {0} --> {1}", item.Key, item.Count());
            }

            //Mostrar alumnos cuyo nombre empiece por vocal

            Console.WriteLine("----- EJ7: Alumnos con nombre que empiece en vocal -----");
            var cons7 = Alumnos.Where(x => Regex.IsMatch(x.Nombre, @"^[aeiouAEIOU][\w]*"));

            foreach (var item in cons7)
            {
                Console.WriteLine("- {0} {1}", item.Nombre, item.Apellidos);
            }

            //Mostrar los nombres diferentes que hay entre alumnos y profesores
            Console.WriteLine("----- EJ7: Nombres de pila distintos entre profesores y alumnos -----");
            var cons8 = Alumnos.Select(x => x.Nombre)
                        .Union
                        (Profesores.Select(x => x.Nombre))
                         .Distinct();

            foreach (var item in cons8)
            {
                Console.WriteLine("- {0}", item);
            }
        }
    }
}
