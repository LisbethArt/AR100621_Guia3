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
    public partial class Form2 : Form
    {
        public int LimiteEstudiantes { get; private set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumeroEstudiantes.Text, out int limite) && limite > 0)
            {
                LimiteEstudiantes = limite;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Ingrese un número válido mayor que cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
