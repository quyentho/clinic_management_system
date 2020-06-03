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
        public static int staffId;
        public static int permissionId;
        [STAThread]
        static void Main()
        {     
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            clinicEntities clinicEntities = new clinicEntities();
            IAccountRepository accountRepository = new AccountRepository(clinicEntities);
            var form = new LoginForm(accountRepository);
            if(form.ShowDialog() == DialogResult.OK)
            {
                if(permissionId == 1)
                {
                    Application.Run(new AdminForm(clinicEntities));
                }
                else
                {
                    Application.Run(new ReceptionForm(clinicEntities));
                }
            }
          
        }
    }
}
