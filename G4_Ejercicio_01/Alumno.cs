using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4_Ejercicio_01
{
    public class Alumno
    {   //atributos
        private string nombre;
        private string apellido;
        private string carnet;
        private string materia;
        private float[] calificaciones = new float[3];

        // Propiedades
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Carnet
        {
            get { return carnet; }
            set { carnet = value; }
        }

        public string Materia
        {
            get { return materia; }
            set { materia = value; }
        }

        public float[] Calificaciones
        {
            get { return calificaciones; }
            set { calificaciones = value; }
        }

        public float Promedio
        {
            get
            {
                if (calificaciones.Length > 0)
                    return calificaciones.Sum() / calificaciones.Length;
                else
                    return 0;
            }
        }
    }
}
