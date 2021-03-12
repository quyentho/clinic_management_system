using clinic.BusinessDomain.Medicine;
using clinic.Models;
using clinic.Views.Forms;
using System;
using System.Collections.Generic;

namespace clinic.Presenters
{
    public class DisplayMedicinePresenter
    {
        private readonly IDisplayMedicineView _view;
        private readonly IMedicineRepository _repository;

        public DisplayMedicinePresenter(IMedicineRepository repository, IDisplayMedicineView view)
        {
            _repository = repository;
            _view = view;
        }

        public void Display()
        {
            var medicines = _repository.GetAll();

            List<MedicineVM> medicineVMs = new List<MedicineVM>();

            foreach (var medicine in medicines)
            {
                medicineVMs.Add(GetViewModel(medicine));
            }

            _view.DgvDisplayDataSource = medicineVMs;
        }

        private MedicineVM GetViewModel(medicine medicine)
        {
            return new MedicineVM
            {
                Id = medicine.id,
                Name = medicine.medicine_name,
                Quantity = medicine.quantity_in_sale_unit.ToString(),
                SalePrice = medicine.sale_price_per_unit.ToString(),
                Unit = medicine.sale_unit
            };
        }

        public void SearchMedicine()
        {
            _view.DgvDisplayDataSource = _repository.GetMedicinesByName(_view.TxtSearchText);
        }
    }
}