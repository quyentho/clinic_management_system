using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Views
{
    public interface IAssignMedicineView
    {
        string Quantity { get; set; }
        string Description { get; set; }
    }
}
