using clinic.Models;
using clinic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinic.Models.Repositories;
using System.Globalization;
using System.Data.Entity.Infrastructure;

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
        private int CalculateQuantityInSaleUnit()
        {
            return int.Parse(_view.TxtEntryQuantity) * int.Parse(_view.TxtExchangeRatio); 
        }
        private medicine GetMedicineFromView()
        {
            var medicine = new medicine()
            {
                medicine_name = _view.TxtMedicineName,
                quantity_in_entry_unit = Convert.ToInt32(_view.TxtEntryQuantity),
                entry_unit = _view.TxtEntryUnit,
                entry_price = Int64.Parse(_view.TxtEntryPrice),
                sale_unit = _view.TxtSaleUnit,
                sale_price_per_unit = Int64.Parse(_view.TxtSalePrice),
                entry_day = DateTime.Now,
                expiry_day = DateTime.ParseExact(_view.TxtExpiryDay, dateTimeFormats,
                                                   CultureInfo.InvariantCulture, DateTimeStyles.None),
                is_active = true,
                unit_exchange_ratio = int.Parse(_view.TxtExchangeRatio),
                quantity_in_sale_unit = CalculateQuantityInSaleUnit()
            };
            return medicine;
        }
      
        public  void Add()
        {
            _repository.InsertMedicine(GetMedicineFromView());
            
        }
        public void Display(int idSelected)
        {
            var medicineFromDB = _repository.GetMedicineById(idSelected);
            if (medicineFromDB != null)
            {
                _view.TxtMedicineName = medicineFromDB.medicine_name;
                _view.TxtEntryQuantity = medicineFromDB.quantity_in_entry_unit.ToString();
                _view.TxtEntryUnit = medicineFromDB.entry_unit;
                _view.TxtEntryPrice = medicineFromDB.entry_price.ToString();
                _view.TxtExpiryDay = String.Format("{0:dd/MM/yyyy}", medicineFromDB.expiry_day);
                _view.TxtSaleUnit = medicineFromDB.sale_unit;
                _view.TxtSalePrice = medicineFromDB.sale_price_per_unit.ToString();
                _view.TxtExchangeRatio = medicineFromDB.unit_exchange_ratio.ToString();
            }
        }
        public void Delete(int idSelected)
        {
            _repository.DeleteMedicine(idSelected);
      
        }
        public  void Edit(int idSelected)
        {
            var medicineForUpdate = GetMedicineFromView();
            medicineForUpdate.id = idSelected;

            _repository.UpdateMedicine(medicineForUpdate);
     
        }
    }
}

