using System;
using System.Collections.Generic;

namespace TallerClase
{
    internal class Program
    {
        static List<Salon> salones = new List<Salon>();

        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTIÓN ACADÉMICA - SALONES Y ALUMNOS ===");
                Console.WriteLine("1. Crear un nuevo salón");
                Console.WriteLine("2. Seleccionar un salón y realizar operaciones");
                Console.WriteLine("3. Salir");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CrearSalon();
                        break;
                    case "2":
                        GestionarSalones();
                        break;
                    case "3":
                        salir = true;
                        Console.WriteLine("\n¡Programa finalizado con éxito!");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Presione Enter para reintentar.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void CrearSalon()
        {
            Console.Clear();
            Console.WriteLine("=== CREACIÓN DE SALÓN ===");
            Console.Write("Ingrese el nombre o sección del salón: ");
            string nombre = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                salones.Add(new Salon(nombre));
                Console.WriteLine($"\n¡Salón '{nombre}' creado correctamente!");
            }
            else
            {
                Console.WriteLine("\nError: El nombre del salón no puede estar vacío.");
            }
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }

        static void GestionarSalones()
        {
            Console.Clear();
            if (salones.Count == 0)
            {
                Console.WriteLine("No hay salones registrados. Cree uno primero.");
                Console.WriteLine("\nPresione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("=== LISTA DE SALONES DISPONIBLES ===");
            for (int i = 0; i < salones.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {salones[i].NombreSalon} ({salones[i].Alumnos.Count} Alumnos)");
            }

            Console.Write("\nSeleccione el número del salón con el que desea trabajar: ");
            if (int.TryParse(Console.ReadLine(), out int seleccion) && seleccion >= 1 && seleccion <= salones.Count)
            {
                MenuSalon(salones[seleccion - 1]);
            }
            else
            {
                Console.WriteLine("\nSelección inválida. Presione Enter para continuar...");
                Console.ReadLine();
            }
        }

        static void MenuSalon(Salon salon)
        {
            bool volver = false;

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine($"=== MENÚ DEL SALÓN: {salon.NombreSalon.ToUpper()} ===");
                Console.WriteLine("1. Registrar nuevo alumno");
                Console.WriteLine("2. Remover alumno");
                Console.WriteLine("3. Ver cantidad de alumnos aprobados");
                Console.WriteLine("4. Ver cantidad de alumnos desaprobados");
                Console.WriteLine("5. Mostrar lista de alumnos aprobados");
                Console.WriteLine("6. Mostrar lista de alumnos desaprobados");
                Console.WriteLine("7. Calcular promedio general del salón");
                Console.WriteLine("8. Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("\n--- REGISTRAR ALUMNO ---");
                        Console.Write("Nombre del alumno: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Nota 1: ");
                        double n1 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Nota 2: ");
                        double n2 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Nota 3: ");
                        double n3 = Convert.ToDouble(Console.ReadLine());

                        salon.RegistrarNuevoAlumno(new Alumno(nombre, n1, n2, n3));
                        Console.WriteLine($"\n¡Alumno '{nombre}' registrado correctamente!");
                        break;

                    case "2":
                        Console.WriteLine("\n--- REMOVER ALUMNO ---");
                        Console.Write("Ingrese el nombre del alumno a remover: ");
                        string nombreRemover = Console.ReadLine();

                        if (salon.RemoverAlumno(nombreRemover))
                        {
                            Console.WriteLine($"\n¡El alumno '{nombreRemover}' fue removido con éxito!");
                        }
                        else
                        {
                            Console.WriteLine("\nNo se encontró ningún alumno registrado con ese nombre.");
                        }
                        break;

                    case "3":
                        Console.WriteLine($"\nCantidad de aprobados: {salon.CantidadAprobados()}");
                        break;

                    case "4":
                        Console.WriteLine($"\nCantidad de desaprobados: {salon.CantidadDesaprobados()}");
                        break;

                    case "5":
                        Console.WriteLine("\n--- LISTA DE ALUMNOS APROBADOS ---");
                        List<Alumno> aprobados = salon.ObtenerAprobados();
                        if (aprobados.Count == 0)
                        {
                            Console.WriteLine("No hay alumnos aprobados.");
                        }
                        else
                        {
                            foreach (var a in aprobados)
                            {
                                Console.WriteLine($"- {a.Nombre} | Promedio TLS: {a.PromedioTLS():F2}");
                            }
                        }
                        break;

                    case "6":
                        Console.WriteLine("\n--- LISTA DE ALUMNOS DESAPROBADOS ---");
                        List<Alumno> desaprobados = salon.ObtenerDesaprobados();
                        if (desaprobados.Count == 0)
                        {
                            Console.WriteLine("No hay alumnos desaprobados.");
                        }
                        else
                        {
                            foreach (var a in desaprobados)
                            {
                                Console.WriteLine($"- {a.Nombre} | Promedio TLS: {a.PromedioTLS():F2}");
                            }
                        }
                        break;

                    case "7":
                        Console.WriteLine($"\nEl promedio general del salón '{salon.NombreSalon}' es: {salon.PromedioSalon():F2}");
                        break;

                    case "8":
                        volver = true;
                        continue;

                    default:
                        Console.WriteLine("\nOpción no válida.");
                        break;
                }

                Console.WriteLine("\nPresione Enter para continuar...");
                Console.ReadLine();
            }
        }
    }
}