using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
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
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Parse("04/30/2018");
            int days = (dt2 - dt1).Days;
            if (days <=0)
            {
                MessageBox.Show("There is an error in your application configuration .. please Contact Your Administrator.");
                return;
            }
            Console.Read();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new PrintGstInvoice());
        }
    }
}
