using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Views
{
    public interface IPersonalInfoView
    {
        string TxtName { get; set; }
        DateTime DtpDoB { get; set; }
        string TxtNewPassword { get; set; }
        string TxtConfirmPassword { get; set; }
        bool IsChangePassword { get; set; }
    }
}
