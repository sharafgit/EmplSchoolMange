using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using EmplSchoolMange.BL.Helper;
using System.Threading.Tasks;

namespace EmplSchoolMange.BL.Helper
{
    public static class MailHelper
    {
        public static string sendMail(string Title , string Message)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("as8338873@gmail.com", "A@123321A@");
                //MailMessage m = new MailMessage();
                //m.From = "";
                //m.To = "";
                //m.Subject = "";
                //m.Body = "";
                //m.CC = "";
                //m.Attachments = "";
                smtp.Send("as8338873@gmail.com", "blogintr@gmail.com", Title, Message);
                return "Mail is Send Successfully";
            }
            catch (Exception ex)
            {
                return "Mail is Send Filed";
            }
        }

    }
}
