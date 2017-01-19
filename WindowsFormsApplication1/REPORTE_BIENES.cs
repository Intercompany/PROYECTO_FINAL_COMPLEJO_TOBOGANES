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

namespace WindowsFormsApplication1
{
    public partial class REPORTE_BIENES : Form
    {
        public REPORTE_BIENES()
        {
            InitializeComponent();
        }

        private void REPORTE_BIENES_Load(object sender, EventArgs e)
        {
            LLENAR_CLASE_BIEN();
            FILTRAR_BIEN();
            ACTUALIZAR_TOTALES();
        }

        #region MyRegion
        N_VENTA OBJBIEN = new N_VENTA();
        N_LOGUEO OBJLOGUEO = new N_LOGUEO();
        E_VENTA_Y_DETALLE E_OBJVENTA = new E_VENTA_Y_DETALLE();
        #endregion

        void LLENAR_CLASE_BIEN()
        {
            if (Properties.Settings.Default.serie == "0003")
            { //AQUI VAN LOS BIENES DE LA SERIE 0003


                List<ListaTipoProd> List = new List<ListaTipoProd>();

                List.Add(new ListaTipoProd { texto = "TODOS", value = "TODOS" });
                List.Add(new ListaTipoProd { texto = "BEBIDAS", value = "BEBIDAS" });
                List.Add(new ListaTipoProd { texto = "BEBIDAS ALCOHOLICAS", value = "BEBIDAS ALCOHOLICAS" });
                List.Add(new ListaTipoProd { texto = "COMIDA CRIOLLA", value = "COMIDA CRIOLLA" });
                List.Add(new ListaTipoProd { texto = "COMIDA TIPICA", value = "COMIDA TIPICA" });
                List.Add(new ListaTipoProd { texto = "COMIDA MARINA", value = "COMIDA MARINA" });
                List.Add(new ListaTipoProd { texto = "POLLOS Y PARRILLAS",value = "POLLOS Y PARRILLAS" });

                cboCLASEBIEN.DataSource = List;
                cboCLASEBIEN.DisplayMember = "texto";
                cboCLASEBIEN.ValueMember = "value";
                cboCLASEBIEN.SelectedIndex = 0;
                                
            }
            else
            {
                List<ListaTipoProd> List = new List<ListaTipoProd>();

                List.Add(new ListaTipoProd { texto = "TODOS", value = "TODOS" });
                List.Add(new ListaTipoProd { texto = "ENTRADAS", value = "ENTRADAS" });
                List.Add(new ListaTipoProd { texto = "HOSPEDAJE", value = "HOSPEDAJE" });
                
                cboCLASEBIEN.DataSource = List;
                cboCLASEBIEN.DisplayMember = "texto";
                cboCLASEBIEN.ValueMember = "value";
                cboCLASEBIEN.SelectedIndex = 0;

            }

        }

        void FILTRAR_BIEN()
        {
            string SERIE = Properties.Settings.Default.serie;
            string SEDE = Properties.Settings.Default.id_sede;
            string FECHA_INI = txtFECHAINI.Value.ToString();
            string FECHA_FIN = txtFECHAFINAL.Value.ToString();
            string NOMBRE_CLASE = cboCLASEBIEN.SelectedValue.ToString();

            dgvLISTARBIENES.DataSource = OBJBIEN.REPORTE_BIENES_AGRUPADOS(SERIE, SEDE, FECHA_INI, FECHA_FIN, NOMBRE_CLASE);
     
        }

        void ACTUALIZAR_TOTALES()
        {
            double TOTALCANT = 0.00;
            double TOTAL = 0.00;
            for (int i = 0; i < dgvLISTARBIENES.Rows.Count; i++)
            {
                TOTAL = TOTAL + Convert.ToDouble(dgvLISTARBIENES.Rows[i].Cells[4].Value.ToString());
                TOTALCANT = TOTALCANT + Convert.ToDouble(dgvLISTARBIENES.Rows[i].Cells[3].Value.ToString());

            }

            lblTOTCANTIDAD.Text = TOTALCANT.ToString("N2");
            LBLTOTAL.Text = TOTAL.ToString("N2");


        }

        private void btnFILTRARBIEN_Click(object sender, EventArgs e)
        {
            FILTRAR_BIEN();
            ACTUALIZAR_TOTALES();
        }

        //void IMPRIMIR_SPOOL()
        //{
        //    string SEDE = Session["SEDE"].ToString();
        //    string SERIE = Session["SERIE"].ToString();

