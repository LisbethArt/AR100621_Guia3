using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G4_Ejercicio_02
{
    public partial class Form1 : Form
    {
        /*listado que permite tener varios elementos de la clase Persona*/
        private List<Producto> Productos = new List<Producto>();
        private int edit_indice = -1; /*el índice para editar comienza en -1, esto significa que
        no hay ninguno seleccionado, esto servirá para el DataGridView.*/
        public Form1()
        {
            InitializeComponent();
        }

        private void actualizarGrid()
        {
            dgvListado.DataSource = null;
            dgvListado.DataSource = Productos; /*los nombres de columna que veremos son
            los de las propiedades*/
        }
        private void reseteo()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            picImagen.Image = null; // Limpiar la imagen mostrada
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                DataGridViewRow selected = dgvListado.SelectedRows[0];
                int posicion = dgvListado.Rows.IndexOf(selected);
                edit_indice = posicion;

                Producto product = Productos[posicion];

                txtNombre.Text = product.Nombre;
                txtDescripcion.Text = product.Descripcion;
                txtMarca.Text = product.Marca;
                txtPrecio.Text = Convert.ToString(product.Precio);
                txtStock.Text = Convert.ToString(product.Stock);

                // Mostrar la imagen del producto
                if (!string.IsNullOrEmpty(product.RutaImagen) && System.IO.File.Exists(product.RutaImagen))
                {
                    picImagen.Image = Image.FromFile(product.RutaImagen);
                }
                else
                {
                    picImagen.Image = null;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que los campos estén completos
            if (string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtDescripcion.Text) ||
                string.IsNullOrEmpty(txtMarca.Text) ||
                string.IsNullOrEmpty(txtPrecio.Text) ||
                string.IsNullOrEmpty(txtStock.Text) ||
                picImagen.Image == null)
            {
                MessageBox.Show("Por favor complete todos los campos y seleccione una imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar el formato correcto del precio y el stock
            float precio;
            if (!float.TryParse(txtPrecio.Text, out precio) || precio <= 0)
            {
                MessageBox.Show("Por favor ingrese un precio válido mayor que cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int stock;
            if (!int.TryParse(txtStock.Text, out stock) || stock <= 0)
            {
                MessageBox.Show("Por favor ingrese un valor de stock válido mayor que cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si hay un producto en edición, actualizar sus datos
            if (edit_indice > -1 && edit_indice < Productos.Count)
            {
                // Obtener el producto en edición
                Producto productoEditado = Productos[edit_indice];

                // Actualizar los demás datos del producto en edición
                productoEditado.Nombre = txtNombre.Text;
                productoEditado.Descripcion = txtDescripcion.Text;
                productoEditado.Marca = txtMarca.Text;
                productoEditado.Precio = precio;
                productoEditado.Stock = stock;

                // Asignar la ruta de la imagen al producto en edición si hay una imagen seleccionada
                if (!string.IsNullOrEmpty(picImagen.ImageLocation))
                {
                    productoEditado.RutaImagen = picImagen.ImageLocation;
                }

                // Reiniciar el índice de edición
                edit_indice = -1;
            }
            else
            {
                MessageBox.Show("No hay ningún producto en edición. Por favor seleccione un producto para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Actualizar el DataGridView
            actualizarGrid();

            // Limpiar los controles de entrada
            reseteo();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (edit_indice > -1)
            {
                Productos.RemoveAt(edit_indice);
                edit_indice = -1;
                reseteo();
                actualizarGrid();
            }
            else
            {
                MessageBox.Show("Dar doble click sobre elemento para seleccionar y borrar");
            }
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            // Mostrar el diálogo para seleccionar un archivo de imagen
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; // Filtrar solo archivos de imagen
            openFileDialog.Title = "Seleccionar imagen";

            // Si el usuario selecciona un archivo y hace clic en "Aceptar"
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Obtener la ruta del archivo seleccionado
                    string rutaImagen = openFileDialog.FileName;

                    // Actualizar la ruta de imagen del producto en edición o creación
                    if (edit_indice > -1 && edit_indice < Productos.Count)
                    {
                        Productos[edit_indice].RutaImagen = rutaImagen;
                    }
                    else
                    {
                        // Crear un nuevo producto y asignar la ruta de la imagen
                        Producto nuevoProducto = new Producto();
                        nuevoProducto.RutaImagen = rutaImagen;
                        Productos.Add(nuevoProducto);
                        // Establecer el índice de edición como el último elemento en la lista
                        edit_indice = Productos.Count - 1;
                    }

                    // Mostrar la imagen completa en el PictureBox y ajustarla al tamaño del control
                    picImagen.SizeMode = PictureBoxSizeMode.Zoom;
                    picImagen.Image = Image.FromFile(rutaImagen);
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que ocurra al obtener la ruta de la imagen
                    MessageBox.Show("Error al obtener la ruta de la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
