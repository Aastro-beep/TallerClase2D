using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerClase;

namespace TallerClase
{
    public class Salon
    {
        public string NombreSalon { get; set; }
        public List<Alumno> Alumnos { get; set; }

        public Salon(string nombreSalon)
        {
            NombreSalon = nombreSalon;
            Alumnos = new List<Alumno>();
        }
        public void RegistrarNuevoAlumno(Alumno alumno)
        {
            Alumnos.Add(alumno);
        }
        public bool RemoverAlumno(string nombre)
        {
            Alumno alumnoEncontrado = Alumnos.FirstOrDefault(a => a.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (alumnoEncontrado != null)
            {
                Alumnos.Remove(alumnoEncontrado);
                return true;
            }
            return false;
        }
        public int CantidadAprobados()
        {
            return Alumnos.Count(a => a.Aprobado());
        }
        public int CantidadDesaprobados()
        {
            return Alumnos.Count(a => !a.Aprobado());
        }
        public List<Alumno> ObtenerAprobados()
        {
            return Alumnos.Where(a => a.Aprobado()).ToList();
        }
        public List<Alumno> ObtenerDesaprobados()
        {
            return Alumnos.Where(a => !a.Aprobado()).ToList();
        }
        public double PromedioSalon()
        {
            if (Alumnos.Count == 0) return 0.0;
            return Alumnos.Average(a => a.PromedioTLS());
        }
    }
}