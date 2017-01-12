using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPA_ENTIDAD;
using CAPA_NEGOCIO;
using System.Runtime.InteropServices;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication1
{
    
    public partial class POPUPCliente : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public POPUPCliente()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void POPUPCliente_Load(object sender, EventArgs e)
        {
            
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
        }

        void autocompletar_DESCRIPCION()
        {
            try
            {
                //    txtCLIENTE_VENTA.AutoCompleteMode = AutoCompleteMode.Suggest;
                //    txtCLIENTE_VENTA.AutoCompleteSource = AutoCompleteSource.CustomSource;

                //AutoCompleteStringCollection col = new AutoCompleteStringCollection();



                //SqlCommand cmd = new SqlCommand("SELECT DESCRIPCION FROM CLIENTE", con);

                //SqlDataReader dr = null;

                //dr = cmd.ExecuteReader();

                //while (dr.Read())
                //{
                //    col.Add(dr["DESCRIPCION"].ToString());
                //}
                //dr.Close();
                //txtCLIENTE_VENTA.AutoCompleteCustomSource = col;
                
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                con.Open();
                if (txtCLIENTE_RUC.Text.Length >= 8 && txtCLIENTE_RUC.Text.Length <= 11)
                {
                    
                    SqlCommand cmv = new SqlCommand("SELECT ID_CLIENTE,DIRECCION,DESCRIPCION FROM CLIENTE where RUC_DNI = '" + txtCLIENTE_RUC.Text + "'", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmv);
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("EL CLIENTE NO EXISTE!!, REGISTRE UNO NUEVO", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCLIENTE_ID.Text = "";
                        txtCLIENTE_VENTA.Text = "";
                    }
                    else if (dt.Rows.Count >= 1)
                    {
                        txtCLIENTE_ID.Text = dt.Rows[0][0].ToString();

                        txtCLIENTE_VENTA.Text = dt.Rows[0][2].ToString();
                        Properties.Settings.Default.direccion_vr = dt.Rows[0][1].ToString();
                        
                    }
                }
                 con.Close();
            }

            catch
            {
            }
        }

        


        private void txtCLIENTE_VENTA_TextChanged(object sender, EventArgs e)
        {
            //autocompletar_DESCRIPCION();




        }

        private void txtCLIENTE_RUC_TextChanged(object sender, EventArgs e)
        {
           // autocompletar_RUCDNI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtCLIENTE_ID.Text = "";
            txtCLIENTE_RUC.Text = "";
            txtCLIENTE_VENTA.Text = "";
            NUEVO_CLIENTE NC = new NUEVO_CLIENTE();
            NC.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void txtCLIENTE_RUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                autocompletar_DESCRIPCION();
            }
           
        }
    }
}
