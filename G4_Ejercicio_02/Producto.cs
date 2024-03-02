using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4_Ejercicio_02
{
    internal class Producto
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string marca;
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        private float precio;
        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private int stock;
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        private string rutaImagen;
        public string RutaImagen
        {
            get { return rutaImagen; }
            set { rutaImagen = value; }
        }
    }
}