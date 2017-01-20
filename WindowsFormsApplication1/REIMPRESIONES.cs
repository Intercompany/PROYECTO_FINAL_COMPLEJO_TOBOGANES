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
using System.Data.Sql;
using System.Configuration;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace WindowsFormsApplication1
{
    public partial class REIMPRESIONES : Form
    {
        public string bc_id_caja;
        public string bc_id_puntoventa;
        public string bc_id_empleado;
        public string bc_id_empresa;
        public string bc_nombre_empleado;
        public string bc_tipo_cambio;
        public string bc_sede;
        public string mensaje_ = "INGRESE CODIGO DE AUTORIZACION";
        public int contador = 0;
        string NOMCLIENTE = "";
        string RUCDNI = "";
        string DIRECLIENTE = "";
        public string MOVIMIENTHO = "";

        public int estado = 0;
        

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public string bc_id_cliente;
        
        public REIMPRESIONES()
        {

            InitializeComponent();
        }

        private void BUSCAR_CLIENTE_Load(object sender, EventArgs e)
        {

            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            TIPO_DOC();
            
            //crea botones en el gridview
            DataGridViewButtonColumn colBotones = new DataGridViewButtonColumn();
            colBotones.Name = "colBotones";
            colBotones.HeaderText = "IMPRIMIR";
            colBotones.Text = "IMPRIMIR";
            colBotones.UseColumnTextForButtonValue = true;
            colBotones.DisplayIndex = 0;
            colBotones.FlatStyle = FlatStyle.Flat;
            
            this.dgvClientes.Columns.Add(colBotones);
            //------------------------------------------------------------///
            CARGAR_DATOS_ID_VTA_NUMERO();
                      

        }

        #region OBJETOS
      


        E_MANT_CLIENTE E_OBJCLIENTE = new E_MANT_CLIENTE();
        N_VENTA N_OBJCLIENTE = new N_VENTA();
        #endregion
 
        void validar_estado()
        {
            if (estado == 0)
            {
                txtIDVENTA.Enabled = false;
                txtNOMCLIENTE.Enabled = false;
                txtNUMERODOC.Enabled = false;
                txtRUCDNI.Enabled = false;
                dgvClientes.Enabled = false;
                cboTipoDoc.Enabled = false;
            }
            else if (estado == 1)
            {
                txtIDVENTA.Enabled = true;
                txtNOMCLIENTE.Enabled = true;
                txtNUMERODOC.Enabled = true;
                txtRUCDNI.Enabled = true;
                dgvClientes.Enabled = true;
                cboTipoDoc.Enabled = true;
            }

        }



        void autocompletar_DESCRIPCION()
        {
            try
            {
                txtNOMCLIENTE.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtNOMCLIENTE.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtRUCDNI.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtRUCDNI.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                AutoCompleteStringCollection ruc = new AutoCompleteStringCollection();

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DESCRIPCION FROM CLIENTE", con);
                /* DataTable dt = new DataTable();
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 da.Fill(dt);*/
                SqlDataReader dr = null;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    col.Add(dr["DESCRIPCION"].ToString());
                }
                dr.Close();
                txtNOMCLIENTE.AutoCompleteCustomSource = col;
                con.Close();
                con.Open();
                if (txtNOMCLIENTE.Text.Length >= 6)
                {
                    SqlCommand cmv = new SqlCommand("SELECT RUC_DNI FROM CLIENTE where DESCRIPCION = '" + txtNOMCLIENTE.Text + "'", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmv);
                    da.Fill(dt);
                    
                    txtRUCDNI.Text = dt.Rows[0][0].ToString();
                    
                    con.Close();
                }
                else { con.Close(); }
            }

            catch
            {
            }
            CARGAR_DATOS_CLI_RUC();
        }

        void autocompletar_dni_ruc()
        {
            try
            {


                txtRUCDNI.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtRUCDNI.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT RUC_DNI FROM CLIENTE", con);

                SqlDataReader dr = null;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    col.Add(dr["RUC_DNI"].ToString());
                }
                dr.Close();
                txtRUCDNI.AutoCompleteCustomSource = col;
                con.Close();
                con.Open();
                if (txtRUCDNI.Text.Length >= 4)
                {
                    SqlCommand cmv = new SqlCommand("SELECT DESCRIPCION FROM CLIENTE where RUC_DNI = '" + txtRUCDNI.Text + "'", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmv);
                    da.Fill(dt);
                    txtNOMCLIENTE.Text = dt.Rows[0][0].ToString();
                    con.Close();
                }
                else { con.Close(); }
            }

            catch
            {
            }
            CARGAR_DATOS_CLI_RUC();
        }

        /*----------------------AUTOCOMPLETAR ID_VENTA----------------------*/
        void autocompletar_ID_VENTA()
        {
            try
            {
                txtIDVENTA.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtIDVENTA.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT  ID_COMPVENT FROM V_CAJA_KADEX WHERE ID_CAJA = '"+Properties.Settings.Default.id_caja+"' AND ID_COMPVENT IS NOT NULL", con);
                SqlDataReader dr = null;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    col.Add(dr["ID_COMPVENT"].ToString());
                }
                dr.Close();
                txtIDVENTA.AutoCompleteCustomSource = col;
                con.Close();
                
            }

            catch
            {
            }

            CARGAR_DATOS_ID_VTA_NUMERO();
        }
        /*------------------------------------------------------------------*/

        /*----------------------AUTOCOMPLETAR NUMERO----------------------*/
        void autocompletar_NUMERO()
        {
            try
            {
                txtNUMERODOC.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtNUMERODOC.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT  VT.V_NUMERO, VT.V_TIPO_DOC"+
                                                "FROM V_CAJA_KADEX AS CK  INNER JOIN V_TABLA_VENTAS AS VT ON CK.ID_COMPVENT = VT.V_ID_VENTA"+
                                                "WHERE CK.ID_CAJA = '"+Properties.Settings.Default.id_caja+"' AND VT.V_TIPO_DOC = '"+cboTipoDoc.SelectedValue.ToString()+"'", con);
                SqlDataReader dr = null;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    col.Add(dr["V_NUMERO"].ToString());
                }
                dr.Close();
                txtNUMERODOC.AutoCompleteCustomSource = col;
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
        /*------------------------------------------------------------------*/






        void TIPO_DOC()
        {

            List<ListaTipoProd> List = new List<ListaTipoProd>();

            
            List.Add(new ListaTipoProd { texto = "TICKET BOLETA", value = "TB" });
            //List.Add(new ListaTipoProd { texto = "BOLETA VENTA", value = "BV" });
            //List.Add(new ListaTipoProd { texto = "FACTURA VENTA", value = "FV" });


            cboTipoDoc.DataSource = List;
            cboTipoDoc.DisplayMember = "texto";
            cboTipoDoc.ValueMember = "value";
            cboTipoDoc.SelectedIndex = 0;
            

        }


        public void CARGAR_DATOS_CLI_RUC()
        {
            string v_nomcliente = txtNOMCLIENTE.Text;
            string v_rucdni = txtRUCDNI.Text;
            string v_tipo_doc = cboTipoDoc.SelectedValue.ToString();
            string v_id_venta = txtIDVENTA.Text;
            string v_numero = txtNUMERODOC.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT  CK.ID_COMPVENT,CK.ID_MOVIMIENTO,VT.V_TIPO_DOC, VT.V_NUMERO, VT.C_DESCRIPCION, VT.C_RUC_DNI, CK.FECHA,"+
                                            "CK.TP_DESCRIPCION, CK.ID_TIPOMOV, CK.TM_DESCRIPCION, CK.IMPORTE, CK.MONEDA, CK.TIPO_CAMBIO, CK.AMORTIZADO,"+
                                            "CK.IMPORTE_CAJA, CK.ID_CAJA, CK.SALDO_INICIAL, CK.SALDO_FINAL, CK.EMPLEADO, CK.PV_DESCRIPCION, CK.S_DESCRIPCION, CK.FECHA_ANULADO, CK.DESCRIPCION,VT.C_DIRECCION" +
                                            " FROM V_CAJA_KADEX AS CK  INNER JOIN V_TABLA_VENTAS AS VT ON CK.ID_COMPVENT = VT.V_ID_VENTA "+
                                            "WHERE CK.ID_CAJA = '"+Properties.Settings.Default.id_caja+"' AND VT.V_TIPO_DOC LIKE  '%"+ v_tipo_doc + "%'  AND VT.V_NUMERO LIKE '%"+ v_numero + "%'"+  
                                            " AND VT.C_DESCRIPCION LIKE '%"+ v_nomcliente + "%' AND VT.C_RUC_DNI LIKE '%"+ v_rucdni + "%' AND VT.V_FECHA_ANULADO IS NULL ORDER BY CK.ID_COMPVENT DESC", con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvClientes.DataSource = dt;
            
            dgvClientes.Columns[1].HeaderText = "COD.VENTA";
            dgvClientes.Columns[2].HeaderText = "MOVIMIENTO";
            dgvClientes.Columns[3].HeaderText = "T. DOC";
            dgvClientes.Columns[4].HeaderText = "NUMERO DOC";
            dgvClientes.Columns[5].HeaderText = "NOM CLIENTE";
            dgvClientes.Columns[6].HeaderText = "RUC/DNI";
            dgvClientes.Columns[7].HeaderText = "FECHA";
            dgvClientes.Columns[8].HeaderText = "T. PAGO";
            dgvClientes.Columns[9].Visible = false;
            dgvClientes.Columns[10].Visible = true;
            dgvClientes.Columns[10].HeaderText = "T. MOV";
            dgvClientes.Columns[11].HeaderText = "IMPORTE SOLES";
            dgvClientes.Columns[12].Visible = false;
            dgvClientes.Columns[13].Visible = false;
            dgvClientes.Columns[14].Visible = false;
            dgvClientes.Columns[15].Visible = false;
            dgvClientes.Columns[16].Visible = false;
            dgvClientes.Columns[17].Visible = false;
            dgvClientes.Columns[18].Visible = false;
            dgvClientes.Columns[19].Visible = false;
            dgvClientes.Columns[20].Visible = false;
            dgvClientes.Columns[21].HeaderText = "ANULADO";
            dgvClientes.Columns[22].Visible = false;
            dgvClientes.Columns[23].Visible = false;
            
            con.Close();
            
        }


        public void CARGAR_DATOS_ID_VTA_NUMERO()
        {
            string v_nomcliente = txtNOMCLIENTE.Text;
            string v_rucdni = txtRUCDNI.Text;
            string v_tipo_doc = cboTipoDoc.SelectedValue.ToString();
            string v_id_venta = txtIDVENTA.Text;
            string v_numero = txtNUMERODOC.Text;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT  CK.ID_COMPVENT,CK.ID_MOVIMIENTO,VT.V_TIPO_DOC, VT.V_NUMERO, VT.C_DESCRIPCION, VT.C_RUC_DNI, CK.FECHA," +
                                            "CK.TP_DESCRIPCION, CK.ID_TIPOMOV, CK.TM_DESCRIPCION, CK.IMPORTE, CK.MONEDA, CK.TIPO_CAMBIO, CK.AMORTIZADO," +
                                            "CK.IMPORTE_CAJA, CK.ID_CAJA, CK.SALDO_INICIAL, CK.SALDO_FINAL, CK.EMPLEADO, CK.PV_DESCRIPCION, CK.S_DESCRIPCION, CK.FECHA_ANULADO, CK.DESCRIPCION,vt.C_DIRECCION" +
                                            " FROM V_CAJA_KADEX AS CK  INNER JOIN V_TABLA_VENTAS AS VT ON CK.ID_COMPVENT = VT.V_ID_VENTA " +
                                            "WHERE CK.ID_CAJA = '" + Properties.Settings.Default.id_caja + "' AND VT.V_TIPO_DOC LIKE  '%" + v_tipo_doc + "%' AND CK.ID_COMPVENT LIKE '%" + v_id_venta + "%' AND VT.V_NUMERO LIKE '%" + v_numero + "%'" +
                                            " AND VT.V_FECHA_ANULADO IS NULL ORDER BY CK.ID_COMPVENT DESC", con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvClientes.DataSource = dt;

            dgvClientes.Columns[1].HeaderText = "COD.VENTA";
            dgvClientes.Columns[2].HeaderText = "MOVIMIENTO";
            dgvClientes.Columns[3].HeaderText = "T. DOC";
            dgvClientes.Columns[4].HeaderText = "NUMERO DOC";
            dgvClientes.Columns[5].HeaderText = "NOM CLIENTE";
            dgvClientes.Columns[6].HeaderText = "RUC/DNI";
            dgvClientes.Columns[7].HeaderText = "FECHA";
            dgvClientes.Columns[8].HeaderText = "T. PAGO";
            dgvClientes.Columns[9].Visible = false;
            dgvClientes.Columns[10].Visible = true;
            dgvClientes.Columns[10].HeaderText = "T. MOV";
            dgvClientes.Columns[11].HeaderText = "IMPORTE SOLES";
            dgvClientes.Columns[12].Visible = false;
            dgvClientes.Columns[13].Visible = false;
            dgvClientes.Columns[14].Visible = false;
            dgvClientes.Columns[15].Visible = false;
            dgvClientes.Columns[16].Visible = false;
            dgvClientes.Columns[17].Visible = false;
            dgvClientes.Columns[18].Visible = false;
            dgvClientes.Columns[19].Visible = false;
            dgvClientes.Columns[20].Visible = false;
            dgvClientes.Columns[21].HeaderText = "ANULADO";
            dgvClientes.Columns[22].Visible = false;
            dgvClientes.Columns[23].Visible = false;
            con.Close();

        }


        private void button1_Click(object sender, EventArgs e)
        {/*
            vFILTRO = " ESTADO = 1";
            CARGAR_DATOS(CONCATENAR_CONDICION());
            */
        }
        /*-------------------popup-message---------------------*/
        
        public void ShowMyDialogBox(string mensaje)
        {
            Form2 testDialog = new Form2();
           testDialog.lblCODIGO.Text = mensaje;
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                if (testDialog.txtCODIGO.Text == "NETBIOS2017")
                {
                    P_IMPRIMIR_GRABAR();
                    testDialog.Close();
                }
                else if (testDialog.txtCODIGO.Text != "NETBIOS2017")
                {
                    string mensaje2= "INGRESE CODIGO CORRECTO";
                    testDialog.txtCODIGO.Text = string.Empty;
                    testDialog.Dispose();
                    ShowMyDialogBox(mensaje2);
                }

            }
            
        }
        /*-------------------popup-message---------------------*/






        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvClientes.Columns[e.ColumnIndex].Name == "colBotones" && dgvClientes.CurrentRow.Cells[3].Value.ToString() == "TB") //boton imprimir detro del gridview
                {
                    NOMCLIENTE = dgvClientes.CurrentRow.Cells[5].Value.ToString();
                    RUCDNI = dgvClientes.CurrentRow.Cells[6].Value.ToString();
                    DIRECLIENTE = dgvClientes.CurrentRow.Cells[24].Value.ToString();
                    MOVIMIENTHO = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                    ShowMyDialogBox(mensaje_);
                }
            }
            catch(Exception) { }
                
        }

        private void button1_DragOver(object sender, DragEventArgs e)
        {
            //button1.BackColor= Color.DeepSkyBlue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CAJA OBJCAJA = new CAJA();

            OBJCAJA.txtIDcaja.Text = Properties.Settings.Default.id_caja;
            OBJCAJA.Visible = true;
            this.Close();

        }

        private void txtNOMCLIENTE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
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

        }

        private void txtRUCDNI_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void txtNOMCLIENTE_TextChanged(object sender, EventArgs e)
        {
            autocompletar_DESCRIPCION();
        }

        private void txtRUCDNI_TextChanged(object sender, EventArgs e)
        {
            autocompletar_dni_ruc();
        }

        private void txtIDVENTA_TextChanged(object sender, EventArgs e)
        {
            autocompletar_ID_VENTA();
        }

        private void cboTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CARGAR_DATOS_ID_VTA_NUMERO();
        }

        private void txtNUMERODOC_TextChanged(object sender, EventArgs e)
        {
            autocompletar_NUMERO();
        }

        void P_IMPRIMIR_GRABAR()
        {
            string DIRECCION = "";
            string RUC = "";
            string ID_VENTA = "";
            string NUMERO = "";
            string MAQREG = "";
            string puntoventadesc = "";
            string WEB;
            string SERIE;
            string TICKETNUMERO;
            con.Open();
            SqlCommand cmv = new SqlCommand("SELECT V_ID_VENTA,V_NUMERO,E_DIRECCION,E_RUC,E_WEB_SITE,PV_SERIE_MAQREG, PV_DESCRIPCION FROM V_TABLA_VENTAS WHERE V_ID_VENTA = '" + dgvClientes.CurrentRow.Cells[1].Value.ToString() + "'" /*"(SELECT TOP 1 V_ID_VENTA FROM V_TABLA_VENTAS ORDER BY V_ID_VENTA DESC)"*/, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmv);
            da.Fill(dt);
            ID_VENTA = dt.Rows[0][0].ToString();
            NUMERO = dt.Rows[0][1].ToString();
            DIRECCION = dt.Rows[0][2].ToString();
            RUC = dt.Rows[0][3].ToString();
            WEB = dt.Rows[0][4].ToString();
            MAQREG = dt.Rows[0][5].ToString();
            puntoventadesc = dt.Rows[0][6].ToString();
            TICKETNUMERO = (Convert.ToInt32(NUMERO) + 1).ToString();
            SERIE = Properties.Settings.Default.serie;
            con.Close();

            /*----------------DETALLE REIMPRESIONES-------------------*/
            con.Open();
            SqlCommand cmd = new SqlCommand("select	DV.VD_ID_VENTA,TV.V_NUMERO,DV.VD_ID_BIEN,DV.VD_ITEM,DV.VD_ITEM, DV.VD_CANTIDAD, DV.VD_PRECIO, DV.VD_IMPORTE," +
                                           " TV.v_igv,TV.V_TOTAL,DV.VD_SALDO_CANTIDAD, DV.B_DESCRIPCION, DV.B_ID_UNIDMED,TV.C_DESCRIPCION, TV.C_RUC_DNI " +
                                           " from V_TABLA_VENTADETALLE AS DV INNER JOIN V_TABLA_VENTAS AS TV ON DV.VD_ID_VENTA = TV.V_ID_VENTA" +
                                           " INNER JOIN V_CAJA_KADEX AS CK ON DV.VD_ID_VENTA = CK.ID_COMPVENT where   CK.ID_COMPVENT = '" + dgvClientes.CurrentRow.Cells[1].Value.ToString() + "' ", con);
            DataTable dt2 = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            dap.Fill(dt2);
            dgvDETREIMPRESION.DataSource = dt2;
            
            
            string IGV = dt2.Rows[0][8].ToString();
            string TOTAL = dt2.Rows[0][9].ToString();
            string SUBTOTAL = (Convert.ToDouble(TOTAL) - Convert.ToDouble(IGV)).ToString();

            con.Close();

            /*-------------------------------------------------------*/


            CreaTicket Ticket1 = new CreaTicket();
            Ticket1.impresora = "BIXOLON SRP-270";

            Ticket1.TextoCentro(Properties.Settings.Default.nomempresa);
            Ticket1.TextoCentro("RUC: " + RUC);
            Ticket1.LineasGuion(); // imprime una linea de guiones

            Ticket1.TextoCentro(Properties.Settings.Default.nomsede);
            Ticket1.TextoCentro(DIRECCION);
            Ticket1.LineasGuion(); // imprime una linea de guiones

            Ticket1.TextoCentro("MAQ. REG: " + MAQREG);
            Ticket1.TextoCentro(DateTime.Now.ToString());

            string TIP_DOC;
            TIP_DOC = cboTipoDoc.SelectedItem.ToString();

            //P_SERIE_Y_NUMERO_CORRELATIVO_POR_PTOVENTA(TIP_DOC, CBOPTOVENTA.Text);
            Ticket1.TextoCentro("TICKET: " + "TB" + " " + Properties.Settings.Default.serie + "-" + NUMERO);
            Ticket1.LineasGuion();


            //DGVPEDIDO["MONEDA", fila].Value.ToString();

            Ticket1.TextoIzquierda("CANT  DETALLE                    IMPORTE");
            for (int i = 0; i < dgvDETREIMPRESION.Rows.Count-1; i++)
            {
                Ticket1.TextoExtremos(" " + dgvDETREIMPRESION.Rows[i].Cells[5].Value.ToString() + " " + dgvDETREIMPRESION.Rows[i].Cells[11].Value.ToString(), Convert.ToDecimal(dgvDETREIMPRESION.Rows[i].Cells[7].Value.ToString()).ToString("N2"));
            }

            Ticket1.LineasTotales();

            Ticket1.TextoExtremos("SubTotal:", SUBTOTAL);
            Ticket1.TextoExtremos("IGV: ", IGV);
            Ticket1.TextoExtremos("Total: ", TOTAL);
            Ticket1.TextoCentro("");
            
            if (NOMCLIENTE != "")
            {
                Ticket1.TextoExtremos("CLIENTE: ", NOMCLIENTE);
                Ticket1.TextoExtremos("RUC/DNI: ", RUCDNI);
                Ticket1.TextoExtremos("DIRECCION: ", DIRECLIENTE);
            }
            Ticket1.LineasGuion(); // imprime una linea de guiones
            Ticket1.TextoCentro("P.V:" + puntoventadesc);
            Ticket1.TextoCentro("CAJERO: " + Properties.Settings.Default.nomempleado);
            Ticket1.TextoCentro("PAGINA WEB: " + WEB);
            Ticket1.TextoCentro("ID VENTA: " + ID_VENTA);
            
            Ticket1.LineasGuion();
            Ticket1.TextoCentro("Agradecemos su Preferencia"); // imprime en el centro "Venta mostrador"
            Ticket1.TextoCentro("Vuelva pronto!! Lo esperamos"); // imprime en el centro "Venta mostrador"
            Ticket1.CortaTicket();

            DataTable DATOS_VENTA = new DataTable();                         //ESTO ME PERMITE CREAR EL DATATABLE PARA LLAMAR A LOS DATOS DE MI VENTA
            /*string ID_VENTA = E_OBJMANT_VENTADET.ID_VENTA;*/                   // ESTO PERMITE GENERAR LA VARIABLE DEL ID_VENTA
            DATOS_VENTA = N_OBJCLIENTE.CAPTURAR_TABLA_VENTA(ID_VENTA, Program.id_sede);        //ESTO ME PERMITE ALMACENAR TODOS LOS DATOS EN UN DATATABLE PARA PODER ACCEDER A ELLO EN TODO MOMENTO

            DataTable DATOS_VENTADETALLE = new DataTable();                  //ESTO ME PERMITE CREAR EL DATATABLE PARA LLAMAR A LOS DATOS DE MI VENTA_DETALLE
            /*string COD_VENTA = E_OBJMANT_VENTADET.ID_VENTA;  */          // ESTO PERMITE GENERAR LA VARIABLE DEL ID_VENTA
            DATOS_VENTADETALLE = N_OBJCLIENTE.CAPTURAR_TABLA_VENTADETALLE(ID_VENTA); //ESTO ME PERMITE ALMACENAR TODOS LOS DATOS EN UN DATATABLE PARA PODER ACCEDER A ELLO EN TODO MOMENTO

            /*---------------------IMPRIMIR TICKET PEQUEÑO-------------------------*/
            for (int f = 0; f < DATOS_VENTA.Rows.Count; f++)
            {
                if (DATOS_VENTADETALLE.Rows[f]["B_EMITE_TICKET"].Equals(true))
                {
                    //Ticket1.TextoCentro( DATOS_VENTA.Rows[0][36].ToString()); //aqui va el nombre de la empresa
                    Ticket1.TextoCentro(Properties.Settings.Default.nomsede); //nombre de la sede
                    Ticket1.LineasGuion();
                    Ticket1.TextoCentro("TICKET DESPACHO");
                    Ticket1.TextoCentro("REFERENCIA: " + DATOS_VENTA.Rows[0][3].ToString() + " " + DATOS_VENTA.Rows[0][1].ToString() + "-" + DATOS_VENTA.Rows[0][2].ToString()); //aqui va el tipo_documento / el numero de serie / y el numero correlativo
                    Ticket1.LineasGuion();
                    Ticket1.TextoCentro("");
                    Ticket1.TextoCentro("CANTIDAD: " + Convert.ToInt32(DATOS_VENTADETALLE.Rows[f]["VD_CANTIDAD"]) + "");
                    Ticket1.TextoCentro("");
                    Ticket1.TextoCentro("DESCRIPCION: ");
                    Ticket1.TextoCentro(DATOS_VENTADETALLE.Rows[f]["B_DESCRIPCION"].ToString());
                    Ticket1.TextoCentro("");
                    Ticket1.LineasGuion();
                    Ticket1.TextoCentro("ATENCION: " + DATOS_VENTA.Rows[0]["V_CLIENTE"].ToString());
                    Ticket1.TextoCentro(DATOS_VENTA.Rows[0][4].ToString());   //aqui va la fecha Y EL ID_VENTA
                    Ticket1.TextoCentro("ID_VENTA: " + DATOS_VENTA.Rows[0][0].ToString());//aqui va el codigo de venta
                    Ticket1.TextoCentro("AGRADECEMOS SU PREFERENCIA!!!");
                    Ticket1.CortaTicket();
                }
            }

            /*-------------------------------------------------------------------------*/




        }

        #region CODIGO IMPRESION
        /* ================================================ METODO PARA GENERAR TICKET 1 PARTE ===============================================================*/
        /* ================================================ METODO PARA GENERAR TICKET 1 PARTE ===============================================================*/
        /* ================================================ METODO PARA GENERAR TICKET 1 PARTE ===============================================================*/
        /* ================================================ METODO PARA GENERAR TICKET 1 PARTE ===============================================================*/

        public class CreaTicket
        {
            public string impresora;
            //{

            string ticket = "";
            string parte1, parte2;
            //string impresora = "\\\\FARMACIA-PVENTA\\Generic / Text Only"; // nombre exacto de la impresora como esta en el panel de control
            //string impresora = "Generic / Text Only"; // nombre exacto de la impresora como esta en el panel de control
            // string impresora = NombreImpresora; // nombre exacto de la impresora como esta en el panel de control
            int max, cort;
            public void LineasGuion()
            {
                ticket = "----------------------------------------\n";   // agrega lineas separadoras -
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
            }
            public void LineasAsterisco()
            {
                ticket = "****************************************\n";   // agrega lineas separadoras *
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
            }
            public void LineasIgual()
            {
                ticket = "========================================\n";   // agrega lineas separadoras =
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
            }
            public void LineasTotales()
            {
                ticket = "                             -----------\n"; ;   // agrega lineas de total
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
            }
            public void EncabezadoVenta()
            {
                //ticket = "Articulo        Can    P.Unit    Importe\n";   // agrega lineas de  encabezados
                ticket = "Cant       Articulo              Importe\n";   // agrega lineas de  encabezados
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            }
            public void TextoIzquierda(string par1)                          // agrega texto a la izquierda
            {
                max = par1.Length;
                if (max > 40)                                 // **********
                {
                    cort = max - 40;
                    parte1 = par1.Remove(40, cort);        // si es mayor que 40 caracteres, lo corta
                }
                else { parte1 = par1; }                      // **********
                ticket = parte1 + "\n";
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            }
            public void TextoDerecha(string par1)
            {
                ticket = "";
                max = par1.Length;
                if (max > 40)                                 // **********
                {
                    cort = max - 40;
                    parte1 = par1.Remove(40, cort);           // si es mayor que 40 caracteres, lo corta
                }
                else { parte1 = par1; }                      // **********
                max = 40 - par1.Length;                     // obtiene la cantidad de espacios para llegar a 40
                for (int i = 0; i < max; i++)
                {
                    ticket += " ";                          // agrega espacios para alinear a la derecha
                }
                ticket += parte1 + "\n";                    //Agrega el texto
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            }
            public void TextoCentro(string par1)
            {
                ticket = "";
                max = par1.Length;
                if (max > 40)                                 // **********
                {
                    cort = max - 40;
                    parte1 = par1.Remove(40, cort);          // si es mayor que 40 caracteres, lo corta
                }
                else { parte1 = par1; }                      // **********
                max = (int)(40 - parte1.Length) / 2;         // saca la cantidad de espacios libres y divide entre dos
                for (int i = 0; i < max; i++)                // **********
                {
                    ticket += " ";                           // Agrega espacios antes del texto a centrar
                }                                            // **********
                ticket += parte1 + "\n";
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            }
            public void TextoExtremos(string par1, string par2)
            {
                max = par1.Length;
                if (max > 25)                                 // **********
                {
                    cort = max - 25;
                    parte1 = par1.Remove(25, cort);          // si par1 es mayor que 18 lo corta
                }
                else { parte1 = par1; }                      // **********
                ticket = parte1;                             // agrega el primer parametro
                max = par2.Length;
                if (max > 25)                                 // **********
                {
                    cort = max - 25;
                    parte2 = par2.Remove(25, cort);          // si par2 es mayor que 18 lo corta
                }
                else { parte2 = par2; }
                max = 40 - (parte1.Length + parte2.Length);
                for (int i = 0; i < max; i++)                 // **********
                {
                    ticket += " ";                            // Agrega espacios para poner par2 al final
                }                                             // **********
                ticket += parte2 + "\n";                     // agrega el segundo parametro al final
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            }
            public void AgregaTotales(string par1, double total)
            {
                max = par1.Length;
                if (max > 25)                                 // **********
                {
                    cort = max - 25;
                    parte1 = par1.Remove(25, cort);          // si es mayor que 25 lo corta
                }
                else { parte1 = par1; }                      // **********
                ticket = parte1;
                parte2 = total.ToString("");
                max = 40 - (parte1.Length + parte2.Length);
                for (int i = 0; i < max; i++)                // **********
                {
                    ticket += " ";                           // Agrega espacios para poner el valor de moneda al final
                }                                            // **********
                ticket += parte2 + "\n";
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            }
            //public void AgregaArticulo(string par1, int cant, double precio, double total)
            //{
            //    if (cant.ToString().Length <= 3 && precio.ToString("c").Length <= 10 && total.ToString("c").Length <= 11) // valida que cant precio y total esten dentro de rango
            //    {
            //        max = par1.Length;
            //        if (max > 16)                                 // **********
            //        {
            //            cort = max - 16;
            //            parte1 = par1.Remove(16, cort);          // corta a 16 la descripcion del articulo
            //        }
            //        else { parte1 = par1; }                      // **********
            //        ticket = parte1;                             // agrega articulo
            //        max = (3 - cant.ToString().Length) + (16 - parte1.Length);
            //        for (int i = 0; i < max; i++)                // **********
            //        {
            //            ticket += " ";                           // Agrega espacios para poner el valor de cantidad
            //        }
            //        ticket += cant.ToString();                   // agrega cantidad
            //        max = 10 - (precio.ToString("").Length);
            //        for (int i = 0; i < max; i++)                // **********
            //        {
            //            ticket += " ";                           // Agrega espacios
            //        }                                            // **********
            //        ticket += precio.ToString(""); // agrega precio
            //        max = 11 - (total.ToString().Length);
            //        for (int i = 0; i < max; i++)                // **********
            //        {
            //            ticket += " ";                           // Agrega espacios
            //        }                                            // **********
            //        ticket += total.ToString("") + "\n"; // agrega precio
            //        RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            //    }
            //    else
            //    {
            //        MessageBox.Show("Valores fuera de rango");
            //        RawPrinterHelper.SendStringToPrinter(impresora, "Error, valor fuera de rango\n"); // imprime texto
            //    }
            //}
            //*****************************+

            //public void AgregaArticulo(string cant, string par1, double precio, double total)
            public void AgregaArticulo(string cant, string par1, string total)
            {
                //if (cant.ToString().Length <= 7 && precio.ToString("c").Length <= 10 && total.ToString("c").Length <= 18) // valida que cant precio y total esten dentro de rango
                if (cant.ToString().Length <= 7 && total.ToString().Length <= 15) // valida que cant precio y total esten dentro de rango
                {

                    ticket = "";
                    max = (7 - cant.ToString().Length);

                    for (int i = 0; i < max; i++)                // **********
                    {
                        ticket += " ";                           // Agrega espacios para poner el valor de cantidad
                    }
                    ticket += cant.ToString();                   // agrega cantidad
                                                                 //**************************************************************+
                    max = par1.Length;
                    if (max > 18)                                 // **********
                    {
                        cort = max - 18;
                        parte1 = par1.Remove(18, cort);          // corta a 16 la descripcion del articulo
                    }
                    else { parte1 = par1; }                      // **********
                    ticket += " " + parte1.ToString(); // agrega articulo

                    max = 15 - (total.ToString().Length);
                    for (int i = 0; i < max; i++)                // **********
                    {
                        ticket += " ";                           // Agrega espacios
                    }                                            // **********
                    ticket += total.ToString() + "\n"; // agrega total linea
                    RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
                }
                else
                {
                    String formato = String.Format("<script>javascript:mensaje('VALORES FUERA DE RANGO');</script>");

                    // MessageBox.Show("Valores fuera de rango");
                    RawPrinterHelper.SendStringToPrinter(impresora, "Error, valor fuera de rango\n"); // imprime texto
                }
            }
            //***************************************+
            public void CortaTicket()
            {
                string corte = "\x1B" + "m";                  // caracteres de corte
                string avance = "\x1B" + "d" + "\x09";        // avanza 9 renglones
                RawPrinterHelper.SendStringToPrinter(impresora, avance); // avanza
                RawPrinterHelper.SendStringToPrinter(impresora, corte); // corta
            }
            public void AbreCajon()
            {
                string cajon0 = "\x1B" + "p" + "\x00" + "\x0F" + "\x96";                  // caracteres de apertura cajon 0
                string cajon1 = "\x1B" + "p" + "\x01" + "\x0F" + "\x96";                 // caracteres de apertura cajon 1
                RawPrinterHelper.SendStringToPrinter(impresora, cajon0); // abre cajon0
                                                                         //RawPrinterHelper.SendStringToPrinter(impresora, cajon1); // abre cajon1
            }
        }




        /*===============================================================================================================================================*/
        /* ================================================ METODOS TICKET 2 PARTE ===============================================================*/

        public class RawPrinterHelper
        {
            // Structure and API declarions:
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

            // SendBytesToPrinter()
            // When the function is given a printer name and an unmanaged array
            // of bytes, the function sends those bytes to the print queue.
            // Returns true on success, false on failure.
            public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
            {
                Int32 dwError = 0, dwWritten = 0;
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA();
                bool bSuccess = false; // Assume failure unless you specifically succeed.

                di.pDocName = "My C#.NET RAW Document";
                di.pDataType = "RAW";

                // Open the printer.
                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {
                    // Start a document.
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        // Start a page.
                        if (StartPagePrinter(hPrinter))
                        {
                            // Write your bytes.
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }
                // If you did not succeed, GetLastError may give more information
                // about why not.
                if (bSuccess == false)
                {
                    dwError = Marshal.GetLastWin32Error();
                }
                return bSuccess;
            }

            public static bool SendStringToPrinter(string szPrinterName, string szString)
            {
                IntPtr pBytes;
                Int32 dwCount;
                // How many characters are in the string?
                dwCount = szString.Length;
                // Assume that the printer is expecting ANSI text, and then convert
                // the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                // Send the converted ANSI string to the printer.
                SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);
                return true;
            }
        }

        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void btnLIMPIAR_Click(object sender, EventArgs e)
        {
            txtIDVENTA.Text = "";
            txtNUMERODOC.Text = "";
            txtNOMCLIENTE.Text = "";
            txtRUCDNI.Text = "";
        }
    }
}
