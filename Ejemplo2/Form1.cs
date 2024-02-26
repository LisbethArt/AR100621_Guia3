using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario
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
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow selected = dgvListado.SelectedRows[0];
            int posicion = dgvListado.Rows.IndexOf(selected); //almacena en cual fila estoy
            edit_indice = posicion; //copio esa variable en índice editado

            Producto product = Productos[posicion]; /*esta variable de tipo persona, se carga
            con los valores que le pasa el listado*/

            //lo que tiene el atributo se lo doy al textbox
            txtNombre.Text = product.Nombre;
            txtDescripcion.Text = product.Descripcion;
            txtMarca.Text = product.Marca;
            txtPrecio.Text = Convert.ToString(product.Precio);
            txtStock.Text = Convert.ToString(product.Stock);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //creo un objeto de la clase persona y guardo a través de las propiedades
            Producto product = new Producto();
            product.Nombre = txtNombre.Text;
            product.Descripcion = txtDescripcion.Text;
            product.Marca = txtMarca.Text;
            product.Precio = float.Parse(txtPrecio.Text);
            product.Stock = int.Parse(txtStock.Text);

            if (edit_indice > -1) //verifica si hay un índice seleccionado
            {
                Productos[edit_indice] = product;
                edit_indice = -1;
            }
            else
            {
                Productos.Add(product); /*al arreglo de Productos le agrego el objeto creado con
                todos los datos que recolecté*/
            }
            actualizarGrid();//llamamos al procedimiento que guarda en datagrid
            reseteo(); //llamamos al método que resetea
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (edit_indice > -1) //verifica si hay un índice seleccionado
            {
                Productos.RemoveAt(edit_indice);
                edit_indice = -1; //resetea variable a -1
                reseteo();
                actualizarGrid();
            }
            else
            {
                MessageBox.Show("Dar doble click sobre elemento para seleccionar y borrar");
            }
        }
    }
}