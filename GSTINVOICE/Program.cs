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
        public static LoginForm frmLogin;
        public static AddContracter FrmContracter;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            frmLogin = new LoginForm();
            FrmContracter = new AddContracter();
            CheckContractor();
           // Application.Run(new MDIContainer());
        }
        public static void CheckContractor()
        {
            try
            {
                using (var con = new OleDbConnection(HelperClass.ConString))
                {
                    OleDbCommand cmd = new OleDbCommand("Select * from Contractortbl", con);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        
                         frmLogin.ShowDialog();
                        
                    }
                    else
                    {
                        FrmContracter.ShowDialog();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
