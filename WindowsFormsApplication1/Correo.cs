using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Correo
    {
        MailMessage correos = new MailMessage();
        SmtpClient envios = new SmtpClient();

        public void enviarCorreo(string emisor, string password, string mensaje, string asunto, string destinatario, string ruta)
        {
            try
            {
                correos.To.Clear();
                correos.Body = "";
                correos.Subject = "";
                correos.Body = mensaje;
                correos.Subject = asunto;
                correos.IsBodyHtml = true;
                correos.To.Add(destinatario.Trim());

                if (ruta.Equals("") == false)
                {
                    System.Net.Mail.Attachment archivo = new System.Net.Mail.Attachment(ruta);
                    correos.Attachments.Add(archivo);
                }

                correos.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, password);

                //Datos importantes no modificables para tener acceso a las cuentas

                envios.Host = "smtp.gmail.com";
                envios.Port = 587;
                envios.EnableSsl = true;

                envios.Send(correos);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
