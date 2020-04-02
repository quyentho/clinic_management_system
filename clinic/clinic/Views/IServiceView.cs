using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Views
{
    interface IServiceView
    {
        bool IsEdit { get; set; }
        bool IsDelete { get; set; }
        string TxtTenDichVu { get; set; }
        string TxtGia { get; set; }
        string ErrorMessage { get; set; }
    }
}
