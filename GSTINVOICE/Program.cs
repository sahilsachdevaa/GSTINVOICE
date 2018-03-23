using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTINVOICE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException +=
             new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new MDIContainer());

        }
        static void CurrentDomain_UnhandledException
       (object sender, UnhandledExceptionEventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            var exception = ((Exception)e.ExceptionObject);
            builder.AppendLine("Error Reporting GSTInvoice");
            builder.AppendLine("Error Message :-" + exception.Message);
            builder.AppendLine("---------------------------");
            builder.AppendLine("Error Trace:-" + exception.StackTrace.ToString());
           
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("gstinvoice2018@gmail.com");
                mail.To.Add("gstinvoice8@gmail.com");
                mail.To.Add("LavishGrover440@gmail.com");
                mail.To.Add("sahilsachdevaa@gmail.com");
                mail.Subject = "GST Invoice Error report";
                mail.Body = builder.ToString();
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("gstinvoice2018@gmail.com", "gstinvoice@123");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }
            finally
            {
                Application.Exit();
            }
        }
    }
}

