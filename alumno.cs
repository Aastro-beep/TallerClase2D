using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerClase
{
    public class Alumno
    {
        public string Nombre { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Nota3 { get; set; }
        public Alumno(string nombre, double nota1, double nota2, double nota3)
        {
            Nombre = nombre;
            Nota1 = nota1;
            Nota2 = nota2;
            Nota3 = nota3;
        }
        public double PromedioTLS()
        {
            return (Nota1 + Nota2 + Nota3) / 3.0;
        }

        public bool Aprobado()
        {
            return PromedioTLS() >= 13.0;
        }
    }
}
