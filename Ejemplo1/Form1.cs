using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo1
{
    public partial class Form1 : Form
    {
        /*listado que permite tener varios elementos de la clase Persona*/
        private List<Persona> Personas = new List<Persona>();
        private int edit_indice = -1; //el índice para editar comienza en -1, esto significa que
        //no hay ninguno seleccionado, esto servirá para el DataGridView.

        public Form1()
        {
            InitializeComponent();
        }

        private void actualizarGrid()
        {
            dgvContactos.DataSource = null;
            dgvContactos.DataSource = Personas; /*los nombres de columna que veremos
            son los de las propiedades*/
        }

        private void limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }
        private void dgvContactos_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow seleccion = dgvContactos.SelectedRows[0];
            int pos = dgvContactos.Rows.IndexOf(seleccion); //almacena en cual fila estoy
            edit_indice = pos; //copio esa variable en índice editado
            Persona per = Personas[pos]; /*esta variable de tipo persona, se carga con los
            valores que le pasa el listado*/
            txtNombre.Text = per.Nombre; //lo que tiene el atributo se lo doy al textbox
            txtApellido.Text = per.Apellido;
            txtTelefono.Text = per.Telefono;
            txtCorreo.Text = per.Correo;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //creo un objeto de la clase persona y guardo a través de las propiedades
            Persona per = new Persona();
            per.Nombre = txtNombre.Text;
            per.Apellido = txtApellido.Text;
            per.Telefono = txtTelefono.Text;
            per.Correo = txtCorreo.Text;
            if (edit_indice > -1) //verifica si hay un índice seleccionado
            {
                Personas[edit_indice] = per;
                edit_indice = -1;
            }
            else
            {
                Personas.Add(per); /*al arreglo de Personas le agrego el objeto creado
                con todos los datos que recolecté*/
            }

            actualizarGrid();//llamamos al procedimiento que guarda en datagrid
            limpiar();//mandamos a llamar la función que limpia
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (edit_indice > -1) //verifica si hay un índice seleccionado
            {
                Personas.RemoveAt(edit_indice);
                edit_indice = -1; //resetea variable a -1
                limpiar();
                actualizarGrid();
            }
            else
            {
                MessageBox.Show("Debe dar doble click primero sobre contacto");
            }
        }
    }
}