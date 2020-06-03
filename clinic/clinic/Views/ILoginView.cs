using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Views
{
    public interface ILoginView
    {
        string TxtUsername { get; set; }
        string TxtPassword { get; set; }
    }
}
