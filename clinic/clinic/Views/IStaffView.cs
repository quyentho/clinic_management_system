using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Views
{
    public interface IStaffView
    {
        string TxtStaffName { get; set; }
        int CbPermissionValue { get;}
        DateTime DtpDayOfBirth { get; set; }
        string TxtPhone { get; set; }
        string TxtSalary { get; set; }
        string ErrorMessage { get; set; }
        bool IsEdit { get; set; }
        int IdSelected { get; set; }
        bool IsDelete { get; set; }
    }
}
