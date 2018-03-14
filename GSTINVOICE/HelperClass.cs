using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTINVOICE
{
    public static class HelperClass
    {
        public static string ConString = ConfigurationManager.ConnectionStrings["ApplicationForm.Properties.Settings.CMSMDataNewConnectionString"].ConnectionString;
    }
}