        //    //DataTable DATOS_VENTA = new DataTable();                         //ESTO ME PERMITE CREAR EL DATATABLE PARA LLAMAR A LOS DATOS DE MI VENTA

        //    // DATOS_VENTA = OBJBIEN.CAPTURAR_TABLA_VENTA(ID_VENTA);        //ESTO ME PERMITE ALMACENAR TODOS LOS DATOS EN UN DATATABLE PARA PODER ACCEDER A ELLO EN TODO MOMENTO



        //    DataTable VENTA_REPORTE = new DataTable();



        //    //AQUI CAPTURO LA LISTA DE BIENES POR FECHA
        //    VENTA_REPORTE = OBJBIEN.REPORTE_BIENES_AGRUPADOS(SERIE, SEDE, txtFECHAINI.Text, txtFECHAFINAL.Text, cboCLASEBIEN.SelectedValue);


        //    //LIMPIANDO MI SPOOL SI ESQUE UBIERA IMPRESIONES PENDIENTES
        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), string.Empty, "2");
        //    // ========================================================================================


        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "---- REPORTE DE BIENES POR CLASE ----", "1");

        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), Session["NOMBRE_EMPRESA"].ToString(), "1"); //aqui va el nombre de la empresa
        //    //OBJVENTA.SPOOL_ETIQUETERA(DATOS_VENTA.Rows[0][40].ToString());        //aqui va la direccion de la empresa


        //    //OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "RUC: " + "20600386809", "1");              //aqui va el ruc de la empresa
        //    //AQUI ESTOY OBTENENIENDO EL NOMBRE DE DISTRITO PROVINCIA Y DEPARTAMENTO DE LA EMPRESA
        //    //OBJVENTA.SPOOL_ETIQUETERA(DATOS_VENTA.Rows[0]["U_UBIDSN"].ToString() + "-" + DATOS_VENTA.Rows[0]["U_UBIPRN"].ToString() + "-" + DATOS_VENTA.Rows[0]["U_UBIDEN"].ToString());   
        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "-", "1");                          // imprime una linea de guiones
        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "SEDE: " + Session["SEDE"].ToString() + "   " + Session["SEDE_DESCRIPCION"].ToString(), "1"); //aqui va el nombre de la sede de la empresa  Y LA SERIE
        //    //OBJVENTA.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), DATOS_VENTA.Rows[0]["S_DIRECCION"].ToString(), "1"); //direccion de la sede
        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "FECHA INIC : " + txtFECHAINI.Text, "1");             //fecha inicial de filtro
        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "FECHA FIN  : " + txtFECHAFINAL.Text, "1");        //fecha final de filtro
        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "FILTRO     : " + cboCLASEBIEN.SelectedValue.ToString(), "1");
        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "-", "1");                          // imprime una linea de guiones




        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "        BIEN            CANT       TOTAL  ", "1");
        //    for (int i = 0; i < VENTA_REPORTE.Rows.Count; i++)
        //    {

        //        OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), VENTA_REPORTE.Rows[i]["DESCRIPCION"].ToString() + "  " +
        //                                 Convert.ToDouble(VENTA_REPORTE.Rows[i]["CANTIDAD"]).ToString("N0") + "    " + VENTA_REPORTE.Rows[i]["TOTAL"].ToString(), "1");
        //    }
        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "-", "1");                          // imprime una linea de guiones


        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "TOTAL CANTIDAD : " + lblTOTCANTIDAD.Text.ToString(), "1");//IMPRIMIENDO TOTAL DE ANULADOS
        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "TOTAL VENTA    : S/. " + LBLTOTAL.Text.ToString(), "1");  //IMPRIMIENDO TOTAL DE VENTAS

        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), string.Empty, "1");
        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), string.Empty, "1");
        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "-", "1");                          // imprime una linea de guiones
        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "V.B: " + Session["PUNTOVENTA"].ToString(), "1"); // obtenemos el punto de venta

        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), string.Empty, "1");
        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), string.Empty, "1");
        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), string.Empty, "1");
        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "-", "1");                          // imprime una linea de guiones
        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "V.B: ADMINISTRACION", "1");

        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "FECHA IMPRESION : " + DateTime.Now.ToString("g"), "1"); //formato de fecha g = 6/15/2008 9:15 PM
        //    OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "CORTATICKET", "1");                          // imprime una linea de guiones

        //}


    }
}
