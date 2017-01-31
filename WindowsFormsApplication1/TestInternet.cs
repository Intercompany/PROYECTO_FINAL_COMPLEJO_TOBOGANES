using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class TestInternet : Form
    {
        private Random rnd = new Random();
        public TestInternet()
        {
            InitializeComponent();
        }

        private void TestInternet_Load(object sender, EventArgs e)
        {
            timer1.Start();
            registrar_evento();
        }
        
        void registrar_evento()
        {

            /*-------------------------PRUEBA DE MONITOREO DE RED(LOGS)----------------------*/
            string path = @"c:\temp\MONITOREO.txt";

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                string hora = DateTime.Now.ToLongTimeString();
                sw.WriteLine("Desconeccion a las " + hora + " Ticket: " + Properties.Settings.Default.serie + Properties.Settings.Default.numero_vr + " Usuario: " + Properties.Settings.Default.nomempleado+" Punto Venta: "+Properties.Settings.Default.nom_p_venta);

            }
        }

        void registrar_evento_reconectado()
        {

            /*-------------------------PRUEBA DE MONITOREO DE RED(LOGS)----------------------*/
            string path = @"c:\temp\MONITOREO.txt";

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                string hora = DateTime.Now.ToLongTimeString();
                sw.WriteLine("Volvio la coneccion a las " + hora + " Ticket: " + Properties.Settings.Default.serie + Properties.Settings.Default.numero_vr + " Usuario: " + Properties.Settings.Default.nomempleado + " Punto Venta: " + Properties.Settings.Default.nom_p_venta);

            }
        }

        private bool AccesoInternet()
        {

            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("200.48.225.130");
                return true;

            }
            catch (Exception es)
            {

                return false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            //Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), 0);
            //BackColor = randomColor;

            BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), 0);



            timer1.Interval = 500;
            timer1.Stop(); // detener mientras se hace la consulta


            AccesoInternet();
            if (AccesoInternet() == true)
            {
                registrar_evento_reconectado();
                this.Close();
            }
            else
            {
                this.BackColor = BackColor;

            }


            timer1.Start();  // iniciar nuevamente el timer.
        }
    }
}
