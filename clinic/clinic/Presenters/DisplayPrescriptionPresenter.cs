using clinic.Models;
using clinic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Presenters
{
    public class DisplayPrescriptionPresenter
    {
        private IPrescriptionRepository _repository;
        private IDisplayPrescriptionView _view;

        public DisplayPrescriptionPresenter(IPrescriptionRepository prescriptionRepository, IDisplayPrescriptionView view)
        {
            _repository = prescriptionRepository;
            _view = view;
        }

        public void Display()
        {
            _view.DgvDisplayDataSource = _repository.GetPrescriptionByBillId(_view.BillId);
        }
    }
}
