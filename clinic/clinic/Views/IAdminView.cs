using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Views
{
    interface IAdminView
    {

        string TxtTimKiem { get; set; }
        int IndexSelected { get; set; }
    }
}
