using clinic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Presenters
{
    public class AssignMedicinePresenter : Presenter
    {
        private IAssignMedicineView _assignMedicineView;
        public AssignMedicinePresenter(IAssignMedicineView assignMedicineView)
        {
            _assignMedicineView = assignMedicineView;
        }
    }
}
