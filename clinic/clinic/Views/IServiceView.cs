using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Views
{
    interface IServiceView
    {
        int IdSelected { get; set; }
        bool IsEdit { get; set; }
        bool IsDelete { get; set; }
        string TxtServiceName { get; set; }
        string TxtPrice { get; set; }
        string ErrorMessage { get; set; }
    }
}
