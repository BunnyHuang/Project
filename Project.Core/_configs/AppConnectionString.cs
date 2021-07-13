using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core._configs
{
    public class AppConnectionString
    {
        /// <summary>
        /// Project ConnectionString
        /// </summary>
        internal static string Project => ConfigurationManager.ConnectionStrings["Project"].ToString();
    }
}
