using clinic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Views
{
    public interface IAssignServiceView
    {
        IList<clinic_service> ServiceDataSource { get; set; }

    }
}
