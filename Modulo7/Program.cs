using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Modulo7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio1();
            //Ejercicio2();
            //Ejercicio3();
            //Ejercicio4A();
            //Ejercicio4B();
            //Ejercicio4C();
            Ejercicio5();

            Console.ReadLine();
        }

        public static void Ejercicio1()
        {
            Console.WriteLine("----- Ejercicio 1: inicio -----");

            bool okInput = true;
            int maxVal, minVal;
            double avgVal;
            ArrayList arrlist = new ArrayList();

            Console.WriteLine("Introduzca números mayores o iguales a cero. Si introduce valor negativo se procede al cálculo del valor máximo, mínimo, media y cantidad de elementos introducidos");

            while (true)
            {
                int inputNum;
                Console.Write("Introduzca valor: ");
                okInput = int.TryParse(Console.ReadLine(), out inputNum);

                if (okInput)
                {
                    if (inputNum < 0)
                    {
                        break;
                    }

                    arrlist.Add(inputNum);
                }
                else
                {
                    Console.WriteLine("Valor de tipo no entero. Reinténtelo");
                }
            }

            maxVal = (int)arrlist[0];
            minVal = (int)arrlist[0];
            avgVal = 0D;

            for (int i = 1; i < arrlist.Count; i++)
            {
                int tmp_val = (int)arrlist[i];

                maxVal = tmp_val > maxVal ? tmp_val : maxVal;
                minVal = tmp_val < minVal ? tmp_val : minVal;
                avgVal += tmp_val;
            }

            avgVal /= arrlist.Count;

            Console.WriteLine("Valor mínimo: " + minVal);
            Console.WriteLine("Valor máximo: " + maxVal);
            Console.WriteLine("Valor medio: " + avgVal);
            Console.WriteLine("----- Ejercicio 1: final -----");
        }

        public static void Ejercicio2()
        {
            Console.WriteLine("----- Ejercicio 2: inicio -----");

            bool okInput = true;
            int pos = 1, maxLen = 0, minLen = 0;
            double avgLen = 0D;
            Hashtable hashTbl = new Hashtable();

            Console.WriteLine("Introduzca nombres de usuario. Cuando se introduzca valor en blanco se parará de añadir nombres");

            while (okInput)
            {
                string strInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(strInput))
                {
                    break;
                }
                else
                {
                    hashTbl.Add(pos++, strInput);
                }
            }

            foreach (DictionaryEntry item in hashTbl)
            {
                string tmp_val = (string)item.Value;
                maxLen = tmp_val.Length > maxLen ? tmp_val.Length : maxLen;
                minLen = tmp_val.Length < minLen ? tmp_val.Length : minLen;
                avgLen += tmp_val.Length;
            }

            avgLen /= hashTbl.Count;

            Console.WriteLine("Longitud nombre más largo: " + maxLen);
            Console.WriteLine("Longitud nombre más corto: " + minLen);
            Console.WriteLine("Cantidad nombres: " + hashTbl.Count);

            while (true)
            {
                Console.WriteLine("Introduzca posición que desea recuperar (en mayuscuylas). En caso de querer finalizar, introduzca 0");

                int inputNum;
                okInput = int.TryParse(Console.ReadLine(), out inputNum);

                if (okInput)
                {
                    if (inputNum == 0)
                    {
                        break;
                    }
                    else if (inputNum < 0)
                    {
                        Console.WriteLine("Valor introducido no es positivo. Reinténtelo");
                    }
                    else
                    {
                        string temp_val = ((string)hashTbl[inputNum]).ToUpper();
                        string temp_long = string.Empty;

                        if (temp_val.Length > avgLen)
                        {
                            temp_long = "superior";
                        }
                        else if (temp_val.Length < avgLen)
                        {
                            temp_long = "inferior";
                        }
                        else
                        {
                            temp_long = "igual";
                        }

                        Console.WriteLine("Valor recuperado: " + temp_val);
                        Console.WriteLine("Longitud respecto media: " + temp_long);
                    }
                }
                else
                {
                    Console.WriteLine("Valor introducido no numérico. Reinténtelo");
                }

            }

            Console.WriteLine("----- Ejercicio 2: final -----");
        }

        public static void Ejercicio3()
        {
            Console.WriteLine("----- Ejercicio 3: inicio -----");

            bool next_action = true;
            Queue q = new Queue();

            while (next_action)
            {
                Console.WriteLine("Seleccione modo:\n1 - Añadir persona\n2 - Dar paso a siguiente en cola\n3 - Finalizar programa ");

                int mode = 0;
                bool okInput = int.TryParse(Console.ReadLine(), out mode);

                if (!okInput)
                {
                    Console.WriteLine("Entrada diferente de valor entero");
                    continue;
                }

                switch (mode)
                {
                    case 1:
                        string nombre = "", apellidos = "", dni = "";

                        while (string.IsNullOrWhiteSpace(nombre))
                        {
                            Console.Write("Introduzca nombre: ");
                            nombre = Console.ReadLine();
                        }

                        while (string.IsNullOrWhiteSpace(apellidos))
                        {
                            Console.Write("Introduzca apellidos: ");
                            apellidos = Console.ReadLine();
                        }

                        while (string.IsNullOrWhiteSpace(dni))
                        {
                            Console.Write("Introduzca DNI: ");
                            dni = Console.ReadLine();
                        }

                        q.Enqueue(new PersonaM7(nombre, apellidos, dni));

                        Console.WriteLine("Personas en cola: " + q.Count.ToString());
                        break;
                    case 2:
                        if (q.Count > 0)
                        {
                            PersonaM7 sel_pers = (PersonaM7)q.Dequeue();
                            Console.WriteLine("Siguiente turno para: " + sel_pers.ToString());
                        }

                        Console.WriteLine("Personas en cola: " + q.Count.ToString());
                        break;
                    case 3:
                        next_action = false;

                        break;
                    default:
                        Console.WriteLine("Valor fuera de rango.");
                        break;
                }
            }

            Console.WriteLine("----- Ejercicio 3: final -----");
        }

        public static void Ejercicio4A()
        {
            Console.WriteLine("----- Ejercicio 4A: inicio -----");

            bool okInput = true;
            int maxVal, minVal;
            double avgVal;
            List<int> list = new List<int>();

            Console.WriteLine("Introduzca números mayores o iguales a cero. Si introduce valor negativo se procede al cálculo del valor máximo, mínimo, media y cantidad de elementos introducidos");

            while (true)
            {
                int inputNum;
                Console.Write("Introduzca valor: ");
                okInput = int.TryParse(Console.ReadLine(), out inputNum);

                if (okInput)
                {
                    if (inputNum < 0)
                    {
                        break;
                    }

                    list.Add(inputNum);
                }
                else
                {
                    Console.WriteLine("Valor de tipo no entero. Reinténtelo");
                }
            }

            maxVal = list[0];
            minVal = list[0];
            avgVal = 0D;

            for (int i = 1; i < list.Count; i++)
            {
                maxVal = list[i] > maxVal ? list[i] : maxVal;
                minVal = list[i] < minVal ? list[i] : minVal;
                avgVal += list[i];
            }

            avgVal /= list.Count;

            Console.WriteLine("Valor mínimo: " + minVal);
            Console.WriteLine("Valor máximo: " + maxVal);
            Console.WriteLine("Valor medio: " + avgVal);
            Console.WriteLine("----- Ejercicio 4A: final -----");
        }

        public static void Ejercicio4B()
        {
            Console.WriteLine("----- Ejercicio 4B: inicio -----");

            bool okInput = true;
            int pos = 1, maxLen = 0, minLen = 0;
            double avgLen = 0D;
            Dictionary<int, string> dictTbl = new Dictionary<int, string>();

            Console.WriteLine("Introduzca nombres de usuario. Cuando se introduzca valor en blanco se parará de añadir nombres");

            while (okInput)
            {
                string strInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(strInput))
                {
                    break;
                }
                else
                {
                    dictTbl.Add(pos++, strInput);
                }
            }

            foreach (KeyValuePair<int, string> item in dictTbl)
            {
                maxLen = item.Value.Length > maxLen ? item.Value.Length : maxLen;
                minLen = item.Value.Length < minLen ? item.Value.Length : minLen;
                avgLen += item.Value.Length;
            }

            avgLen /= dictTbl.Count;

            Console.WriteLine("Longitud nombre más largo: " + maxLen);
            Console.WriteLine("Longitud nombre más corto: " + minLen);
            Console.WriteLine("Cantidad nombres: " + dictTbl.Count);

            while (true)
            {
                Console.WriteLine("Introduzca posición que desea recuperar (en mayuscuylas). En caso de querer finalizar, introduzca 0");

                int inputNum;
                okInput = int.TryParse(Console.ReadLine(), out inputNum);

                if (okInput)
                {
                    if (inputNum == 0)
                    {
                        break;
                    }
                    else if (inputNum < 0)
                    {
                        Console.WriteLine("Valor introducido no es positivo. Reinténtelo");
                    }
                    else
                    {
                        string temp_long = string.Empty;

                        if (dictTbl[inputNum].Length > avgLen)
                        {
                            temp_long = "superior";
                        }
                        else if (dictTbl[inputNum].Length < avgLen)
                        {
                            temp_long = "inferior";
                        }
                        else
                        {
                            temp_long = "igual";
                        }

                        Console.WriteLine("Valor recuperado: " + dictTbl[inputNum].ToUpper());
                        Console.WriteLine("Longitud respecto media: " + temp_long);
                    }
                }
                else
                {
                    Console.WriteLine("Valor introducido no numérico. Reinténtelo");
                }

            }

            Console.WriteLine("----- Ejercicio 4B: final -----");
        }

        public static void Ejercicio4C()
        {
            Console.WriteLine("----- Ejercicio 4C: inicio -----");

            bool next_action = true;
            Queue<PersonaM7> q = new Queue<PersonaM7>();

            while (next_action)
            {
                Console.WriteLine("Seleccione modo:\n1 - Añadir persona\n2 - Dar paso a siguiente en cola\n3 - Finalizar programa ");

                int mode = 0;
                bool okInput = int.TryParse(Console.ReadLine(), out mode);

                if (!okInput)
                {
                    Console.WriteLine("Entrada diferente de valor entero");
                    continue;
                }

                switch (mode)
                {
                    case 1:
                        string nombre = "", apellidos = "", dni = "";

                        while (string.IsNullOrWhiteSpace(nombre))
                        {
                            Console.Write("Introduzca nombre: ");
                            nombre = Console.ReadLine();
                        }

                        while (string.IsNullOrWhiteSpace(apellidos))
                        {
                            Console.Write("Introduzca apellidos: ");
                            apellidos = Console.ReadLine();
                        }

                        while (string.IsNullOrWhiteSpace(dni))
                        {
                            Console.Write("Introduzca DNI: ");
                            dni = Console.ReadLine();
                        }

                        q.Enqueue(new PersonaM7(nombre, apellidos, dni));

                        Console.WriteLine("Personas en cola: " + q.Count.ToString());
                        break;
                    case 2:
                        if (q.Count > 0)
                        {
                            Console.WriteLine("Siguiente turno para: " + q.Dequeue().ToString());
                        }

                        Console.WriteLine("Personas en cola: " + q.Count.ToString());
                        break;
                    case 3:
                        next_action = false;

                        break;
                    default:
                        Console.WriteLine("Valor fuera de rango.");
                        break;
                }
            }

            Console.WriteLine("----- Ejercicio 4C: final -----");
        }

        public static void Ejercicio5()
        {
            Console.WriteLine("----- Ejercicio 5: inicio -----");

            bool next_action = true;
            PersonaM7Collection PersColl = new PersonaM7Collection();

            while (next_action)
            {
                Console.WriteLine("Seleccione modo:\n1 - Añadir persona\n2 - Modificar persona\n3 - Ver persona\n4 - Eliminar persona\n5 - Buscar persona\n6 - Finalizar programa ");

                int mode = 0;
                int pos = 0;
                int confirm_delete = 0;
                string nombre = "", apellidos = "", dni = "", searchtxt = "";
                bool okInput = false;

                while (!okInput)
                {
                    okInput = int.TryParse(Console.ReadLine(), out mode);

                    if (!okInput)
                    {
                        Console.WriteLine("Entrada diferente de valor entero");
                    }
                }

                //Resetear variable
                okInput = false;

                switch (mode)
                {
                    //Añadir
                    case 1:
                        while (string.IsNullOrWhiteSpace(nombre))
                        {
                            Console.Write("Introduzca nombre: ");
                            nombre = Console.ReadLine();
                        }

                        while (string.IsNullOrWhiteSpace(apellidos))
                        {
                            Console.Write("Introduzca apellidos: ");
                            apellidos = Console.ReadLine();
                        }

                        while (string.IsNullOrWhiteSpace(dni))
                        {
                            Console.Write("Introduzca DNI: ");
                            dni = Console.ReadLine();
                        }

                        PersColl.Add(new PersonaM7(nombre, apellidos, dni));

                        break;
                    //Modificar
                    case 2:

                        while (!okInput)
                        {
                            Console.Write("Introduzca posición: ");
                            okInput = int.TryParse(Console.ReadLine(), out pos);

                            if (!okInput)
                            {
                                Console.WriteLine("Entrada diferente de valor entero");
                            }
                            else if (pos > PersColl.Count - 1)
                            {
                                Console.WriteLine("Posición fuera de rango");
                                okInput = false;
                            }
                        }

                        //Resetear variable
                        okInput = false;

                        while (string.IsNullOrWhiteSpace(nombre))
                        {
                            Console.Write("Introduzca nombre: ");
                            nombre = Console.ReadLine();
                        }

                        while (string.IsNullOrWhiteSpace(apellidos))
                        {
                            Console.Write("Introduzca apellidos: ");
                            apellidos = Console.ReadLine();
                        }

                        while (string.IsNullOrWhiteSpace(dni))
                        {
                            Console.Write("Introduzca DNI: ");
                            dni = Console.ReadLine();
                        }

                        PersColl[pos].Nombre = nombre;
                        PersColl[pos].Apellidos = apellidos;
                        PersColl[pos].DNI = dni;

                        break;
                    //Ver
                    case 3:

                        while (!okInput)
                        {
                            Console.Write("Introduzca posición: ");
                            okInput = int.TryParse(Console.ReadLine(), out pos);

                            if (!okInput)
                            {
                                Console.WriteLine("Entrada diferente de valor entero");
                            }
                            else if (pos > PersColl.Count - 1)
                            {
                                Console.WriteLine("Posición fuera de rango");
                                okInput = false;
                            }
                        }

                        //Resetear variable
                        okInput = false;

                        Console.WriteLine(PersColl[pos].ToString());

                        break;
                    //Eliminar
                    case 4:

                        while (!okInput)
                        {
                            Console.Write("Introduzca posición: ");
                            okInput = int.TryParse(Console.ReadLine(), out pos);

                            if (!okInput)
                            {
                                Console.WriteLine("Entrada diferente de valor entero");
                            }
                            else if (pos > PersColl.Count - 1)
                            {
                                Console.WriteLine("Posición fuera de rango");
                                okInput = false;
                            }
                        }

                        //Resetear variable
                        okInput = false;

                        while (!okInput)
                        {
                            Console.Write("Introduzca 1 para confirmar eliminación: ");
                            okInput = int.TryParse(Console.ReadLine(), out confirm_delete);

                            if (!okInput)
                            {
                                Console.WriteLine("Entrada diferente de valor entero");
                            }
                            else if (confirm_delete == 1)
                            {
                                PersColl.RemoveAt(pos);
                                Console.WriteLine("Persona eliminada");
                            }
                        }

                        break;
                    //Buscar
                    case 5:
                        Console.Write("Introduzca texto para busqueda (nombre, apellido o DNI): ");
                        searchtxt = Console.ReadLine();

                        foreach (PersonaM7 item in PersColl)
                        {
                            if (item.Nombre.Contains(searchtxt) ||
                               item.Apellidos.Contains(searchtxt) ||
                               item.DNI.Contains(searchtxt))
                            {
                                Console.WriteLine("Resultado encontrado: " + item.ToString());
                            }
                        }

                        break;
                    //Finalizar
                    case 6:
                        next_action = false;
                        break;
                    default:
                        Console.WriteLine("Valor fuera de rango. Reinténtelo");
                        break;
                }
            }

            Console.WriteLine("----- Ejercicio 5: final -----");
        }
    }
}
