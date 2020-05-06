using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Views
{
    interface IServiceView
    {
        string TxtServiceName { get; set; }
        string TxtPrice { get; set; }
        string ErrorMessage { get; set; }
    }
}
