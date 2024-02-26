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

namespace Ejemplo3
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
    }
}