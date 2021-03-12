using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace clinic.Models.Repositories
{
    public class BillRepository: IBillRepository
    {
        private clinicEntities _clinicEntities;
        private List<bill> _listUnpaidBill;
        private List<bill> _listPaidBill;

        public BillRepository(clinicEntities clinicEntities)
        {
            _clinicEntities = clinicEntities;
            _listUnpaidBill = GetUnpaidBillFromDb();
            _listPaidBill = GetListPaidBillFromDb();
        }

        public List<bill> GetListUnpaidBill()
        {
            return _listUnpaidBill.ToList();
        }

        private List<bill> GetUnpaidBillFromDb()
        {
            return _clinicEntities.bills.Include(b=>b.clinic_service).Include(b=>b.patient).Include(b=>b.prescriptions)
                .Where(b => b.is_paid == false)
                .ToList();
        }

        public List<bill> GetListPaidBill()
        {
            return _listPaidBill;
        }

        private List<bill> GetListPaidBillFromDb()
        {
            return _clinicEntities.bills.Include(b=>b.clinic_service)
                .Include(b=>b.prescriptions.Select(p=>p.medicine))
                .Where(b => b.is_paid == true).ToList();
        }

        public void CreateBill(bill newBill)
        {
            
            _clinicEntities.bills.Add(newBill);
            _listUnpaidBill.Add(newBill);
            Save();
        }
        private void Save()
        {
            _clinicEntities.SaveChanges();
        }

        public void PayBill(int id)
        {
            var billFromDb = _clinicEntities.bills.Find(id);

            if (billFromDb is null)
            {
                throw new ArgumentOutOfRangeException("id", "Hoa Don Khong Ton Tai");
            }

            billFromDb.is_paid = true;
            RemoveBillFromUnpaidList(billFromDb);
            AddBillToPaidList(billFromDb);
            Save();
        }

        private void AddBillToPaidList(bill billFromDb)
        {
            _listPaidBill.Add(billFromDb);
        }
        private void RemoveBillFromUnpaidList(bill billFromDb)
        {
            _listUnpaidBill.Remove(billFromDb);
        }
        public long CalculateRevenueByMonth(DateTime dateTime)
        {
            return _listPaidBill.Where(b => b.created_at.Month == dateTime.Month && b.created_at.Year == dateTime.Year)
                .Select(b => b.total_money).Sum();
        }
        public RevenueViewModel GetRevenueByDate(DateTime dateTime)
        {
            var revenueVM = new RevenueViewModel();
            revenueVM.Date = dateTime.Date.ToString("dd/MM/yyyy");
            revenueVM.Revenue = CalculateRevenueByDate(dateTime);
            return revenueVM;
        }
        public RevenueViewModel GetRevenueByMonth(DateTime dateTime)
        {
            var revenueVM = new RevenueViewModel();
            revenueVM.Date = dateTime.Date.ToString("MM/yyyy");
            revenueVM.Revenue = CalculateRevenueByMonth(dateTime);
            return revenueVM;
        }
        public RevenueViewModel GetRevenueByYear(DateTime dateTime)
        {
            var revenueVM = new RevenueViewModel();
            revenueVM.Date = dateTime.Date.ToString("yyyy");
            revenueVM.Revenue = CalculateRevenueByYear(dateTime);
            return revenueVM;
        }
        public long CalculateRevenueByDate(DateTime dateTime)
        {
            return _listPaidBill.Where(b => b.created_at.Date == dateTime.Date)
                .Select(b => b.total_money).Sum();
        }

        public long CalculateRevenueByYear(DateTime dateTime)
        {
            return _listPaidBill.Where(b => b.created_at.Year == dateTime.Year)
                .Select(b => b.total_money).Sum();
        }

        public List<bill> GetListPaidBillByYear(DateTime dateTime)
        {
            return _listPaidBill.Where(b => b.created_at.Year == dateTime.Year).ToList();
        }

        public List<bill> GetListPaidBillByMonth(DateTime dateTime)
        {
            return _listPaidBill.Where(b => b.created_at.Year == dateTime.Year
                                         && b.created_at.Month == dateTime.Month).ToList();
        }

        public List<bill> GetListPaidBillByDate(DateTime dateTime)
        {
            return _listPaidBill.Where(b => b.created_at.Year == dateTime.Year
                                        && b.created_at.Month == dateTime.Month
                                        && b.created_at.Date == dateTime.Date).ToList();
        }
        public void AddServiceToBill(int billId,clinic_service service)
        {
            bill bill = GetUnpaidBillById(billId);
            if (bill is null)
            {
                throw new ArgumentOutOfRangeException("billId", "Bill Khong Ton Tai");
            }
            var item = _clinicEntities.Entry(bill);
            item.State = EntityState.Modified;

            item.Collection(i => i.clinic_service).Load();

            //bill.clinic_service.Clear();

            var serviceForAdd  = _clinicEntities.clinic_service.Find(service.id);
            bill.clinic_service.Add(serviceForAdd);
            Save();
        }
        public bill GetUnpaidBillById(int billId)
        {
            return _listUnpaidBill.Where(b => b.id == billId).FirstOrDefault();
        }

        public void AddPrescriptionToBill(int billId, prescription prescription)
        {
            var bill = GetUnpaidBillById(billId);
            if (bill is null)
                throw new ArgumentOutOfRangeException("billId", "Bill Khong Ton Tai");

           bill.prescriptions.Add(prescription);

           Save();
        }

        public void CalculateTotalMoneyInBill(int billId)
        {
            var bill = GetUnpaidBillById(billId);

            Int64 totalMoney = bill.clinic_service.Select(s => s.price).Sum()
                + bill.prescriptions.Select(p => p.quantity_indicated * p.medicine.sale_price_per_unit).Sum();

            bill.total_money = totalMoney;
            UpdateTotalMoneyOfBillInDatabase(billId, totalMoney);
        }

        private void UpdateTotalMoneyOfBillInDatabase(int billId, long totalMoney)
        {
            var billToUpdate = _clinicEntities.bills.Find(billId);
            billToUpdate.total_money = totalMoney;
            Save();
        }

        public bill GetUnpaidBillByPhoneNumber(string phoneNumber)
        {
            return _listUnpaidBill.Where(b => b.patient.phone_number == phoneNumber).FirstOrDefault();
        }

        public List<bill> GetUnpaidBillsByPatientName(string patientName)
        {
            return _listUnpaidBill.Where(b => b.patient.patient_name == patientName).ToList();
        }

        public bill GetUnpaidBillByPatientId(int patientId)
        {
            return _listUnpaidBill.Where(b => b.patient_id == patientId).FirstOrDefault();
        }
    }
}