using System;

namespace Ejemplo4
{
    class Program
    {
        static void Main(string[] args)
        {
            int tamvec;
            int op;

            Console.WriteLine("Ingrese número de estudiantes en su grupo");
            tamvec = int.Parse(Console.ReadLine());
            Console.Clear();
            Alumno[] Estudiante = new Alumno[tamvec];
            do
            {
                Console.WriteLine("\t******MENÚ******");
                Console.WriteLine("1. Ingresar datos de nuevo estudiante");
                Console.WriteLine("2. Ver listado de estudiantes inscritos");
                Console.WriteLine("3. Reporte de estudiantes");
                Console.WriteLine("4. Salir");

                op = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (op)
                {
                    case 1:
                        Console.WriteLine("SECCIÓN DE INGRESO");
                        for (int i = 0; i < Estudiante.Length; i++)
                        {
                            Estudiante[i] = new Alumno();
                            Estudiante[i].ingresardatos();
                            Console.Clear();
                        }
                        break;

                    case 2:
                        Console.WriteLine("\n------------------------------");
                        Console.WriteLine("\nLISTADO ALUMNOS");
                        Console.WriteLine("\n------------------------------");
                        for (int i = 0; i < Estudiante.Length; i++)
                        {
                            Console.WriteLine("Estudiante número " + (i + 1) + ": ");
                            Console.WriteLine(Estudiante[i].Nombre + " " + Estudiante[i].Apellido);
                            Console.WriteLine("\n");
                        }
                        Console.WriteLine("\n");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        Console.WriteLine("\nREPORTE DE ESTUDIANTES");
                        for (int i = 0; i < Estudiante.Length; i++)
                        {
                            Estudiante[i].mostrar();
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:
                        break;

                    default:
                        Console.WriteLine("\n Escriba opción válida");
                        Console.ReadKey();
                        break;
                }
            } while (op != 4);
            Console.ReadKey();
        }
    }
}