using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototip_21_Noiembrie
{
    internal static class Program
    {   
        /// <summary>
        /// The main entry point for the application.
        /// </summary>Application.EnableVisualStyles();
            
        [STAThread]
       
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fStartServer());
        }
    }
}
