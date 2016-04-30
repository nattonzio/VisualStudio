using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Proycs
{
    public partial class Form1 : Form
    {
        MySqlConnection con;
        public int erro = 0, er = 2;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            con.Open();
            string usu = txtusu.Text;
            string pass = txtpass.Text;
            MySqlCommand cmd = new MySqlCommand("select * from Usuario where nom_usu='" + usu + "' and pass_usu='" + pass + "'", con);
            MySqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                this.Hide();
                Form2 ss = new Form2();
                ss.ShowDialog();
            }
            else
            {
                erro++;
                lber.Text = Convert.ToString(erro);
                if (erro < 3)
                {
                    txtpass.Clear();
                    txtusu.Clear();
                    MessageBox.Show("Usuario o Contraseña incorrecta \n Quedan " + (er--) + " intentos", "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtusu.Focus();
                }

                if (erro == 3)
                {
                    MessageBox.Show("Número de Intentos Excedidos");
                    Application.Exit();
                }
                con.Close();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                con = new MySqlConnection("server=localhost; User Id=root; database = Proycs");
//                MySqlConnection con = new MySqlConnection("server=localhost;User Id=root;database=data");
            }
            catch (Exception)
            {
                MessageBox.Show("Error de BD", "Error");
                con.Close();
            }
        }

        private void lber_Click(object sender, EventArgs e)
        {
        
        }
    }
}
