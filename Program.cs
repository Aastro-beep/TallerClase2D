using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerClase;

namespace Taller
{
    internal class TallerClase
    {
        static void Main(string[] args)
        {
            TallerClase programa = new TallerClase();
            programa.Run();
        }
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Escriba la figura para calcular su area!");
                Console.WriteLine("-Triangulo");
                Console.WriteLine("-Rectangulo");
                Console.WriteLine("-Circulo");
                string opciones = Console.ReadLine();

                switch (opciones)
                {
                    case "Triangulo":
                        Console.WriteLine("Coloque la base: ");
                        float baseR = float.Parse(Console.ReadLine());
                        Console.WriteLine("Coloque la altura: ");
                        float heightR = float.Parse(Console.ReadLine());

                        Triangulo rectangle = new Triangulo(baseR, heightR);
                        Console.WriteLine("Calculando area... " + rectangle.Area());

                        break;

                    case "Rectangulo":
                        Console.WriteLine("Coloque la base: ");
                        float baseT = float.Parse(Console.ReadLine());
                        Console.WriteLine("Coloque la altura: ");
                        float heightT = float.Parse(Console.ReadLine());
                        Rectangulo triangle = new Rectangulo(baseT, heightT);

                        Console.WriteLine("Calculando area... " + triangle.Area());

                        break;

                    case "Circulo":
                        Console.WriteLine("Coloque el radio");
                        float radio = float.Parse(Console.ReadLine());
                        Circulo circle = new Circulo(radio);

                        Console.WriteLine("Calculando area... " + circle.Area());

                        break;
                }

                Console.WriteLine("Deseas volver a elegir una figura?");
                string respuesta = Console.ReadLine();
                if (respuesta != "si")
                {
                    Console.WriteLine("Vuelva pronto!");
                    break;
                }
            }
        }
    }
}