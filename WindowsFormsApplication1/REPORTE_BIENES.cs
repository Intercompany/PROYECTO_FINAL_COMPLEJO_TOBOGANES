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
            txtFECHAINI.Value = Convert.ToDateTime(Properties.Settings.Default.fecha_apertura_caja);
            txtFECHAINI.Enabled = false;
            txtFECHAFINAL.Enabled = false;
           
        }

        #region MyRegion
        N_VENTA OBJBIEN = new N_VENTA();
        N_LOGUEO OBJLOGUEO = new N_LOGUEO();
        E_VENTA_Y_DETALLE E_OBJVENTA = new E_VENTA_Y_DETALLE();
        #endregion

        void LLENAR_CLASE_BIEN()
        {
            if (Properties.Settings.Default.serie == "0004" && Properties.Settings.Default.id_sede == "001" )
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
            else if ((Properties.Settings.Default.serie == "0006" && Properties.Settings.Default.id_sede == "003") ||(Properties.Settings.Default.serie == "0005" && Properties.Settings.Default.id_sede == "003"))
            { //AQUI VAN LOS BIENES DE LA SERIE 0003


                List<ListaTipoProd> List = new List<ListaTipoProd>();

                List.Add(new ListaTipoProd { texto = "TODOS", value = "TODOS" });
                List.Add(new ListaTipoProd { texto = "BEBIDAS", value = "BEBIDAS" });
                List.Add(new ListaTipoProd { texto = "BEBIDAS ALCOHOLICAS", value = "BEBIDAS ALCOHOLICAS" });
                List.Add(new ListaTipoProd { texto = "COMIDA CRIOLLA", value = "COMIDA CRIOLLA" });
                List.Add(new ListaTipoProd { texto = "COMIDA TIPICA", value = "COMIDA TIPICA" });
                List.Add(new ListaTipoProd { texto = "COMIDA MARINA", value = "COMIDA MARINA" });
                List.Add(new ListaTipoProd { texto = "POLLOS Y PARRILLAS", value = "POLLOS Y PARRILLAS" });

                cboCLASEBIEN.DataSource = List;
                cboCLASEBIEN.DisplayMember = "texto";
                cboCLASEBIEN.ValueMember = "value";
                cboCLASEBIEN.SelectedIndex = 0;

            }
            else if ((Properties.Settings.Default.serie == "0010" && Properties.Settings.Default.id_sede == "003") || (Properties.Settings.Default.serie == "0005" && Properties.Settings.Default.id_sede == "003"))
            { //AQUI VAN LOS BIENES DE LA SERIE DE BEBIDAS


                List<ListaTipoProd> List = new List<ListaTipoProd>();

                List.Add(new ListaTipoProd { texto = "TODOS", value = "TODOS" });
                List.Add(new ListaTipoProd { texto = "BEBIDAS", value = "BEBIDAS" });
                List.Add(new ListaTipoProd { texto = "BEBIDAS ALCOHOLICAS", value = "BEBIDAS ALCOHOLICAS" });
                
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
            dgvLISTARBIENES.Columns[0].Width = 70;
            dgvLISTARBIENES.Columns[1].Width = 120;
            dgvLISTARBIENES.Columns[2].Width = 350;
            dgvLISTARBIENES.Columns[3].Width = 70;
            dgvLISTARBIENES.Columns[4].Width = 60;

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSAlir_Click(object sender, EventArgs e)
        {
            
            CAJA cj = new CAJA();
            cj.txtIDcaja.Text = Properties.Settings.Default.id_caja;
            cj.Visible = true;
            this.Close();
        }

        void IMPRIMIR_SPOOL()
        {
            string SEDE = Properties.Settings.Default.id_sede;
            string SERIE = Properties.Settings.Default.serie;

            //DataTable DATOS_VENTA = new DataTable();                         //ESTO ME PERMITE CREAR EL DATATABLE PARA LLAMAR A LOS DATOS DE MI VENTA

            // DATOS_VENTA = OBJBIEN.CAPTURAR_TABLA_VENTA(ID_VENTA);        //ESTO ME PERMITE ALMACENAR TODOS LOS DATOS EN UN DATATABLE PARA PODER ACCEDER A ELLO EN TODO MOMENTO



            DataTable VENTA_REPORTE = new DataTable();



            //AQUI CAPTURO LA LISTA DE BIENES POR FECHA
            VENTA_REPORTE = OBJBIEN.REPORTE_BIENES_AGRUPADOS(SERIE, SEDE, txtFECHAINI.Value.ToString(), txtFECHAFINAL.Value.ToString(), cboCLASEBIEN.SelectedValue.ToString());

            CreaTicket Ticket1 = new CreaTicket();
            Ticket1.impresora = "BIXOLON SRP-270";

            //LIMPIANDO MI SPOOL SI ESQUE UBIERA IMPRESIONES PENDIENTES
            Ticket1.TextoCentro("");
            // ========================================================================================


            Ticket1.TextoCentro("---- REPORTE DE BIENES POR CLASE ----");

            Ticket1.TextoCentro(Properties.Settings.Default.nomempresa); //aqui va el nombre de la empresa
            //OBJVENTA.SPOOL_ETIQUETERA(DATOS_VENTA.Rows[0][40].ToString());        //aqui va la direccion de la empresa


            //OBJBIEN.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "RUC: " + "20600386809", "1");              //aqui va el ruc de la empresa
            //AQUI ESTOY OBTENENIENDO EL NOMBRE DE DISTRITO PROVINCIA Y DEPARTAMENTO DE LA EMPRESA
            //OBJVENTA.SPOOL_ETIQUETERA(DATOS_VENTA.Rows[0]["U_UBIDSN"].ToString() + "-" + DATOS_VENTA.Rows[0]["U_UBIPRN"].ToString() + "-" + DATOS_VENTA.Rows[0]["U_UBIDEN"].ToString());   
            Ticket1.LineasGuion();                         // imprime una linea de guiones
            Ticket1.TextoCentro("SEDE: " + Properties.Settings.Default.id_sede + "   " + Properties.Settings.Default.nomsede); //aqui va el nombre de la sede de la empresa  Y LA SERIE
                                                                                                                              //OBJVENTA.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), DATOS_VENTA.Rows[0]["S_DIRECCION"].ToString(), "1"); //direccion de la sede
            Ticket1.TextoCentro("FECHA INIC : " + txtFECHAINI.Value.ToShortDateString());             //fecha inicial de filtro
            Ticket1.TextoCentro("FECHA FIN  : " + txtFECHAFINAL.Value.ToShortDateString());        //fecha final de filtro
            Ticket1.TextoCentro("CLASE BIEN : " + cboCLASEBIEN.SelectedValue.ToString());
            Ticket1.LineasGuion();                         // imprime una linea de guiones




            Ticket1.TextoCentro("        BIEN            CANT       TOTAL  ");
            for (int i = 0; i < VENTA_REPORTE.Rows.Count; i++)
            {

                Ticket1.TextoCentro(VENTA_REPORTE.Rows[i]["DESCRIPCION"].ToString() + "  " +
                                         Convert.ToDouble(VENTA_REPORTE.Rows[i]["CANTIDAD"]).ToString("N0") + "    " + VENTA_REPORTE.Rows[i]["TOTAL"].ToString());
            }
            Ticket1.LineasGuion();                          // imprime una linea de guiones


            Ticket1.TextoCentro("TOTAL CANTIDAD : " + lblTOTCANTIDAD.Text.ToString());//IMPRIMIENDO TOTAL DE ANULADOS
            Ticket1.TextoCentro("TOTAL VENTA    : S/. " + LBLTOTAL.Text.ToString());  //IMPRIMIENDO TOTAL DE VENTAS

            Ticket1.TextoCentro("");
            Ticket1.TextoCentro("");
            Ticket1.LineasGuion();                           // imprime una linea de guiones
            Ticket1.TextoCentro("V.B: " + Properties.Settings.Default.nom_p_venta); // obtenemos el punto de venta

            Ticket1.TextoCentro("");
            Ticket1.TextoCentro("");
            Ticket1.TextoCentro("");
            Ticket1.LineasGuion();                            // imprime una linea de guiones
            Ticket1.TextoCentro("V.B: ADMINISTRACION");

            Ticket1.TextoCentro("FECHA IMPRESION : " + DateTime.Now.ToString("g")); //formato de fecha g = 6/15/2008 9:15 PM
            Ticket1.CortaTicket();                         // imprime una linea de guiones

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

        private void btnIMPRIMIR_Click(object sender, EventArgs e)
        {
            IMPRIMIR_SPOOL();
        }
    }
}
