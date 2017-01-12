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
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class NUEVO_CLIENTE : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public NUEVO_CLIENTE()
        {
            InitializeComponent();
        }

        private void NUEVO_CLIENTE_Load(object sender, EventArgs e)
        {
            ESTADO_INICIAL();

            P_LISTAR_DEPARTAMENTO();
            
            cboDEPARTAMAENTO_SelectedIndexChanged(sender, e);
            cboPROVINCIA_SelectedIndexChanged(sender, e);
            CARGAR_TIPO_CLIENTE();
            lblTITULO.Text = "MANTENIMIENTO DE CLIENTE";
            //DataGridViewButtonColumn colBotones = new DataGridViewButtonColumn();
            //colBotones.Name = "colBotones";
            //colBotones.HeaderText = "SELECCIONAR";
            //colBotones.Text = "SELECCIONAR";
            //colBotones.UseColumnTextForButtonValue = true;
            //colBotones.DisplayIndex = 0;
            //colBotones.FlatStyle = FlatStyle.Flat;

            //this.dgvCLIENTES.Columns.Add(colBotones);

        }

        #region OBJETOS
        E_MANT_CLIENTE E_OBJCLIENTE = new E_MANT_CLIENTE();
        N_VENTA N_OBJCLIENTE = new N_VENTA();
        #endregion


        void CARGAR_TIPO_CLIENTE()
        {

            List<ListaTipoProd> List = new List<ListaTipoProd>();

            List.Add(new ListaTipoProd { texto = "PERSONA NATURAL", value = "PN" });
            List.Add(new ListaTipoProd { texto = "PERSONA JURIDICA", value = "PJ" });



            cboTIPOCLIENTE.DataSource = List;
            cboTIPOCLIENTE.DisplayMember = "texto";
            cboTIPOCLIENTE.ValueMember = "value";
            cboTIPOCLIENTE.SelectedIndex = 0;

        }

        

        void REGISTRAR_CLIENTE(string ACCIONE)
        {
            try
            {
                E_OBJCLIENTE.ID_CLIENTE = string.Empty;
                E_OBJCLIENTE.TIPO_CLIENTE = cboTIPOCLIENTE.SelectedValue.ToString();
                E_OBJCLIENTE.DESCRIPCION = txtNOMCLIENTEREG.Text;
                E_OBJCLIENTE.RUC_DNI = txtRUCDNI.Text;
                E_OBJCLIENTE.DIRECCION = txtDIRECCION.Text;
                E_OBJCLIENTE.TELEFONO_1 = txtTEL1.Text;
                E_OBJCLIENTE.TELEFONO_2 = txtTEL2.Text;
                E_OBJCLIENTE.MOVIL = txtMOVIL.Text;
                E_OBJCLIENTE.FECHA_NAC = dtpFECHANAC.Value.ToShortDateString();
                E_OBJCLIENTE.EMAIL = txtEMAIL.Text;
                E_OBJCLIENTE.WEB_SITE = txtSITIOWEB.Text; ;
                E_OBJCLIENTE.ESTADO = true;
                E_OBJCLIENTE.UBIDST = cboDISTRITO.SelectedValue.ToString();
                E_OBJCLIENTE.ACCION = ACCIONE;
                N_OBJCLIENTE.MANTENIMIENTO_CLIENTE(E_OBJCLIENTE);
                MessageBox.Show("CLIENTE REGISTRADO CORRECTAMENTE", "  CORRECTO  ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ESTADO_INICIAL();
            }
            catch(Exception ex)
            {
                lblmsj.Text = "¡RUC o DNI ya existe! cambie el numero";
                txtRUCDNI.Focus();
                txtRUCDNI.BackColor = Color.MistyRose;
            }
            
          }

        void ACTUALIZAR_CLIENTE(string ACCIONE)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("UPDATE CLIENTE SET DESCRIPCION ='"+ txtNOMCLIENTE.Text + "',RUC_DNI='"+ txtRUCDNI.Text + "',DIRECCION='"+ txtDIRECCION.Text + "',TELEFONO_1='"+ txtTEL1.Text + "'," +
                    "TELEFONO_2='"+ txtTEL2.Text + "',MOVIL='"+ txtMOVIL.Text + "',EMAIL='"+ txtEMAIL.Text + "',WEB_SITE='"+ txtSITIOWEB.Text + "',UBIDST='"+ cboDISTRITO.SelectedValue.ToString() + "' " +
                    " WHERE ID_CLIENTE='"+ dgvCLIENTES.CurrentRow.Cells["ID_CLIENTE"].Value.ToString() + "'", con);

            cmd.CommandType = CommandType.Text;
            
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                

                
                MessageBox.Show("CLIENTE ACTUALIZADO CORRECTAMENTE","  CORRECTO  ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ESTADO_INICIAL();
        }
            catch (Exception ex)
            {
                lblmsj.Text = "¡RUC o DNI ya existe! cambie el numero";
                txtRUCDNI.Focus();
                txtRUCDNI.BackColor = Color.MistyRose;
            }


}
        

        void P_LISTAR_DEPARTAMENTO()
        {
            DataTable dt = N_OBJCLIENTE.LISTAR_DEPARTAMENTO();
            cboDEPARTAMAENTO.DataSource = dt;
            cboDEPARTAMAENTO.ValueMember = "UBIDEP";
            cboDEPARTAMAENTO.DisplayMember = "UBIDEN";
            
        }

        void P_LISTAR_PROVINCIA(string depart)
        {
            DataTable dt = N_OBJCLIENTE.LISTAR_PROVINCIA(depart);
            cboPROVINCIA.DataSource = dt;
            cboPROVINCIA.ValueMember = "UBIPRV";
            cboPROVINCIA.DisplayMember = "UBIPRN";
            
        }
        void P_LISTAR_DISTRITO(string prov)
        {
            DataTable dt = N_OBJCLIENTE.LISTAR_DISTRITO(prov);
            cboDISTRITO.DataSource = dt;
            cboDISTRITO.ValueMember = "UBIDST";
            cboDISTRITO.DisplayMember = "UBIDSN";
            
        }

        void autocompletar_DESCRIPCION()
        {
            try
            {
                txtNOMCLIENTE.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtNOMCLIENTE.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT DESCRIPCION FROM CLIENTE ", con);
                SqlDataReader dr = null;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    col.Add(dr["DESCRIPCION"].ToString());
                }
                dr.Close();
                txtNOMCLIENTE.AutoCompleteCustomSource = col;
                con.Close();

            }

            catch
            {
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            CARGAR_DATOS_ID_VTA_NUMERO();
            
        }
        

        public void CARGAR_DATOS_ID_VTA_NUMERO()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT TIPO_CLIENTE,DESCRIPCION,RUC_DNI,DIRECCION,TELEFONO_1,TELEFONO_2,MOVIL," +
                                            "FECHA_NAC, EMAIL, WEB_SITE, UB.UBIDEP,UB.UBIPRV,UB.UBIDST,ID_CLIENTE from CLIENTE as CL " +
                                            "INNER JOIN UBIGEO as UB ON CL.UBIDST = UB.UBIDST WHERE DESCRIPCION LIKE'%" + txtNOMCLIENTE.Text + "%' ORDER BY ID_CLIENTE DESC", con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvCLIENTES.DataSource = dt;
            
            dgvCLIENTES.Columns[0].HeaderText = "T.CLIENTE";
            dgvCLIENTES.Columns[1].HeaderText = "NOMBRE O R.SOCIAL";
            dgvCLIENTES.Columns[2].HeaderText = "RUC O DNI";
            dgvCLIENTES.Columns[3].HeaderText = "DIRECCION";
            dgvCLIENTES.Columns[4].Visible = false;
            dgvCLIENTES.Columns[5].Visible = false;
            dgvCLIENTES.Columns[7].Visible = false;
            dgvCLIENTES.Columns[8].Visible = false;
            dgvCLIENTES.Columns[9].Visible = false;
            dgvCLIENTES.Columns[10].Visible = false;
            dgvCLIENTES.Columns[11].Visible = false;
            dgvCLIENTES.Columns[12].Visible = false;
            dgvCLIENTES.Columns[13].Visible = false;
            con.Close();
        }

        

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboDEPARTAMAENTO_SelectedIndexChanged(object sender, EventArgs e)
        {

            P_LISTAR_PROVINCIA(cboDEPARTAMAENTO.SelectedValue.ToString());
        }

        private void cboPROVINCIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            P_LISTAR_DISTRITO(cboPROVINCIA.SelectedValue.ToString());
        }

        private void cboDISTRITO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bnAceptar_Click(object sender, EventArgs e)
        {
            txtDIRECCION.Enabled = true;
            cboTIPOCLIENTE.Enabled = true;
            txtNOMCLIENTEREG.Enabled = true;
            txtNOMCLIENTE.Enabled = false;
            txtNOMCLIENTE.Visible = false;
            txtNOMCLIENTEREG.Visible = true;
            txtRUCDNI.Enabled = true;
            txtSITIOWEB.Enabled = true;
            txtTEL1.Enabled = true;
            txtTEL2.Enabled = true;
            txtMOVIL.Enabled = true;
            txtEMAIL.Enabled = true;
            dtpFECHANAC.Enabled = true;
            bntActualizar.Enabled = false;
            bnAceptar.Enabled = false;
            btnGUARDARCAMBIOS.Enabled = true;
            button1.Enabled = true;
            cboDEPARTAMAENTO.Enabled = true;
            cboPROVINCIA.Enabled = true;
            cboDISTRITO.Enabled = true;
            lblTITULO.Text = "REGISTRO DE CLIENTE";
        }

        private void bntActualizar_Click(object sender, EventArgs e)
        {
            txtDIRECCION.Enabled = true;
            cboTIPOCLIENTE.Enabled = true;
            txtNOMCLIENTEREG.Enabled = false;
            txtNOMCLIENTE.Enabled = true;
            txtNOMCLIENTE.Visible = true;
            txtNOMCLIENTEREG.Visible = false;
            txtRUCDNI.Enabled = true;
            txtSITIOWEB.Enabled = true;
            txtTEL1.Enabled = true;
            txtTEL2.Enabled = true;
            txtMOVIL.Enabled = true;
            txtEMAIL.Enabled = true;
            dtpFECHANAC.Enabled = true;
            lblmsj1.Text = "Busqueda automatica ingrese nombre de cliente";
            lblTITULO.Text = "ACTUALIZACION DE CLIENTE";
            bntActualizar.Enabled = false;
            bnAceptar.Enabled = false;
            btnGUARDARCAMBIOS.Enabled = true;
            button1.Enabled = true;
            cboDEPARTAMAENTO.Enabled = true;
            cboPROVINCIA.Enabled = true;
            cboDISTRITO.Enabled = true;
            dgvCLIENTES.Enabled = true;
            

        }

        private void txtDESCRIPCION_TextChanged(object sender, EventArgs e)
        {
            autocompletar_DESCRIPCION();
            
        }

        private void dgvCLIENTES_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvCLIENTES.Columns[e.ColumnIndex].Name == "colBotones") //boton imprimir detro del gridview
                {
                    LLENAR_CONTROLES_ACTUALIZAR();
                    
                }
            }
            catch (Exception) { }
        }

        void LLENAR_CONTROLES_ACTUALIZAR()//LLENA UBIGEO DE CLIENTE EN ACTUALIZAR
        {
            txtNOMCLIENTE.Text = dgvCLIENTES.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
            txtRUCDNI.Text = dgvCLIENTES.CurrentRow.Cells["RUC_DNI"].Value.ToString();
            txtDIRECCION.Text = dgvCLIENTES.CurrentRow.Cells["DIRECCION"].Value.ToString();
            txtTEL1.Text = dgvCLIENTES.CurrentRow.Cells["TELEFONO_1"].Value.ToString();
            txtTEL2.Text = dgvCLIENTES.CurrentRow.Cells["TELEFONO_2"].Value.ToString();
            txtMOVIL.Text = dgvCLIENTES.CurrentRow.Cells["MOVIL"].Value.ToString();
            dtpFECHANAC.Text = dgvCLIENTES.CurrentRow.Cells["FECHA_NAC"].Value.ToString();
            //txtMC_FULTIMAVENTA.Text = DT.Rows[0]["FECHA_ULTVENTA"].ToString();
            txtEMAIL.Text = dgvCLIENTES.CurrentRow.Cells["EMAIL"].Value.ToString();
            txtSITIOWEB.Text = dgvCLIENTES.CurrentRow.Cells["WEB_SITE"].Value.ToString();

           
            cboDEPARTAMAENTO.SelectedValue = dgvCLIENTES.CurrentRow.Cells["UBIDEP"].Value.ToString();

            P_LISTAR_PROVINCIA(cboDEPARTAMAENTO.SelectedValue.ToString());
            cboPROVINCIA.SelectedValue = dgvCLIENTES.CurrentRow.Cells["UBIPRV"].Value.ToString();

            P_LISTAR_DISTRITO(cboPROVINCIA.SelectedValue.ToString());
            cboDISTRITO.SelectedValue = dgvCLIENTES.CurrentRow.Cells["UBIDST"].Value.ToString();

        }



        private void txtNOMCLIENTE_TextChanged(object sender, EventArgs e)
        {
            autocompletar_DESCRIPCION();
        }

        private void txtRUCDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtRUCDNI.Text.Trim(); ;
        }

        private void txtRUCDNI_TextChanged(object sender, EventArgs e)
        {
            
            lblmsj.Text = "";
            txtRUCDNI.BackColor = Color.White;
            if (txtRUCDNI.Text.Length < 8 || txtRUCDNI.Text.Length > 12)
            {
                  txtRUCDNI.Focus();
                  lblmsj.Text = "EL VALOR DEBE TENER  8 u 11 CIFRAS";
                
                
            } 
   
        }

        void ESTADO_INICIAL()
        {
            txtDIRECCION.Enabled = false;
            txtDIRECCION.Text = string.Empty;
            cboTIPOCLIENTE.Enabled = false;
            txtNOMCLIENTE.Enabled = false;
            txtNOMCLIENTE.Text = string.Empty;
            txtNOMCLIENTEREG.Text = string.Empty;
            txtNOMCLIENTEREG.Enabled = false;
            txtRUCDNI.Enabled = false;
            txtRUCDNI.Text = string.Empty;
            txtSITIOWEB.Enabled = false;
            txtSITIOWEB.Text = string.Empty;
            txtTEL1.Enabled = false;
            txtTEL1.Text = string.Empty;
            txtTEL2.Enabled = false;
            txtTEL2.Text = string.Empty;
            txtMOVIL.Enabled = false;
            txtMOVIL.Text = string.Empty;
            txtEMAIL.Enabled = false;
            txtEMAIL.Text = string.Empty;
            dtpFECHANAC.Enabled = false;
            lblmsj1.Text = "";
            lblmsj.Text = "";
            //LBLSELECCLI.Text = "";
            bntActualizar.Enabled = true;
            bnAceptar.Enabled = true;
            button1.Enabled = false;
            btnGUARDARCAMBIOS.Enabled = false;
            cboDEPARTAMAENTO.Enabled = false;
            P_LISTAR_DEPARTAMENTO();
            
            cboPROVINCIA.Enabled = false;
            
            cboDISTRITO.Enabled = false;
            
            btnGUARDARCAMBIOS.Enabled = false;
            dgvCLIENTES.Enabled = false;
            try { dgvCLIENTES.Rows.Clear(); } catch { }
        }

        private void btnGUARDARCAMBIOS_Click(object sender, EventArgs e)
        {
            if (txtRUCDNI.TextLength == 9 || txtRUCDNI.TextLength == 10)
            {
                txtRUCDNI.Focus();
                lblmsj.Text = "EL VALOR DEBE TENER  8 u 11 CIFRAS";
            }
            else
            {
                if (txtNOMCLIENTEREG.Enabled == true && txtNOMCLIENTE.Enabled == false)
                {
                    if (txtNOMCLIENTEREG.Text != string.Empty && txtRUCDNI.Text != string.Empty && txtDIRECCION.Text != string.Empty)
                    {
                        REGISTRAR_CLIENTE("1");
                        //cargar grilla de clientes

                        //volver al inicio
                        cboDEPARTAMAENTO_SelectedIndexChanged(sender, e);
                        cboPROVINCIA_SelectedIndexChanged(sender, e);
                    }
                    else { MessageBox.Show("LLENE TODOS LOS CAMPOS OBLIGATORIOS", " ¡ERROR!  ", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }
                else if (txtNOMCLIENTEREG.Enabled == false && txtNOMCLIENTE.Enabled == true)
                {
                    if (txtNOMCLIENTE.Text != string.Empty && txtRUCDNI.Text != string.Empty && txtDIRECCION.Text != string.Empty)
                    {
                        ACTUALIZAR_CLIENTE("2");
                        //cargar grilla de clientes
                        //CARGAR_DATOS_ID_VTA_NUMERO();
                        //volver al inicio
                        cboDEPARTAMAENTO_SelectedIndexChanged(sender, e);
                        cboPROVINCIA_SelectedIndexChanged(sender, e);
                    }
                    else { MessageBox.Show("LLENE TODOS LOS CAMPOS OBLIGATORIOS", " ¡ERROR!  ", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            
        }

        private void txtNOMCLIENTEREG_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ESTADO_INICIAL();
            dgvCLIENTES.DataSource = null;
        }

        private void dgvCLIENTES_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                LLENAR_CONTROLES_ACTUALIZAR();

                
            }
            catch (Exception) { }
        }

        private void txtRUCDNI_KeyPress_1(object sender, KeyPressEventArgs e)
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
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
