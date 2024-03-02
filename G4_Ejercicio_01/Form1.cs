using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G4_Ejercicio_01
{
    public partial class Form1 : Form
    {
        private List<Alumno> estudiantes = new List<Alumno>();
        private int edit_indice = -1;
        private int limiteEstudiantes;
        private bool permitirEditar = true;

        public Form1(int limiteEstudiantes)
        {
            InitializeComponent();
            this.limiteEstudiantes = limiteEstudiantes;
        }

        private void actualizarGrid()
        {
            // Limpiar las columnas existentes para evitar duplicaciones
            dgvAlumnos.Columns.Clear();

            // Agregar columnas para mostrar las notas individualmente
            dgvAlumnos.Columns.Add("Nombre", "Nombre");
            dgvAlumnos.Columns.Add("Apellido", "Apellido");
            dgvAlumnos.Columns.Add("Carnet", "Carnet");
            dgvAlumnos.Columns.Add("Materia", "Materia");
            dgvAlumnos.Columns.Add("Nota1", "Nota 1");
            dgvAlumnos.Columns.Add("Nota2", "Nota 2");
            dgvAlumnos.Columns.Add("Nota3", "Nota 3");
            dgvAlumnos.Columns.Add("Promedio", "Promedio");

            // Limpiar las filas del DataGridView
            dgvAlumnos.Rows.Clear();

            // Agregar las filas actualizadas
            foreach (Alumno estudiante in estudiantes)
            {
                int rowIndex = dgvAlumnos.Rows.Add(); // Agregar una nueva fila
                DataGridViewRow row = dgvAlumnos.Rows[rowIndex];
                row.Cells["Nombre"].Value = estudiante.Nombre;
                row.Cells["Apellido"].Value = estudiante.Apellido;
                row.Cells["Carnet"].Value = estudiante.Carnet;
                row.Cells["Materia"].Value = estudiante.Materia;
                row.Cells["Nota1"].Value = estudiante.Calificaciones[0];
                row.Cells["Nota2"].Value = estudiante.Calificaciones[1];
                row.Cells["Nota3"].Value = estudiante.Calificaciones[2];
                row.Cells["Promedio"].Value = estudiante.Promedio.ToString("N2");
            }
        }

        private void limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCarnet.Clear();
            txtMateria.Clear();
            txtNota1.Clear();
            txtNota2.Clear();
            txtNota3.Clear();
            txtPromedio.Clear();
        }

        private void dgvAlumnos_DoubleClick(object sender, EventArgs e)
        {
            if (permitirEditar)
            {
                try
                {
                    DataGridViewRow seleccion = dgvAlumnos.SelectedRows[0];
                    int pos = dgvAlumnos.Rows.IndexOf(seleccion);

                    // Verificar si el índice es válido
                    if (pos >= 0 && pos < estudiantes.Count)
                    {
                        edit_indice = pos;
                        Alumno estudiante = estudiantes[pos];
                        txtNombre.Text = estudiante.Nombre;
                        txtApellido.Text = estudiante.Apellido;
                        txtCarnet.Text = estudiante.Carnet;
                        txtMateria.Text = estudiante.Materia;
                        txtNota1.Text = estudiante.Calificaciones[0].ToString();
                        txtNota2.Text = estudiante.Calificaciones[1].ToString();
                        txtNota3.Text = estudiante.Calificaciones[2].ToString();
                        txtPromedio.Text = estudiante.Promedio.ToString("N2");
                    }
                    else
                    {
                        MessageBox.Show("El índice seleccionado no es válido.");
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Si se produce la excepción, no hay fila seleccionada, simplemente limpiamos los campos
                    limpiar();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha alcanzado el límite de estudiantes
            if (estudiantes.Count >= limiteEstudiantes)
            {
                MessageBox.Show($"Se ha alcanzado el límite de {limiteEstudiantes} estudiantes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar si se han ingresado datos válidos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCarnet.Text) || string.IsNullOrWhiteSpace(txtMateria.Text) ||
                string.IsNullOrWhiteSpace(txtNota1.Text) || string.IsNullOrWhiteSpace(txtNota2.Text) ||
                string.IsNullOrWhiteSpace(txtNota3.Text))
            {
                MessageBox.Show("Ingrese datos válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear un nuevo estudiante
            Alumno estudiante = new Alumno();
            estudiante.Nombre = txtNombre.Text;
            estudiante.Apellido = txtApellido.Text;
            estudiante.Carnet = txtCarnet.Text;
            estudiante.Materia = txtMateria.Text;

            // Verificar si las calificaciones son números válidos
            float nota1, nota2, nota3;
            if (!float.TryParse(txtNota1.Text, out nota1) || !float.TryParse(txtNota2.Text, out nota2) || !float.TryParse(txtNota3.Text, out nota3))
            {
                MessageBox.Show("Ingrese calificaciones válidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Asignar las calificaciones
            estudiante.Calificaciones[0] = nota1;
            estudiante.Calificaciones[1] = nota2;
            estudiante.Calificaciones[2] = nota3;

            if (edit_indice > -1 && edit_indice < estudiantes.Count) // Verificar si se está editando un estudiante existente
            {
                // Actualizar el estudiante existente
                estudiantes[edit_indice] = estudiante;
                edit_indice = -1; // Restablecer el índice después de la edición
            }
            else
            {
                estudiantes.Add(estudiante); // Agregar el nuevo estudiante a la lista
            }

            actualizarGrid();
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.SelectedRows.Count > 0) // Verificar si hay alguna fila seleccionada
            {
                int indice = dgvAlumnos.SelectedRows[0].Index; // Obtener el índice de la fila seleccionada

                if (indice >= 0 && indice < estudiantes.Count) // Verificar si el índice es válido
                {
                    estudiantes.RemoveAt(indice); // Eliminar el estudiante correspondiente al índice seleccionado
                    actualizarGrid();
                    limpiar();
                    dgvAlumnos.ClearSelection();
                }
                else
                {
                    MessageBox.Show("El índice seleccionado no es válido.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un estudiante primero.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvAlumnos.ClearSelection();
            edit_indice = -1;
            limpiar();
        }
    }
}