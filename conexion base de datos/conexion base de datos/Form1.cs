using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace conexion_base_de_datos
{
    public partial class Form1 : Form
    {
        OracleConnection ora = new OracleConnection("Data source=xe;user id=prue;password=p123");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnconectar_Click(object sender, EventArgs e)
        {
            ora.Open();
            MessageBox.Show("Estas Conectado");
            ora.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("spAdd", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("pidmaterial", OracleType.Number).Value = txtidmaterial.Text;
                comando.Parameters.Add("pdescripcion", OracleType.VarChar).Value = txtdescripcion.Text;
                comando.Parameters.Add("pprecio", OracleType.Number).Value = txtprecio.Text;
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Insertado");
                ora.Close();

            }
            catch (Exception E)
            {

                MessageBox.Show("ha ocurrido un erroe"+E);
            }
           
        }
    }
}
