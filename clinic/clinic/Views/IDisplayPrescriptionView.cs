using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Views
{
    public interface IDisplayPrescriptionView
    {
        int BillId { get; set; }
        object DgvDisplayDataSource { get; set; }
        string LbPatientName { get; set; }
    }
}
