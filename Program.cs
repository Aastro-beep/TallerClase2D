using System;
using System.Collections.Generic;

namespace TallerClase
{
    internal class Program
    {
        static List<Salon> salones = new List<Salon>();

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("¡Seleccione una opción!: ");
                Console.WriteLine("1.Crear un nuevo salon");
                Console.WriteLine("2.Seleccionar un salon creado y operar");
                Console.WriteLine("3.Exit");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        SalonCreado();
                        break;
                    case "2":
                        OperarSalon();
                        break;
                    case "3":
                        exit = true;
                        Console.WriteLine("¡Vuelva pronto!");
                        break;
                    default:
                        Console.WriteLine("Reintente de nuevo...");
                        Console.ReadLine();
                        break;
                }
            }
        }
        static void SalonCreado()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido a CrearSalon");
            Console.Write("Ingrese el nombre del salón: ");
            string nombre = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                salones.Add(new Salon(nombre));
                Console.WriteLine($"¡Salón '{nombre}' creado!");
            }
            else
            {
                Console.WriteLine("Reintente de nuevo...");
            }
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        static void OperarSalon()
        {
            Console.Clear();
            if (salones.Count == 0)
            {
                Console.WriteLine("¡No hay salones registrados!");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Lista de Salones");
            for (int i = 0; i < salones.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {salones[i].NombreSalon} ({salones[i].Alumnos.Count} Alumnos)");
            }

            Console.Write("Seleccione el número del salón: ");
            if (int.TryParse(Console.ReadLine(), out int seleccion) && seleccion >= 1 && seleccion <= salones.Count)
            {
                MenuSalon(salones[seleccion - 1]);
            }
            else
            {
                Console.WriteLine("Enter para reintentar...");
                Console.ReadLine();
            }
        }

        static void MenuSalon(Salon salon)
        {
            bool volver = false;

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine($"Menú del salon: {salon.NombreSalon.ToUpper()}");
                Console.WriteLine("¡Seleccione una opción!: ");
                Console.WriteLine("1. Registrar nuevo alumno");
                Console.WriteLine("2. Remover alumno");
                Console.WriteLine("3. Ver cantidad de alumnos aprobados");
                Console.WriteLine("4. Ver cantidad de alumnos desaprobados");
                Console.WriteLine("5. Mostrar lista de alumnos aprobados");
                Console.WriteLine("6. Mostrar lista de alumnos desaprobados");
                Console.WriteLine("7. Calcular promedio general del salón");
                Console.WriteLine("8. Volver al menú principal");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Registrar alumno");
                        Console.Write("Nombre del alumno: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Nota 1: ");
                        double n1 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Nota 2: ");
                        double n2 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Nota 3: ");
                        double n3 = Convert.ToDouble(Console.ReadLine());

                        salon.RegistrarNuevoAlumno(new Alumno(nombre, n1, n2, n3));
                        Console.WriteLine($"¡Alumno '{nombre}' registrado!");
                        break;

                    case "2":
                        Console.WriteLine("Remover alumno");
                        Console.Write("Ingrese el nombre del alumno a remover: ");
                        string nombreRemover = Console.ReadLine();

                        if (salon.RemoverAlumno(nombreRemover))
                        {
                            Console.WriteLine($"¡El alumno '{nombreRemover}' fue removido!");
                        }
                        else
                        {
                            Console.WriteLine("Reintente de nuevo...");
                        }
                        break;

                    case "3":
                        Console.WriteLine($"Cantidad de aprobados: {salon.CantidadAprobados()}");
                        break;

                    case "4":
                        Console.WriteLine($"Cantidad de desaprobados: {salon.CantidadDesaprobados()}");
                        break;

                    case "5":
                        Console.WriteLine("Lista de APROBADOS");
                        List<Alumno> aprobados = salon.ObtenerAprobados();
                        if (aprobados.Count == 0)
                        {
                            Console.WriteLine("No hay alumnos aprobados...");
                        }
                        else
                        {
                            foreach (var a in aprobados)
                            {
                                Console.WriteLine($"- {a.Nombre} | Promedio-TLS: {a.PromedioTLS():F2}");
                            }
                        }
                        break;

                    case "6":
                        Console.WriteLine("Lista de DESAPROBADOS");
                        List<Alumno> desaprobados = salon.ObtenerDesaprobados();
                        if (desaprobados.Count == 0)
                        {
                            Console.WriteLine("¡No hay alumnos desaprobados!");
                        }
                        else
                        {
                            foreach (var a in desaprobados)
                            {
                                Console.WriteLine($"- {a.Nombre} | Promedio-TLS: {a.PromedioTLS():F2}");
                            }
                        }
                        break;

                    case "7":
                        Console.WriteLine($"El promedio general del salón '{salon.NombreSalon}' es...: {salon.PromedioSalon():F2}");
                        break;

                    case "8":
                        volver = true;
                        continue;

                    default:
                        Console.WriteLine("Reintente de nuevo...");
                        break;
                }

                Console.WriteLine("¡Presione Enter para continuar...!");
                Console.ReadLine();
            }
        }
    }
}