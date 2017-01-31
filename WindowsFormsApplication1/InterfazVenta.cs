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
using System.Globalization;
using System.Net.NetworkInformation;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class InterfazVenta : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        #region variables globales 
        public string v_id_caja;
        public string v_serie;
        public string v_id_puntoventa;
        public string v_id_empleado;
        public string v_id_empresa;
        public string v_nombre_empleado;
        public string v_tipo_cambio;
        public string v_sede;
        public string v_fchapertura;
        public string v_fchacierre;
        public string v_saldo_ini;
        public string v_saldo_fin;
        /*----                       ----*/
        public string v_tipo_doc;
        public string v_ind_tipo_doc;
        public string v_id_bien;
        public string v_desc_bien;
        public string v_precio_bien;
        public string v_llamabien;
        public string v_numeroticket;
        /*-------------------------------*/
        #endregion

        #region variables de retorno buscar cliente
        public string POP_id_cliente = string.Empty;
        public string POP_ruc_dni = string.Empty;
        public string POP_descripcion = string.Empty;
        public int suma = 0;
        #endregion
        
        public string[] valor = new string[36];
        public string[] idbien = new string[36];
        public string[] PRECIO_BIEN = new string[36];
        public String MON = "";
        public String WEB = "";
        public double VUELTO = 0.00, PAGA = 0.00;

        public string res = "";
        public string res1 = "";
        public string res2 = "";


        //public DataTable detallebien = new DataTable();
        public DataTable vPdt_detBien = new DataTable();

        public InterfazVenta()
        {
            InitializeComponent();

        }
        private void InterfazVenta_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            lblTicket.Text = v_numeroticket;
            lblSerie.Text = Properties.Settings.Default.serie;
            lblEmpresa.Text = Properties.Settings.Default.nomempresa;
            lblUsuario.Text = Properties.Settings.Default.nomempleado;
            lblSede.Text = Properties.Settings.Default.nomsede;
            lblFecha.Text = DateTime.Today.ToShortDateString();
            txtTIPO_PAGO.Enabled = false;
            //txtCLIENTE_ID.Enabled = false;
            LLENAR_CLASE_BIEN();
            LLENAR_MENU_BIENES();
            TIPO_PAGO();
            TIPO_DOC();
            ESTRUCTURA_DETALLEBIEN();
            lblCajaIDVentas.Text = Properties.Settings.Default.id_caja;
            dgvBIEN_VENTA.Visible = false;
            LLENAR_GRILLA();
            // DataTable vPdt_detBien = (DataTable)detalle;
            
            /*----------*/
            //crea boton Eliminar en el gridview
            DataGridViewButtonColumn colBotonEliminar = new DataGridViewButtonColumn();
            colBotonEliminar.Name = "colBotonEliminar";
            colBotonEliminar.HeaderText = "Eliminar";
            colBotonEliminar.Text = "Eliminar";
            colBotonEliminar.UseColumnTextForButtonValue = true;
            colBotonEliminar.FlatStyle = FlatStyle.Flat;
            colBotonEliminar.InheritedStyle.BackColor = Color.Honeydew;
            this.dgvBIEN_VENTA.Columns.Add(colBotonEliminar);

            /*-------------------------------------------------------------------------------------------*/
            txtCANTIDAD_VENTA.Text = "1";
            txtPRECIO_VENTA.Text = string.Empty;

            if (v_id_bien != string.Empty)  //AQUI EJECUTO EL LLENADO DEL BIEN SI ESQUE UBIERAN DATOS QUE REGISTRAR
            {

                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(v_id_bien, v_desc_bien, v_precio_bien);

                v_id_bien = string.Empty;
                v_desc_bien = string.Empty;
                v_precio_bien = string.Empty;
            }

            LLENAR_GRILLA(); //ESTO PERMITE QUE SE MUESTRE LOS DATOS DE LA GRILLA A PESAR QUE SE AGA EL AUTOPOSBAC
            ACTUALIZAR_TOTALES(); //ESTO DEVUELVE LA ACTUALIZACION DE TOTALES
            timer1.Start();
        }



        #region OBJETOS
        N_VENTA N_OBJVENTAS = new N_VENTA();
        E_VENTA E_OBJVENTAS = new E_VENTA();
        E_MANT_CLIENTE E_OBJMANT_CLIENTE = new E_MANT_CLIENTE();
        E_VENTA_Y_DETALLE E_OBJMANT_VENTADET = new E_VENTA_Y_DETALLE();
        E_CAJA_KARDEX E_OBJCAJA_KARDEX = new E_CAJA_KARDEX();


        #endregion




        void LLENAR_CLASE_BIEN()
        {

            if ((Properties.Settings.Default.punto_venta == "PV003") || (Properties.Settings.Default.punto_venta == "PV008") || (Properties.Settings.Default.punto_venta == "PV009") || (Properties.Settings.Default.punto_venta == "PV014"))
            { //AQUI VAN LOS BIENES PARA RESTAURANT

                List<LISTA_CLASE_PROD> Lista = new List<LISTA_CLASE_PROD>();

                Lista.Add(new LISTA_CLASE_PROD { texto = "BEBIDAS", value = "C2" });
                Lista.Add(new LISTA_CLASE_PROD { texto = "COMIDA CRIOLLA", value = "C3" });
                Lista.Add(new LISTA_CLASE_PROD { texto = "COMIDA TIPICA", value = "C4" });
                Lista.Add(new LISTA_CLASE_PROD { texto = "COMIDA MARINA", value = "C5" });
                Lista.Add(new LISTA_CLASE_PROD { texto = "POLLOS Y PARRILLAS", value = "C6" });
                //cboCLASE_BIEN.Items.Add(Lista);
                cboCLASE_BIEN.DisplayMember = "texto";
                cboCLASE_BIEN.ValueMember = "value";
                cboCLASE_BIEN.DataSource = Lista;
                
                cboCLASE_BIEN.SelectedIndex = 1;
               // cboTIPO_DOC.SelectedIndex = 0;

            }
            else
            {
                List<LISTA_CLASE_PROD> Lista = new List<LISTA_CLASE_PROD>();
                Lista.Add(new LISTA_CLASE_PROD { texto = "SERVICIOS", value = "C1" });

                cboCLASE_BIEN.DataSource = Lista;
                cboCLASE_BIEN.DisplayMember = "texto";
                cboCLASE_BIEN.ValueMember = "value";
                cboCLASE_BIEN.SelectedIndex = 0;
            }

        }


        void TIPO_PAGO()
        {

            List<ListaTipoProd> List = new List<ListaTipoProd>();

            List.Add(new ListaTipoProd { texto = "EFECTIVO", value = "0001" });
            List.Add(new ListaTipoProd { texto = "TARJETA CREDITO", value = "0002" });
            List.Add(new ListaTipoProd { texto = "TARJETA DEBITO", value = "0003" });
            List.Add(new ListaTipoProd { texto = "DEPOSITO BANCARIO", value = "0004" });
            List.Add(new ListaTipoProd { texto = "TRANSFERENCIA BANCARIA", value = "0005" });
            List.Add(new ListaTipoProd { texto = "CHEQUE BANCARIO", value = "0006" });
            //List<string> List = new List<string>();

            //List.Add( "EFECTIVO", "0001");


            cboTIPOPAGO.DataSource = List;
            cboTIPOPAGO.DisplayMember = "texto";
            cboTIPOPAGO.ValueMember = "value";
            cboTIPOPAGO.SelectedIndex = 0;

        }

        void TIPO_DOC()
        {

            List<ListaTipoProd> List = new List<ListaTipoProd>();

            List.Add(new ListaTipoProd { texto = "TICKET BOLETA", value = "TB" });
            //List.Add(new ListaTipoProd { texto = "BOLETA VENTA", value = "BV" });
           // List.Add(new ListaTipoProd { texto = "FACTURA VENTA", value = "FV" });


            cboTIPO_DOC.DataSource = List;
            cboTIPO_DOC.DisplayMember = "texto";
            cboTIPO_DOC.ValueMember = "value";
            cboTIPO_DOC.SelectedIndex = 0;

        }



        void LLENAR_MENU_BIENES()
        {
            string dato = "";
            dato = cboCLASE_BIEN.SelectedValue.ToString();
            DataTable dt = new DataTable();
            E_OBJVENTAS.ID_CLASE = cboCLASE_BIEN.SelectedValue.ToString();
            E_OBJVENTAS.ID_EMPRESA = Properties.Settings.Default.id_empresa;
            dt = N_OBJVENTAS.BIEN_X_CLASE(E_OBJVENTAS); //llenar el datatable con los datos del filtrado de bienes por clase

            for (int i = 0; i < 36; i++)
            {
                valor[i] = "";
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (i < 36) //esto controla los 16 botones asignados para los platos
                {
                    valor[i] = dt.Rows[i][1].ToString();     //esto permite obtener la descripcion y el precio de los bienes
                    idbien[i] = dt.Rows[i][0].ToString();     //esto permite obtener los codigos de cada bien que contiene el datatable
                    PRECIO_BIEN[i] = dt.Rows[i][2].ToString();

                }
            }

                btnBIEN01.Text = valor[0];
                btnBIEN02.Text = valor[1];
                btnBIEN03.Text = valor[2];
                btnBIEN04.Text = valor[3];
                btnBIEN05.Text = valor[4];
                btnBIEN06.Text = valor[5];
                btnBIEN07.Text = valor[6];
                btnBIEN08.Text = valor[7];
                btnBIEN09.Text = valor[8];
                btnBIEN10.Text = valor[9];
                btnBIEN11.Text = valor[10];
                btnBIEN12.Text = valor[11];
                btnBIEN13.Text = valor[12];
                btnBIEN14.Text = valor[13];
                btnBIEN15.Text = valor[14];
                btnBIEN16.Text = valor[15];
                btnBIEN17.Text = valor[16];
                btnBIEN18.Text = valor[17];
                btnBIEN19.Text = valor[18];
                btnBIEN20.Text = valor[19];
                btnBIEN21.Text = valor[20];
                btnBIEN22.Text = valor[21];
                btnBIEN23.Text = valor[22];
                btnBIEN24.Text = valor[23];
                btnBIEN25.Text = valor[24];
                btnBIEN26.Text = valor[25];
                btnBIEN27.Text = valor[26];
                btnBIEN28.Text = valor[27];
                btnBIEN29.Text = valor[28];
                btnBIEN30.Text = valor[29];
                btnBIEN31.Text = valor[30];
                btnBIEN32.Text = valor[31];
                btnBIEN33.Text = valor[32];
                btnBIEN34.Text = valor[33];
                btnBIEN35.Text = valor[34];
                btnBIEN36.Text = valor[35];


        }

        void ESTRUCTURA_DETALLEBIEN()
        {

            DataColumn colum = vPdt_detBien.Columns.Add("ID_BIEN", typeof(String));
            colum.Unique = true;
            vPdt_detBien.Columns.Add(new DataColumn("CANT", typeof(double)));
            vPdt_detBien.Columns.Add(new DataColumn("DESCRIPCION", typeof(String)));
            vPdt_detBien.Columns.Add(new DataColumn("PRECIO", typeof(Double)));
            vPdt_detBien.Columns.Add(new DataColumn("IMPORTE", typeof(Double)));
            vPdt_detBien.PrimaryKey = new DataColumn[] { vPdt_detBien.Columns[0] };
            //estructura de la tabladetalle

        }

        void OBTENER_ID_BIEN_Y_LLENAR_GRILLA(string ID_BIEN, string DESCRIPCION, string PRECIO)
        {
            if (dgvBIEN_VENTA.Visible == false) { dgvBIEN_VENTA.Visible = true; }
            DataTable dt = vPdt_detBien;
            try
            {
                DataRow row = dt.NewRow();
                row["ID_BIEN"] = ID_BIEN;
                row["CANT"] = Convert.ToDouble(txtCANTIDAD_VENTA.Text); //
                row["DESCRIPCION"] = DESCRIPCION;
                if (txtPRECIO_VENTA.Text != string.Empty) // si es vacio tomo el precio del texbox precioventa
                {
                    row["PRECIO"] = Convert.ToDouble(txtPRECIO_VENTA.Text);
                }
                else //sino tomo el precio de la base de datos q esta en el parametro PRECIO
                {
                    row["PRECIO"] = Convert.ToDouble(PRECIO);
                }

                row["IMPORTE"] = Convert.ToDouble(row["PRECIO"]) * Convert.ToDouble(row["CANT"]);
                dt.Rows.Add(row);
                dt.AcceptChanges();

                LLENAR_GRILLA();
                ACTUALIZAR_TOTALES();

                //aqui limpio la data de ingreso de precio y cantidad de cada bien
                txtCANTIDAD_VENTA.Text = "1";
                txtPRECIO_VENTA.Text = string.Empty;

                txtCANTIDAD_VENTA.Focus();
            }
            catch (Exception)
            {

                // MessageBox.Show("EL BIEN YA ESTA EN LA LISTA");

            }
        }

        void LLENAR_GRILLA()
        {
            DataTable dt = vPdt_detBien;
            dgvBIEN_VENTA.DataSource = dt;
            dgvBIEN_VENTA.Columns[0].Width = 70;
            dgvBIEN_VENTA.Columns[1].Width = 40;
            dgvBIEN_VENTA.Columns[2].Width = 300;
            dgvBIEN_VENTA.Columns[3].Width = 50;
            dgvBIEN_VENTA.Columns[4].Width = 60;

        }

        public void ACTUALIZAR_TOTALES()
        {
            double subTotal, igv, total = 0;
            DataTable dt = (DataTable)vPdt_detBien;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total = total + Convert.ToDouble(dt.Rows[i][4].ToString());

            }
            subTotal = (total / 1.18);
            igv = total - subTotal;


            lblSUBTOTAL.Text = subTotal.ToString("N2");
            lblIGV.Text = igv.ToString("N2");
            lblTOTAL.Text = total.ToString("N2");

        }
        /*-----------------------AUTOCOMPLETAR---------------------------*/
        //void autocompletar_DESCRIPCION()
        //{
        //    try
        //    {
        //        txtCLIENTE_VENTA.AutoCompleteMode = AutoCompleteMode.Suggest;
        //        txtCLIENTE_VENTA.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //        txtCLIENTE_RUC.AutoCompleteMode = AutoCompleteMode.Suggest;
        //        txtCLIENTE_RUC.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //        AutoCompleteStringCollection col = new AutoCompleteStringCollection();
        //        AutoCompleteStringCollection ruc = new AutoCompleteStringCollection();

        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("SELECT DESCRIPCION FROM CLIENTE", con);
        //        /* DataTable dt = new DataTable();
        //         SqlDataAdapter da = new SqlDataAdapter(cmd);
        //         da.Fill(dt);*/
        //        SqlDataReader dr = null;

        //        dr = cmd.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            col.Add(dr["DESCRIPCION"].ToString());
        //        }
        //        dr.Close();
        //        txtCLIENTE_VENTA.AutoCompleteCustomSource = col;
        //        con.Close();
        //        con.Open();
        //        if (txtCLIENTE_VENTA.Text.Length >= 6)
        //        {
        //            SqlCommand cmv = new SqlCommand("SELECT ID_CLIENTE,RUC_DNI,DIRECCION FROM CLIENTE where DESCRIPCION = '" + txtCLIENTE_VENTA.Text + "'", con);
        //            DataTable dt = new DataTable();
        //            SqlDataAdapter da = new SqlDataAdapter(cmv);
        //            da.Fill(dt);
        //            txtCLIENTE_ID.Text = dt.Rows[0][0].ToString();
        //            txtCLIENTE_RUC.Text = dt.Rows[0][1].ToString();
        //            LBLDIRECCION.Text = dt.Rows[0][2].ToString();
        //            con.Close();
        //        }
        //        else { con.Close(); }
        //    }

        //    catch
        //    {
        //    }
        //}

        //void autocompletar_RUCDNI()
        //{
        //    try
        //    {


        //        //txtCLIENTE_RUC.AutoCompleteMode = AutoCompleteMode.Suggest;
        //        //txtCLIENTE_RUC.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //        AutoCompleteStringCollection col = new AutoCompleteStringCollection();

        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }
        //        SqlCommand cmd = new SqlCommand("SELECT RUC_DNI FROM CLIENTE", con);

        //        SqlDataReader dr = null;

        //        dr = cmd.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            col.Add(dr["RUC_DNI"].ToString());
        //        }
        //        dr.Close();
        //       // txtCLIENTE_RUC.AutoCompleteCustomSource = col;
        //        con.Close();
        //        con.Open();
        //        if (txtCLIENTE_RUC.Text.Length >= 4)
        //        {
        //            SqlCommand cmv = new SqlCommand("SELECT ID_CLIENTE,DESCRIPCION FROM CLIENTE where RUC_DNI = '" + txtCLIENTE_RUC.Text + "'", con);
        //            DataTable dt = new DataTable();
        //            SqlDataAdapter da = new SqlDataAdapter(cmv);
        //            da.Fill(dt);
        //            txtCLIENTE_ID.Text = dt.Rows[0][0].ToString();
        //            txtCLIENTE_VENTA.Text = dt.Rows[0][1].ToString();
        //            con.Close();
        //        }
        //        else { con.Close(); }
        //    }

        //    catch
        //    {
        //    }
        //}


        /*---------------------------------------------------------------*/


       

        private void button2_Click(object sender, EventArgs e)
        {
            //txtCLIENTE_VENTA.Text = string.Empty;
            //txtCLIENTE_ID.Text = string.Empty;
            //txtCLIENTE_RUC.Text = string.Empty;
            NUEVO_CLIENTE NC = new NUEVO_CLIENTE();
            NC.ShowDialog();

        }

        #region
        private void btnBIEN01_Click_1(object sender, EventArgs e)
        {

            if (idbien[0] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[0].ToString(), valor[0].ToString(), PRECIO_BIEN[0].ToString());
            }
        }

        private void btnBIEN02_Click(object sender, EventArgs e)
        {
            
            if (idbien[1] != null)
            {
                
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[1].ToString(), valor[1].ToString(), PRECIO_BIEN[1].ToString());

            }
        }

        protected void btnBIEN03_Click(object sender, EventArgs e)
        {
            
            if (idbien[2] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[2].ToString(), valor[2].ToString(), PRECIO_BIEN[2].ToString());
            }
        }

        protected void btnBIEN04_Click(object sender, EventArgs e)
        {
            
            if (idbien[3] != null )
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[3].ToString(), valor[3].ToString(), PRECIO_BIEN[3].ToString());
            }
        }

        protected void btnBIEN05_Click(object sender, EventArgs e)
        {
            
            if (idbien[4] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[4].ToString(), valor[4].ToString(), PRECIO_BIEN[4].ToString());
            }
        }

        protected void btnBIEN06_Click(object sender, EventArgs e)
        {
            
            if (idbien[5] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[5].ToString(), valor[5].ToString(), PRECIO_BIEN[5].ToString());
            }
        }

        protected void btnBIEN07_Click(object sender, EventArgs e)
        {
            
            if (idbien[6] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[6].ToString(), valor[6].ToString(), PRECIO_BIEN[6].ToString());
            }
        }

        protected void btnBIEN08_Click(object sender, EventArgs e)
        {
            
            if (idbien[7] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[7].ToString(), valor[7].ToString(), PRECIO_BIEN[7].ToString());
            }
        }

        protected void btnBIEN09_Click(object sender, EventArgs e)
        {
            
            if (idbien[8] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[8].ToString(), valor[8].ToString(), PRECIO_BIEN[8].ToString());
            }
        }

        protected void btnBIEN10_Click(object sender, EventArgs e)
        {
            
            if (idbien[9] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[9].ToString(), valor[9].ToString(), PRECIO_BIEN[9].ToString());
            }
        }

        protected void btnBIEN11_Click(object sender, EventArgs e)
        {
            
            if (idbien[10] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[10].ToString(), valor[10].ToString(), PRECIO_BIEN[10].ToString());
            }
        }

        protected void btnBIEN12_Click(object sender, EventArgs e)
        {
            
            if (idbien[11] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[11].ToString(), valor[11].ToString(), PRECIO_BIEN[11].ToString());
            }
        }

        protected void btnBIEN13_Click(object sender, EventArgs e)
        {
           
            if (idbien[12] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[12].ToString(), valor[12].ToString(), PRECIO_BIEN[12].ToString());
            }
        }

        protected void btnBIEN14_Click(object sender, EventArgs e)
        {
            
            if (idbien[13] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[13].ToString(), valor[13].ToString(), PRECIO_BIEN[13].ToString());
            }
        }

        protected void btnBIEN15_Click(object sender, EventArgs e)
        {
            
            if (idbien[14] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[14].ToString(), valor[14].ToString(), PRECIO_BIEN[14].ToString());
            }
        }

        protected void btnBIEN16_Click(object sender, EventArgs e)
        {
           
            if (idbien[15] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[15].ToString(), valor[15].ToString(), PRECIO_BIEN[15].ToString());
            }
        }
        protected void btnBIEN17_Click(object sender, EventArgs e)
        {
            
            if (idbien[16] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[16].ToString(), valor[16].ToString(), PRECIO_BIEN[16].ToString());
            }
        }
        protected void btnBIEN18_Click(object sender, EventArgs e)
        {
            
            if (idbien[17] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[17].ToString(), valor[17].ToString(), PRECIO_BIEN[17].ToString());
            }
        }
        protected void btnBIEN19_Click(object sender, EventArgs e)
        {
            
            if (idbien[18] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[18].ToString(), valor[18].ToString(), PRECIO_BIEN[18].ToString());
            }
        }
        protected void btnBIEN20_Click(object sender, EventArgs e)
        {
            if (idbien[19] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[19].ToString(), valor[19].ToString(), PRECIO_BIEN[19].ToString());
            }
        }

        #endregion


        public void Eliminar_Registro(String cod)
        {
            DataTable dt = (DataTable)vPdt_detBien;
            DataRow row;
            row = dt.Rows.Find(cod);
            row.Delete();
            row.AcceptChanges();
            LLENAR_GRILLA();
            ACTUALIZAR_TOTALES();
        }








        private void dgvBIEN_VENTA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (this.dgvBIEN_VENTA.Columns[e.ColumnIndex].Name == "colBotonEliminar") //boton eliminar detro del gridview
            {
                try
                {
                    dgvBIEN_VENTA.Rows.RemoveAt(e.RowIndex);
                    DataTable dt = (DataTable)vPdt_detBien;
                    dt.Rows.RemoveAt(e.RowIndex);
                }
                catch { }
            }
            ACTUALIZAR_TOTALES();

        }

        /*------------------------------------PARTE VENTAS---------------------------------------*/
        void MANTENIMIENTO_VENTA()
        {
            try
            {
                E_OBJMANT_VENTADET.ID_VENTA = string.Empty;
                E_OBJMANT_VENTADET.SERIE = Properties.Settings.Default.serie;
                E_OBJMANT_VENTADET.TIPO_DOC = cboTIPO_DOC.SelectedValue.ToString();
                E_OBJMANT_VENTADET.MONEDA = "S";
                E_OBJMANT_VENTADET.VALOR_VENTA = Convert.ToDouble(lblSUBTOTAL.Text);
                E_OBJMANT_VENTADET.IGV = Convert.ToDouble(lblIGV.Text);
                E_OBJMANT_VENTADET.TOTAL = Convert.ToDouble(lblTOTAL.Text);
                E_OBJMANT_VENTADET.SALDO = 0.00;
                E_OBJMANT_VENTADET.ID_SEDE = Properties.Settings.Default.id_sede;
                E_OBJMANT_VENTADET.ID_PEDIDO = null;
                E_OBJMANT_VENTADET.ID_CLIENTE = POP_id_cliente;
                if (Convert.ToDouble(lblTOTAL.Text) < 700)
                {
                    E_OBJMANT_VENTADET.CLIENTE = txtCliente.Text;
                }
                else
                {
                    E_OBJMANT_VENTADET.CLIENTE = POP_descripcion;
                }
                E_OBJMANT_VENTADET.ACCION = "1";

                res = N_OBJVENTAS.MANTENIMIENTO_VENTA(E_OBJMANT_VENTADET); //AQUI CARGO LA VENTA
                MANTENIMIENTO_VENTADETALLE();// AQUI CARGO EL DETALLE DE LA VENTA

                MANTENIMIENTO_CAJA_KARDEX();//AQUI LLAMO A MI PROCEDIMIENTO PAR GENERAR EL INGRESO EN CAJA KARDEX
                if (res == "ok" && res1 == "ok" && res2 == "ok")
                {
                    MessageBox.Show("VENTA REGISTRADA CORRECTAMENTE", "Alerta de Venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    P_IMPRIMIR();
                }
                else
                {
                    MessageBox.Show("VENTA NO REGISTRADA", "Alerta de Venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception)
            {


               MessageBox.Show("REGISTRA TODOS LOS CAMPOS NECESARIOS PARA LA VENTA", "Alerta de Venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
            

           


        }

        void LIMPIAR_VENTA()
        {
            DataTable dt = (DataTable)vPdt_detBien;
            cboTIPO_DOC.SelectedValue = "TB";
            cboTIPOPAGO.SelectedValue = "0001";
            // txtCLIENTE_VENTA.Text = string.Empty;
            lblSUBTOTAL.Text = "0.00";
            lblIGV.Text = "0.00";
            lblTOTAL.Text = "0.00";
            txtPAGA.Text = string.Empty;
            txtTIPO_PAGO.Text = "";
            txtCliente.Text = "";
            dt.Clear();


        }


        void MANTENIMIENTO_VENTADETALLE()
        {
            DataTable detalleVenta = (DataTable)vPdt_detBien;

            try
            {
                for (int i = 0; i < dgvBIEN_VENTA.Rows.Count; i++)
                {
                    E_OBJMANT_VENTADET.ID_VENTA = E_OBJMANT_VENTADET.ID_VENTA;
                    E_OBJMANT_VENTADET.ID_BIEN = dgvBIEN_VENTA.Rows[i].Cells[0].Value.ToString();
                    E_OBJMANT_VENTADET.ITEM = i + 1;
                    // Label can = dgvBIEN_VENTA.Rows[i].FindControl("Label1") as Label;
                    E_OBJMANT_VENTADET.CANTIDAD = Convert.ToDouble(dgvBIEN_VENTA.Rows[i].Cells[1].Value.ToString());
                    // Label pre = dgvBIEN_VENTA.Rows[i].FindControl("Label2") as Label;
                    E_OBJMANT_VENTADET.PRECIO = Convert.ToDouble(dgvBIEN_VENTA.Rows[i].Cells[3].Value.ToString());
                    E_OBJMANT_VENTADET.IMPORTE = Convert.ToDouble(dgvBIEN_VENTA.Rows[i].Cells[4].Value.ToString());
                    E_OBJMANT_VENTADET.SALDO_CANTIDAD = 0.00;
                    //1 = VENTA_DIRECTA Y NECESITO GRABAR EL DETALLE DE PEDIDO Y EL DETALLE DE LA VENTA 
                    E_OBJMANT_VENTADET.GRABA_PEDIDO_DETALLE = "1";

                    res1 =N_OBJVENTAS.MANTENIMIENTO_VENTADETALLE(E_OBJMANT_VENTADET);
                }
            }
            catch (Exception)
            {

                //Response.Write("<script>window.alert('NO ESCOGISTE NINGUN BIEN A VENDER');</script>");
            }

        }


        public void MANTENIMIENTO_EEECAJA_KARDEX()
        {
            try
            {
                E_OBJCAJA_KARDEX.ID_MOVIMIENTO = string.Empty;

                if (cboTIPOPAGO.SelectedItem.ToString() == "EFECTIVO")
                {
                    E_OBJCAJA_KARDEX.DESCRIPCION = "VENTA DIRECTA";
                }
                else
                {
                    E_OBJCAJA_KARDEX.DESCRIPCION = "VENTA DIRECTA " + txtTIPO_PAGO.Text;
                }

                E_OBJCAJA_KARDEX.ID_COMPVENT = E_OBJMANT_VENTADET.ID_VENTA; //id de la venta

                E_OBJCAJA_KARDEX.ID_TIPOPAGO = cboTIPOPAGO.SelectedValue.ToString(); // AQUI SE ANOTA EL PAGO POR EL CONCEPTO QUE SE ELIGIO

                E_OBJCAJA_KARDEX.ID_TIPOMOV = "IPV"; //ingreso por venta 
                E_OBJCAJA_KARDEX.IMPORTE = Convert.ToDouble(lblTOTAL.Text.ToString());
                E_OBJCAJA_KARDEX.MONEDA = "S";
                E_OBJCAJA_KARDEX.TIPO_CAMBIO = Convert.ToDouble(Properties.Settings.Default.tipo_cambio);
                E_OBJCAJA_KARDEX.AMORTIZADO = Convert.ToDouble(lblTOTAL.Text.ToString());
                E_OBJCAJA_KARDEX.ID_CAJA = Properties.Settings.Default.id_caja;
                E_OBJCAJA_KARDEX.IMPORTE_CAJA = Convert.ToDouble(lblTOTAL.Text.ToString());
                E_OBJCAJA_KARDEX.OPCION = 1;

                N_OBJVENTAS.CAJA_KARDEX_MANTENIMIENTO(E_OBJCAJA_KARDEX);
            }
            catch (Exception)
            {

                throw;
            }

        }


        public void MANTENIMIENTO_CAJA_KARDEX()
        {
            try
            {
                E_OBJCAJA_KARDEX.ID_MOVIMIENTO = string.Empty;

                if (cboTIPOPAGO.Text == "EFECTIVO")
                {
                    E_OBJCAJA_KARDEX.DESCRIPCION = "VENTA DIRECTA";
                }
                else
                {
                    E_OBJCAJA_KARDEX.DESCRIPCION = "VENTA DIRECTA " + txtTIPO_PAGO.Text;
                }

                E_OBJCAJA_KARDEX.ID_COMPVENT = E_OBJMANT_VENTADET.ID_VENTA; //id de la venta

                E_OBJCAJA_KARDEX.ID_TIPOPAGO = cboTIPOPAGO.SelectedValue.ToString(); // AQUI SE ANOTA EL PAGO POR EL CONCEPTO QUE SE ELIGIO

                E_OBJCAJA_KARDEX.ID_TIPOMOV = "IPV"; //ingreso por venta 
                E_OBJCAJA_KARDEX.IMPORTE = Convert.ToDouble(lblTOTAL.Text.ToString());
                E_OBJCAJA_KARDEX.MONEDA = "S";
                E_OBJCAJA_KARDEX.TIPO_CAMBIO = Convert.ToDouble(Properties.Settings.Default.tipo_cambio);
                E_OBJCAJA_KARDEX.AMORTIZADO = Convert.ToDouble(lblTOTAL.Text.ToString());
                E_OBJCAJA_KARDEX.ID_CAJA = Properties.Settings.Default.id_caja;
                E_OBJCAJA_KARDEX.IMPORTE_CAJA = Convert.ToDouble(lblTOTAL.Text.ToString());
                E_OBJCAJA_KARDEX.OPCION = 1;

                res2 = N_OBJVENTAS.CAJA_KARDEX_MANTENIMIENTO(E_OBJCAJA_KARDEX);
            }
            catch (Exception)
            {

                throw;
            }
        }




        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvBIEN_VENTA.Rows.Count > 0)
            {

                if (txtPAGA.Text.ToString() != string.Empty)
                {
                    if (Convert.ToDouble(txtPAGA.Text) >= Convert.ToDouble(lblTOTAL.Text))
                    {
                        double TOTAL = Convert.ToDouble(lblTOTAL.Text);
                        PAGA = Convert.ToDouble(txtPAGA.Text);
                        VUELTO = Convert.ToDouble(Convert.ToDouble(PAGA - TOTAL).ToString("N2"));
                        if (Convert.ToDouble(lblTOTAL.Text) >= 700)
                        {
                            txtCliente.Enabled = false;
                            ShowMyDialogBox();
                        }
                        else if (Convert.ToDouble(lblTOTAL.Text) < 700)
                        {
                            DialogResult result = MessageBox.Show("¿QUIERE REALIZAR LA VENTA?", "!!ATENCION!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (result == DialogResult.OK)
                            {
                                MANTENIMIENTO_VENTA();

                                //cboTIPO_DOC.SelectedIndex = 0;//REGRESANDO EL TIPO DE DOC A BOLETA DE VENTA
                                //cboCLASE_BIEN.SelectedIndex = 0;
                                
                                POP_id_cliente = string.Empty;
                                POP_ruc_dni = string.Empty;
                                POP_descripcion = string.Empty;
                                
                                LIMPIAR_VENTA();
                                
                            }
                            else if (result == DialogResult.Cancel)
                            {
                                POP_id_cliente = string.Empty;
                                POP_ruc_dni = string.Empty;
                                POP_descripcion = string.Empty;

                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("INGRESAR UN MONTO MAYOR AL MONTO TOTAL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                //CREAR MESSAGEBOX DE PREGUNTA PARA FINALIZAR VENTA
                //MessageBox.Show("¿QUIERE REALIZAR LA VENTA?", "!!ATENCION!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                
            }
            else
            {
                MessageBox.Show("ERROR prueba, NO SE SELECCIONARON NI SE LLENARON TODOS LOS DATOS CORRECTOS, VUELVA A INTENTARLO...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region SPOOL IMPRESION
        public void IMPRIMIR_SPOOL()
        {

            DataTable DATOS_VENTA = new DataTable();                         //ESTO ME PERMITE CREAR EL DATATABLE PARA LLAMAR A LOS DATOS DE MI VENTA
            string ID_VENTA = E_OBJMANT_VENTADET.ID_VENTA;                   // ESTO PERMITE GENERAR LA VARIABLE DEL ID_VENTA
            DATOS_VENTA = N_OBJVENTAS.CAPTURAR_TABLA_VENTA(ID_VENTA, Program.id_sede);        //ESTO ME PERMITE ALMACENAR TODOS LOS DATOS EN UN DATATABLE PARA PODER ACCEDER A ELLO EN TODO MOMENTO

            DataTable DATOS_VENTADETALLE = new DataTable();                  //ESTO ME PERMITE CREAR EL DATATABLE PARA LLAMAR A LOS DATOS DE MI VENTA_DETALLE
            string COD_VENTA = E_OBJMANT_VENTADET.ID_VENTA;            // ESTO PERMITE GENERAR LA VARIABLE DEL ID_VENTA
            DATOS_VENTADETALLE = N_OBJVENTAS.CAPTURAR_TABLA_VENTADETALLE(COD_VENTA); //ESTO ME PERMITE ALMACENAR TODOS LOS DATOS EN UN DATATABLE PARA PODER ACCEDER A ELLO EN TODO MOMENTO


            //LIMPIANDO MI SPOOL SI ESQUE UBIERA IMPRESIONES PENDIENTES
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "2");
            // ========================================================================================

            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_VENTA.Rows[0][36].ToString(), "1"); //aqui va el nombre de la empresa


            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "RUC: " + DATOS_VENTA.Rows[0][37].ToString(), "1");    //aqui va el ruc de la empresa
            //AQUI ESTOY OBTENENIENDO EL NOMBRE DE DISTRITO PROVINCIA Y DEPARTAMENTO DE LA EMPRESA
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");                          // imprime una linea de guiones
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_VENTA.Rows[0][28].ToString(), "1"); //aqui va el nombre de la sede de la empresa 
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_VENTA.Rows[0][29].ToString(), "1"); //aqui va la direccion de la sede de la empresa
            //AQUI ESTOY OBTENENIENDO EL NOMBRE DE DISTRITO PROVINCIA Y DEPARTAMENTO DE LA SEDE
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_VENTA.Rows[0]["S_UBIDSN"].ToString() + "-" + DATOS_VENTA.Rows[0]["S_UBIPRN"].ToString() + "-" + DATOS_VENTA.Rows[0]["S_UBIDEN"].ToString(), "1");
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "MAQ REG : " + DATOS_VENTA.Rows[0][48].ToString(), "1");          //AQUI SE COLOCA EL NOMBRE DE LA MAQUINA REGISTRADORA
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_VENTA.Rows[0][4].ToString(), "1");   //aqui va la fecha

            string TIP_DOC;
            TIP_DOC = DATOS_VENTA.Rows[0][3].ToString();/* AQUI BA EL NOMBRE  DEL TIPO DE DOCUMENTO */

            //P_SERIE_Y_NUMERO_CORRELATIVO_POR_PTOVENTA(TIP_DOC, CBOPTOVENTA.Text);
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "TICKET: " + TIP_DOC + " " + DATOS_VENTA.Rows[0][1].ToString() + "-" + DATOS_VENTA.Rows[0][2].ToString(), "1"); //aqui va el tipo_documento / el numero de serie / y el numero correlativo

            if (DATOS_VENTA.Rows[0]["V_ID_CLIENTE"] != DBNull.Value)   //ESTO ME PERMITE IMPRIMIR LOS DATOS CLIENTES SI ESQUE EXISTIERA UN CLIENTE
            {
                N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");                              // imprime una linea de guiones
                N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "CLIENTE: " + DATOS_VENTA.Rows[0]["C_DESCRIPCION"].ToString(), "1"); //OBTENIENDO EL NOMBRE DEL CLIENTE
                N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "RUC/DNI: " + DATOS_VENTA.Rows[0]["C_RUC_DNI"].ToString(), "1"); //OBTENIENDO EL RUC DEL CLIENTE
                N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_VENTA.Rows[0]["C_DIRECCION"].ToString(), "1"); //OBTENIENDO LA DIRECCION DEL CLIENTE
                //AQUI ESTOY OBTENENIENDO EL NOMBRE DE DISTRITO PROVINCIA Y DEPARTAMENTO DEL CLIENTE
                N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_VENTA.Rows[0]["C_UBIDSN"].ToString() + "-" + DATOS_VENTA.Rows[0]["C_UBIPRN"].ToString() + "-" + DATOS_VENTA.Rows[0]["C_UBIDEN"].ToString(), "1");
            }

            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");


            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "CANT   DETALLE                IMPORTE", "1");
            for (int i = 0; i < DATOS_VENTADETALLE.Rows.Count; i++)
            {
                N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_VENTADETALLE.Rows[i][3].ToString() + "   " + DATOS_VENTADETALLE.Rows[i][7].ToString() + "   " + DATOS_VENTADETALLE.Rows[i][5].ToString(), "1");
            }

            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");

            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "SUBTOTAL: S/. " + DATOS_VENTA.Rows[0][6].ToString(), "1"); //obtenemos el sub_total
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "IGV: S/. " + DATOS_VENTA.Rows[0][7].ToString(), "1");  //obtenemos el igv
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "TOTAL: S/. " + DATOS_VENTA.Rows[0][8].ToString(), "1"); //obtenemos el total
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "P.V: " + Properties.Settings.Default.punto_venta, "1"); // obtenemos el punto de venta
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "CAJERO: " + Properties.Settings.Default.nomempleado, "1"); //obtenemos la descripcion del cajero

            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_VENTA.Rows[0][41].ToString(), "1"); //aqui obtenemos el email de la empresa
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_VENTA.Rows[0][42].ToString(), "1"); //aqui obtenemos la pagina web de la empresa

            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "PAGO CON: S/. " + PAGA.ToString("N2"), "1"); //obtenemos el total
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "VUELTO: S/. " + VUELTO.ToString("N2"), "1"); //obtenemos el total
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");

            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "ID_VENTA: " + DATOS_VENTA.Rows[0][0].ToString(), "1"); //obtenemos la descripcion del cajero
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "AGRADECEMOS SU PREFERENCIA!!!", "1"); // imprime en el centro "Venta mostrador"
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "VUELVA PRONTO!! LO ESPERAMOS!!", "1");
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "1");
            if (DATOS_VENTA.Rows[0]["V_CLIENTE"].ToString() != string.Empty)
            {
                N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "ATENCION: " + DATOS_VENTA.Rows[0]["V_CLIENTE"].ToString(), "1");
            }
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "CORTATICKET", "1");

            //METODO PARA EMITIR TICKET INDIVIDUALES POR PRODUCTO QUE ESTAN CONFIGURADOS EN LA TABLA BIEN

            for (int f = 0; f < DATOS_VENTADETALLE.Rows.Count; f++)
            {
                if (DATOS_VENTADETALLE.Rows[f]["B_EMITE_TICKET"].Equals(true))
                {
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_VENTA.Rows[0][36].ToString(), "1"); //aqui va el nombre de la empresa
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_VENTA.Rows[0][28].ToString(), "1"); //nombre de la sede
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "TICKET DESPACHO", "1");
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "REFERENCIA: " + DATOS_VENTA.Rows[0][3].ToString() + " " + DATOS_VENTA.Rows[0][1].ToString() + "-" + DATOS_VENTA.Rows[0][2].ToString(), "1"); //aqui va el tipo_documento / el numero de serie / y el numero correlativo
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "1");
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "**" + DATOS_VENTADETALLE.Rows[f]["VD_CANTIDAD"].ToString() + "**", "1");
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_VENTADETALLE.Rows[f]["B_DESCRIPCION"].ToString(), "1");
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "1");
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "ATENCION: " + DATOS_VENTA.Rows[0]["V_CLIENTE"].ToString(), "1");
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_VENTA.Rows[0][4].ToString(), "1");   //aqui va la fecha Y EL ID_VENTA
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "ID_VENTA: " + DATOS_VENTA.Rows[0][0].ToString(), "1");//aqui va el codigo de venta
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "AGRADECEMOS SU PREFERENCIA!!!", "1");
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "CORTATICKET", "1");
                }
            }
        }

        #endregion

        void P_IMPRIMIR()
        {
            string DIRECCION = "";
            string RUC = "";
            string ID_VENTA = "";
            string NUMERO = "";
            string MAQREG = "";
            string puntoventadesc = "";
                        
            con.Open();
            
            SqlCommand cmv = new SqlCommand(" SELECT VT.V_ID_VENTA,VT.V_NUMERO,VT.E_DIRECCION,VT.E_RUC,VT.E_WEB_SITE,VT.PV_SERIE_MAQREG,VT.PV_DESCRIPCION,VT.V_SERIE "+
            "FROM V_TABLA_VENTAS AS VT WHERE V_ID_VENTA = (SELECT TOP 1 V_ID_VENTA FROM V_TABLA_VENTAS AS VT INNER JOIN PUNTO_VENTA AS PV ON VT.PV_SERIE = PV.SERIE "+
            " WHERE VT.V_ID_SEDE = '"+Properties.Settings.Default.id_sede+"' AND "+
            "(SELECT ID_PUNTOVENTA FROM PUNTO_VENTA WHERE SERIE = V_SERIE AND ID_SEDE = '"+Properties.Settings.Default.id_sede+"') = '"+Properties.Settings.Default.punto_venta+"' "+
            " ORDER BY V_FECHA DESC)", con);
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
            lblTicket.Text = (Convert.ToInt32(NUMERO) + 1).ToString();
            lblSerie.Text = Properties.Settings.Default.serie;
            con.Close();

            if (POP_id_cliente != string.Empty)
            {
                con.Open();
                SqlCommand cmH = new SqlCommand("SELECT DIRECCION FROM CLIENTE where ID_CLIENTE = '" + POP_id_cliente + "'", con);
                DataTable dF = new DataTable();
                SqlDataAdapter daT = new SqlDataAdapter(cmH);
                daT.Fill(dF);
                Properties.Settings.Default.direccion_vr = dF.Rows[0][0].ToString();
                con.Close();
            }


            DataTable DATOS_VENTA = new DataTable();                         //ESTO ME PERMITE CREAR EL DATATABLE PARA LLAMAR A LOS DATOS DE MI VENTA
            /*string ID_VENTA = E_OBJMANT_VENTADET.ID_VENTA;*/                   // ESTO PERMITE GENERAR LA VARIABLE DEL ID_VENTA
            DATOS_VENTA = N_OBJVENTAS.CAPTURAR_TABLA_VENTA(ID_VENTA, Program.id_sede);        //ESTO ME PERMITE ALMACENAR TODOS LOS DATOS EN UN DATATABLE PARA PODER ACCEDER A ELLO EN TODO MOMENTO

            DataTable DATOS_VENTADETALLE = new DataTable();                  //ESTO ME PERMITE CREAR EL DATATABLE PARA LLAMAR A LOS DATOS DE MI VENTA_DETALLE
            /*string COD_VENTA = E_OBJMANT_VENTADET.ID_VENTA;  */          // ESTO PERMITE GENERAR LA VARIABLE DEL ID_VENTA
            DATOS_VENTADETALLE = N_OBJVENTAS.CAPTURAR_TABLA_VENTADETALLE(ID_VENTA); //ESTO ME PERMITE ALMACENAR TODOS LOS DATOS EN UN DATATABLE PARA PODER ACCEDER A ELLO EN TODO MOMENTO


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
            TIP_DOC = cboTIPO_DOC.Text;

            //P_SERIE_Y_NUMERO_CORRELATIVO_POR_PTOVENTA(TIP_DOC, CBOPTOVENTA.Text);
            Ticket1.TextoCentro("TICKET: " + "TB" + " " + Properties.Settings.Default.serie + "-" + NUMERO);
            Ticket1.LineasGuion();


            //DGVPEDIDO["MONEDA", fila].Value.ToString();

            Ticket1.TextoIzquierda("CANT  DETALLE                    IMPORTE");
            for (int i = 0; i < dgvBIEN_VENTA.Rows.Count; i++)
            {
                Ticket1.TextoExtremos(" " + dgvBIEN_VENTA.Rows[i].Cells[1].Value.ToString() + "    " + dgvBIEN_VENTA.Rows[i].Cells[2].Value.ToString(), MON + Convert.ToDecimal(dgvBIEN_VENTA.Rows[i].Cells[4].Value.ToString()).ToString("N2"));
            }

            Ticket1.LineasTotales();

            string PAGO = PAGA.ToString("N2");
            string VUELTOF = VUELTO.ToString("N2");
            Ticket1.TextoExtremos("SubTotal:", MON + lblSUBTOTAL.Text);
            Ticket1.TextoExtremos("IGV: ", MON + lblIGV.Text);
            Ticket1.TextoExtremos("Total: ", MON + lblTOTAL.Text);
            Ticket1.TextoCentro("");
            Ticket1.TextoCentro("PAGA CON: S/ " + PAGO.ToString());
            Ticket1.TextoCentro("VUELTO: S/ " + VUELTOF.ToString());
            Ticket1.TextoCentro("");
            if (POP_id_cliente != "")
            {
                Ticket1.TextoExtremos("CLIENTE: ", POP_descripcion);
                Ticket1.TextoExtremos("RUC/DNI: ", POP_ruc_dni);
                Ticket1.TextoExtremos("DIRECCION: ", Properties.Settings.Default.direccion_vr);
            }
            Ticket1.LineasGuion(); // imprime una linea de guiones
            Ticket1.TextoCentro("P.V:" + puntoventadesc);
            Ticket1.TextoCentro("CAJERO: " + Properties.Settings.Default.nomempleado);
            Ticket1.TextoCentro("PAGINA WEB: " + WEB);
            Ticket1.TextoCentro("ID VENTA: " + ID_VENTA);
                        
            // Ticket1.TextoCentro(WEB);
            // imprime linea con total
            Ticket1.LineasGuion();
            Ticket1.TextoCentro("Agradecemos su Preferencia"); // imprime en el centro "Venta mostrador"
            Ticket1.TextoCentro("Vuelva pronto!! Lo esperamos"); // imprime en el centro "Venta mostrador"
            Ticket1.CortaTicket();

            /*id_cliente = 0;
            LBLCLIENTE.Text = "";
            LBLDOC.Text = "";
            LBLDIRECCION.Text = "";
            LBLDPTO.Text = "";
            LBLPROV.Text = "";
            LBLDIST.Text = "";
            */
            /*---------------------IMPRIMIR TICKET PEQUEÑO-------------------------*/
            for (int f = 0; f < dgvBIEN_VENTA.Rows.Count; f++)
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



        private void button1_Click(object sender, EventArgs e)
        {
            CAJA OBJCAJA = new CAJA();

            OBJCAJA.txtIDcaja.Text = Properties.Settings.Default.id_caja;
            OBJCAJA.id_empleado = v_id_empleado;
            OBJCAJA.id_puntoventa = v_id_puntoventa;
            OBJCAJA.sede = v_sede;
            OBJCAJA.tipo_cambio = v_tipo_cambio;
            OBJCAJA.nombre_empleado = v_nombre_empleado;
            OBJCAJA.id_empresa = v_id_empresa;
            OBJCAJA.Visible = true;
            this.Close();
        }

        private void txtCLIENTE_VENTA_TextChanged(object sender, EventArgs e)
        {
            //autocompletar_DESCRIPCION();
        }

        private void txtCLIENTE_RUC_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCLIENTE_VENTA_KeyPress(object sender, KeyPressEventArgs e)
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


        private void txtCLIENTE_RUC_TextChanged(object sender, EventArgs e)
        {
            //autocompletar_RUCDNI();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cboTIPO_DOC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button3_MouseEnter(object sender, EventArgs e)
        {
            this.button3.BackColor = Color.Pink;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            this.button3.BackColor = Color.CornflowerBlue;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBIEN04_MouseEnter(object sender, EventArgs e)
        {
            btnBIEN04.BackColor = Color.DarkTurquoise;
        }

        private void btnBIEN04_MouseLeave(object sender, EventArgs e)
        {
            btnBIEN04.BackColor = Color.DarkCyan;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtCANTIDAD_VENTA_TextChanged(object sender, EventArgs e)
        {

        }

        private bool VALIDAR_DATOS()
        {
            bool retorno = false;
            if (dgvBIEN_VENTA.Rows.Count > 0)
            {
                /*
                           if (cboTIPO_DOC.SelectedIndex == 1) //si es ticket factura?
                           {
                             if (Convert.ToDouble(lblTOTAL.Text) < 700) //solo permitir hacer ticket factura <= a 700
                               {
                                if (txtID_CLIENTE.Text != string.Empty)
                                  {
                                     if(cboTIPO_PAGO.SelectedItem.Text != "EFECTIVO") //SI EL PAGO ES EN EFECTIVO
                                         {
                                               if (txtTIPO_PAGO.Text != string.Empty) //SI EL CAMPO DONDE SE LLENA LA OPERACION YL NUMERO Y TODOS DATOS DEL DOCUMENTO DE OPERACION ESTA LLENO
                                               {
                                                   if (txtPAGA.Text != string.Empty)
                                                   {

                                                       retorno = true;

                                                   }
                                                   else
                                                   {
                                                       retorno = false;
                                                   }
                                               }
                                                   else
                                                   {
                                                       retorno = false;
                                                   }
                                         }
                                         else
                                         {
                                           retorno = true;
                                         }

                                       }
                                   else //el id cliente esta vacio y es factura 
                                   {
                                       retorno = false;
                                   }
                               }
                               else //en este caso la factura es > a 700 entonces no se debe generar la venta
                               {
                                   retorno = false;
                               }

                           }
                     */
                if (cboTIPO_DOC.SelectedIndex == 0)//si es boleta entonces
                {
                    if (Convert.ToDouble(lblTOTAL.Text) >= 700)  //tiene q escoger un cliente si la boleta es >= que 700
                    {
                        if (POP_id_cliente != string.Empty) //
                        {
                            if (cboTIPOPAGO.Text != "EFECTIVO") //SI EL PAGO ES EN EFECTIVO
                            {
                                if (txtTIPO_PAGO.Text != string.Empty) //SI EL CAMPO DONDE SE LLENA LA OPERACION YL NUMERO Y TODOS DATOS DEL DOCUMENTO DE OPERACION ESTA LLENO
                                {
                                    if (txtPAGA.Text != string.Empty)
                                    {
                                        retorno = true;
                                    }
                                    else
                                    {
                                        retorno = false;
                                    }
                                }
                                else
                                {
                                    retorno = false;
                                }
                            }
                            else
                            {
                                retorno = true;
                            }
                        }
                        else //el id_cliente est vacio
                        {
                            retorno = false;
                        }
                    }
                    else // es boleta y < de 700 entonces no interesa los datos del cliente
                    {
                        if (txtPAGA.Text != string.Empty)
                        {

                            if (Convert.ToDouble(txtPAGA.Text.ToString()) >= Convert.ToDouble(lblTOTAL.Text.ToString()))
                            {
                                if (cboTIPOPAGO.Text != "EFECTIVO") //SI EL PAGO ES EN EFECTIVO
                                {
                                    if (txtTIPO_PAGO.Text != string.Empty) //SI EL CAMPO DONDE SE LLENA LA OPERACION YL NUMERO Y TODOS DATOS DEL DOCUMENTO DE OPERACION ESTA LLENO
                                    {
                                        retorno = true;
                                    }
                                    else
                                    {
                                        retorno = false;
                                    }
                                }
                                else
                                {
                                    retorno = true;
                                }
                            }
                            else
                            {
                                retorno = false;
                            }
                        }
                        else
                        {
                            retorno = false;
                        }
                    }

                }






            }
            return retorno;
        }

        private void txtCANTIDAD_VENTA_MouseClick(object sender, MouseEventArgs e)
        {
            txtCANTIDAD_VENTA.Text = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            suma += 1;
            txtCANTIDAD_VENTA.Text = suma.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtCANTIDAD_VENTA.Text == "")
            {
                suma = 1;
                txtCANTIDAD_VENTA.Text = suma.ToString();
            }
            else
            {
                if (suma > 1)
                {
                    suma -= 1;
                    txtCANTIDAD_VENTA.Text = suma.ToString();
                    
                }
            }
        }

        private void txtCANTIDAD_VENTA_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPRECIO_VENTA_TextChanged(object sender, EventArgs e)
        {

        }

        //bool banderaPunto = true;
        private void txtPRECIO_VENTA_KeyPress(object sender, KeyPressEventArgs e)
        {
                //if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != 46)
                //    e.Handled = true;
                //else if (e.KeyChar == 46)
                //{
                //    if (banderaPunto)
                //    {
                //        banderaPunto = false;
                //    }
                //    else e.Handled = true;
                //}
        }

        private void cboTIPOPAGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTIPOPAGO.SelectedIndex == 0) { txtTIPO_PAGO.Enabled = false; } else { txtTIPO_PAGO.Enabled = true; }
            
        }

        private void txtPAGA_KeyPress(object sender, KeyPressEventArgs e)
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
            if (txtPAGA.Text != "") {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    button3.PerformClick();
                } }
        }

        private void cboCLASE_BIEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLENAR_MENU_BIENES();
        }

        private void lblTOTAL_Click(object sender, EventArgs e)
        {

        }

        private void lblTOTAL_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnBIEN36_Click(object sender, EventArgs e)
        {
            if (idbien[35] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[35].ToString(), valor[35].ToString(), PRECIO_BIEN[35].ToString());
            }
        }

        private void btnBIEN21_Click(object sender, EventArgs e)
        {
            if (idbien[20] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[20].ToString(), valor[20].ToString(), PRECIO_BIEN[20].ToString());
            }
        }

        private void btnBIEN22_Click(object sender, EventArgs e)
        {
            if (idbien[21] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[21].ToString(), valor[21].ToString(), PRECIO_BIEN[21].ToString());
            }

        }

        private void btnBIEN23_Click(object sender, EventArgs e)
        {
            if (idbien[22] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[22].ToString(), valor[22].ToString(), PRECIO_BIEN[22].ToString());
            }

        }

        private void btnBIEN24_Click(object sender, EventArgs e)
        {
            if (idbien[23] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[23].ToString(), valor[23].ToString(), PRECIO_BIEN[23].ToString());
            }
        }

        private void btnBIEN25_Click(object sender, EventArgs e)
        {
            if (idbien[24] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[24].ToString(), valor[24].ToString(), PRECIO_BIEN[24].ToString());
            }
        }

        private void btnBIEN26_Click(object sender, EventArgs e)
        {
            if (idbien[25] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[25].ToString(), valor[25].ToString(), PRECIO_BIEN[25].ToString());
            }
        }

        private void btnBIEN27_Click(object sender, EventArgs e)
        {
            if (idbien[26] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[26].ToString(), valor[26].ToString(), PRECIO_BIEN[26].ToString());
            }
        }

        private void btnBIEN28_Click(object sender, EventArgs e)
        {
            if (idbien[27] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[27].ToString(), valor[27].ToString(), PRECIO_BIEN[27].ToString());
            }
        }

        private void btnBIEN29_Click(object sender, EventArgs e)
        {
            if (idbien[28] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[28].ToString(), valor[28].ToString(), PRECIO_BIEN[28].ToString());
            }
        }

        private void btnBIEN30_Click(object sender, EventArgs e)
        {
            if (idbien[29] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[29].ToString(), valor[29].ToString(), PRECIO_BIEN[29].ToString());
            }
        }

        private void btnBIEN31_Click(object sender, EventArgs e)
        {
            if (idbien[30] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[30].ToString(), valor[30].ToString(), PRECIO_BIEN[30].ToString());
            }
        }

        private void btnBIEN32_Click(object sender, EventArgs e)
        {
            if (idbien[31] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[31].ToString(), valor[31].ToString(), PRECIO_BIEN[31].ToString());
            }
        }

        private void btnBIEN33_Click(object sender, EventArgs e)
        {
            if (idbien[32] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[32].ToString(), valor[32].ToString(), PRECIO_BIEN[32].ToString());
            }
        }

        private void btnBIEN34_Click(object sender, EventArgs e)
        {
            if (idbien[33] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[33].ToString(), valor[33].ToString(), PRECIO_BIEN[33].ToString());
            }
        }

        private void btnBIEN35_Click(object sender, EventArgs e)
        {
            if (idbien[34] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[34].ToString(), valor[34].ToString(), PRECIO_BIEN[34].ToString());
            }
        }

        private void txtPAGA_TextChanged(object sender, EventArgs e)
        {

        }

        public void ShowMyDialogBox()
        {
            POPUPCliente testDialog = new POPUPCliente();
            //testDialog.txtCLIENTE_VENTA.Text =
            
            try
            {
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    if (testDialog.txtCLIENTE_ID.Text != string.Empty)
                    {
                        POP_id_cliente = testDialog.txtCLIENTE_ID.Text;
                        POP_descripcion = testDialog.txtCLIENTE_VENTA.Text;
                        POP_ruc_dni = testDialog.txtCLIENTE_RUC.Text;
                        MANTENIMIENTO_VENTA();
                        
                        LIMPIAR_VENTA();
                        txtCliente.Enabled = true;
                        testDialog.Close();
                    }
                    else if (testDialog.txtCLIENTE_ID.Text == string.Empty)
                    {
                        MessageBox.Show("LLENE LOS DATOS DEL CLIENTE", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }

                }
            }
            catch { }

        }
        /*-------------------popup-message---------------------*/

        /*AQUI EMPIEZA LA PRUBA DE INTERNET*/
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }



        private bool AccesoInternet()
        {
            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("google.com");
                return true;

            }
            catch (Exception ec)
            {

                return false;
            }


        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
            timer1.Stop(); // detener mientras se hace la consulta

            AccesoInternet();

            if (AccesoInternet() == false)
            {
                DialogoInternet();

            }

            timer1.Start();  // iniciar nuevamente el timer.
        }

        public void DialogoInternet()
        {
            TestInternet testing = new TestInternet();
            testing.ShowDialog();
        }


    }
}