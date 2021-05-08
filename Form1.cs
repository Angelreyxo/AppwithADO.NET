using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppConADO.NET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"server=DESKTOP-DTI3QKS; database=PRODUCTOS; integrated security = true");
            con.Open();
            
            int id = int.Parse(txtId.Text);

            string cadena = "SELECT nombrePro, marcaPro, precioPro, descripcionPro FROM tablaProducto WHERE idPro=" + id;
            SqlCommand comando = new SqlCommand(cadena,con);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                txtNombre.Text = registro["nombrePro"].ToString();
                txtMarca.Text = registro["marcaPro"].ToString();
                txtPrecio.Text = registro["precioPro"].ToString();
                txtDescripcion.Text = registro["descripcionPro"].ToString();
            }
            else
            {
                MessageBox.Show("ID de articulo no valido");
            }
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                if (e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
                {
                    MessageBox.Show("Solo puede ingresar Numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
