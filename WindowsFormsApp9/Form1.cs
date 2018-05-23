using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        string cadena = ConfigurationManager.ConnectionStrings["cadenaNorthwind"].ConnectionString;
        string curriculum; //variable para guardar curriculum

        Form2 formulario2; //creo variable para el formulario 2
        public Form1()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //cargamos el grid
            CargarGrid();

        }

        private void CargarGrid()
        {
            string query = "SELECT * FROM EMPLOYEES";
            SqlDataAdapter adaptador = new SqlDataAdapter(query, cadena);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            //cargamos datagrid
            dataGridView1.DataSource = tabla;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);//dar formato


        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //cuando hago doble sobre la tabla , genero método
            CargarDetalle();
        }

        private void CargarDetalle()
        {
            txtFistName.Text = dataGridView1.CurrentRow.Cells["FirstName"].Value.ToString();  //recupero directamente del datagrid,esto es un objeto
            txtLastName.Text=dataGridView1.CurrentRow.Cells["LastName"].Value.ToString();
            txtTitle.Text= dataGridView1.CurrentRow.Cells["Title"].Value.ToString();
            txtAddress.Text= dataGridView1.CurrentRow.Cells["Address"].Value.ToString();
            txtCity.Text= dataGridView1.CurrentRow.Cells["City"].Value.ToString();
            txtCountry.Text= dataGridView1.CurrentRow.Cells["Country"].Value.ToString();
            txtPostalCode.Text= dataGridView1.CurrentRow.Cells["PostalCode"].Value.ToString();
            txtPhone.Text= dataGridView1.CurrentRow.Cells["HomePhone"].Value.ToString();


            curriculum = dataGridView1.CurrentRow.Cells["Notes"].Value.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //hago llamada al metodo void del formulario 2
            formulario2 = new Form2();
            formulario2.MostrarCurriculum(curriculum);
            formulario2.ShowDialog(); //el usuario puede interactuar
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //controles del mismo tipo, para que hagan lo mismo: IMPORTANTE
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Text = string.Empty;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); //cierro la aplicación
        }
    }
}
