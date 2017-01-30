using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    
    public partial class CANTIDAD_PROD : Form
    {
        public int suma;
        public CANTIDAD_PROD()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        private void CANTIDAD_PROD_Load(object sender, EventArgs e)
        {
            btnOK.DialogResult = DialogResult.OK;
            label2.Text = Properties.Settings.Default.nom_prod_grilla;
            textBox1.Text = "1";
            txtPrecio.Text = Properties.Settings.Default.precio_prod_grilla;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            suma += 1;
            textBox1.Text = suma.ToString();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                suma = 1;
                textBox1.Text = suma.ToString();
            }
            else
            {
                if (suma > 1)
                {
                    suma -= 1;
                    textBox1.Text = suma.ToString();

                }
            }
            textBox1.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.cantidad_grilla = textBox1.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();

            Properties.Settings.Default.precio_prod_grilla = txtPrecio.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();

            KIOSKOBEBIDAS KB = new KIOSKOBEBIDAS();
            KB.OBTENER_ID_BIEN_Y_LLENAR_GRILLA(Properties.Settings.Default.id_prod_grilla, Properties.Settings.Default.nom_prod_grilla, Properties.Settings.Default.precio_prod_grilla);
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnOK.PerformClick();
            }

            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.Close();
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnOK.PerformClick();
            }

            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.Close();
            }
        }
    }
}
