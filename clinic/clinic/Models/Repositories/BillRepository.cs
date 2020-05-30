using System;
using System.Collections.Generic;
using System.Linq;
using clinic.Models;
using System.Data.Entity;

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

        public List<bill> GetListBillUnpaid()
        {
            return _listUnpaidBill.ToList();
        }

        private List<bill> GetUnpaidBillFromDb()
        {
            return _clinicEntities.bills.Include(b=>b.clinic_service)
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
            _clinicEntities.AddOrUpdateEntity<bill>(_clinicEntities, billFromDb);
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

        public long CalculateRevenueByDate(DateTime dateTime)
        {
            return _listPaidBill.Where(b => b.created_at.Month == dateTime.Month 
            && b.created_at.Year == dateTime.Year
            && b.created_at.Date == dateTime.Date)
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
            item.State = System.Data.Entity.EntityState.Modified;

            item.Collection(i => i.clinic_service).Load();

            bill.clinic_service.Add(service);

            Save();
        }
        private bill GetUnpaidBillById(int billId)
        {
            return _listUnpaidBill.Where(b => b.id == billId).FirstOrDefault();
        }

        public void AddPrescriptionToBill(int billId, prescription prescription)
        {
            var bill = GetUnpaidBillById(billId);
            if (bill is null)
                throw new ArgumentOutOfRangeException("billId", "Bill Khong Ton Tai");

            var item = _clinicEntities.Entry(bill);
            item.State = System.Data.Entity.EntityState.Modified;

               item.Collection(i => i.prescriptions).Load();

            bill.prescriptions.Add(prescription);

            Save();
        }

        public Int64 CalculateTotalMoney(int billId)
        {
            var bill = GetUnpaidBillById(billId);

            Int64 totalMoney = bill.clinic_service.Select(s => s.price).Sum()
                + bill.prescriptions.Select(p => p.quantity_indicated * p.medicine.sale_price_per_unit).Sum();

            return totalMoney;
        }
    }
}