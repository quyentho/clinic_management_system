using System;
using System.Collections.Generic;

namespace clinic.Models
{
    public interface IBillRepository
    {
        List<bill> GetListBillUnpaid();
        List<bill> GetListPaidBill();
        void CreateBill(bill newBill);
        void PayBill(int id);
        void AddServiceToBill(int billId, clinic_service service);
        
        void AddPrescriptionToBill(int billId, prescription prescription);
        //TODO: Implement these functionality
        Int64 CalculateTotalMoney(int billId);
    }
}