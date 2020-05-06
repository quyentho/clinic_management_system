using clinic.Models;
using clinic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinic.Models.Repositories;

namespace clinic.Presenters
{
    class MedicinePresenter : Presenter
    {
        private IMedicineView _view;
        private readonly IMedicineRepository _repository;
        public MedicinePresenter(IMedicineRepository medicineRepository, IMedicineView medicineView)
        {
            _view = medicineView;
            _repository = medicineRepository;
        }
        public  void Add()
        {
            var medicine = new medicine()
            {
               
            };
            _repository.InsertMedicine(medicine);
             _repository.Save();
        }
        public void Display(int idSelected)
        {
            var medicineFromDB = _repository.GetMedicineById(idSelected);
            if (medicineFromDB != null)
            {
                _view.TxtMedicineName = medicineFromDB.medicine_name;
                _view.TxtQuantity = medicineFromDB.quantity.ToString();
                _view.TxtEntryUnit = medicineFromDB.entry_unit;
                _view.TxtEntryPrice = medicineFromDB.entry_price.ToString();
                _view.TxtExpiryDay = medicineFromDB.expiry_day.ToString();
                _view.TxtSaleUnit = medicineFromDB.sale_unit;
                _view.TxtSalePrice = medicineFromDB.sale_price_per_unit.ToString();
            }
        }
        public  void Delete(int idSelected)
        {
            var medicineFromDb = _repository.GetMedicineById(idSelected);
            if (medicineFromDb != null)
            {
                _repository.DeleteMedicine(medicineFromDb);
                _repository.Save();
            }
        }
        public  void Edit(int idSelected)
        {
            var medicineUpdated = new medicine()
            {
                medicine_name = _view.TxtMedicineName,
                quantity = Convert.ToInt32(_view.TxtQuantity),
                entry_unit = _view.TxtEntryUnit,
                entry_price = Int64.Parse(_view.TxtEntryPrice),
                sale_unit = _view.TxtSaleUnit,
                sale_price_per_unit = Int64.Parse(_view.TxtSalePrice),
                entry_day = DateTime.Now,
                expiry_day = DateTime.Parse(_view.TxtExpiryDay),
                is_active = true
            };
            _repository.UpdateMedicine(medicineUpdated);
            _repository.Save();
        }
    }
}

