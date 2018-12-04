using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Controladores.Utilidades
{
    public class EnvioMail
    {
        public static void Envio(Tipo_Evento TE)
        {
            MailAddress fromAddress = new MailAddress("cerebrotisj@gmail.com", "CEREBRO");
            MailAddress toAddress = new MailAddress(TE.Accion, "Destinatario");
            const string fromPassword = "Cerebro2018";
            const string subject = "Nuevo Evento CEREBRO";
            const string body = "Se ah generado un nuevo evento en la plataforma Cerebro, por favor inicie sesion y chequee la lista de eventos";

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (MailMessage message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
        
}
