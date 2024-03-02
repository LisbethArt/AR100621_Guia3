using Ejemplo1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G4_Ejercicio_03
{
    public partial class FrmRecibe : Form
    {
        public List<Persona> PersonaRecibe = null; //creación de una lista que reciba

        public FrmRecibe()
        {
            InitializeComponent();
        }
        private void actualizarGrid() //función que llena el DGV del formulario 2
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = PersonaRecibe;
        }

        private void btnLlenar_Click(object sender, EventArgs e)
        { actualizarGrid(); } //actualiza DGV cada vez que se presione. 

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obtener el texto ingresado en el cuadro de texto de búsqueda
            string filtroNombre = txtBuscar.Text.Trim();

            // Verificar si se ingresó algún texto de búsqueda
            if (!string.IsNullOrEmpty(filtroNombre))
            {
                // Filtrar la lista de personas por el nombre que comienza con el texto de búsqueda
                List<Persona> personasFiltradas = PersonaRecibe.Where(p => p.Nombre.StartsWith(filtroNombre)).ToList();

                // Actualizar el DataGridView con las personas filtradas
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = personasFiltradas;
            }
            else
            {
                // Si no se ingresó ningún texto, mostrar todos los datos originales
                actualizarGrid();
            }
        }
    }
}
