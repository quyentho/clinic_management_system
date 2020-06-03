using clinic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic.Views
{
    public interface IAssignServiceView
    {
        object DgvServiceDataSource { get; set; }
        List<clinic_service> ListServiceSelected { get; set; }
        int PatientId { get; set; }
        int IdServiceSelected { get; set; }
        int IndexRemove { get; set; }
        DataGridView DgvServicesSelected { get; set; }
        string ErrMessage { get; set; }

    }
}
