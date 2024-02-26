using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR100621_Guia3
{
    class Persona
    {   //atributos
        private string nombre;
        private string apellido;
        private string telefono;
        private string correo;
        //métodos
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
        public string Telefono
         {
             get { return telefono; }
             set { telefono = value; }
         }
        public string Correo
         {
             get { return correo; }
             set { correo = value; }
         }
     }
}