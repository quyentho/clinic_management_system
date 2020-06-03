using clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using clinic.Views.Forms;
using clinic.Models.Repositories;

namespace clinic
{
    static class Program
    {
       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {     
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            clinicEntities clinicEntities = new clinicEntities();

            Application.Run(new ReceptionForm());
        }
    }
}
