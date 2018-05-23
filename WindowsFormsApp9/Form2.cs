using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void MostrarCurriculum (string cadena) //recoge variable , recoge la caja de texto del curriculum
        {
            textBox1.Text = cadena;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();// boton cerrar
        }
    }
}
