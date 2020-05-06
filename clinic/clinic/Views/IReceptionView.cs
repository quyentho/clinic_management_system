using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Views
{
    public interface IReceptionView
    {
        string TxtSearch { get; set; }
        int IdSelected { get; set; }
    }
}
