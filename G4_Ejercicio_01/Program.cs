using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G4_Ejercicio_01
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form2 form2 = new Form2();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                int limiteEstudiantes = form2.LimiteEstudiantes;
                Form1 form1 = new Form1(limiteEstudiantes);
                Application.Run(form1);
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
