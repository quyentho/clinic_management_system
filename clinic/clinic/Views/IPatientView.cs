using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Views
{
    public interface IPatientView
    {
        string Txtname { get; set; }
        string TxtPhone { get; set; }
        string TxtAge { get; set; }
        string CbGender { get; set; }
    }
}
