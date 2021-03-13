using System;
using System.Collections.Generic;

namespace clinic.Models
{
    public interface IBillRepository
    {
        void ClearPresciptionInBill(bill bill);
        void ClearServicesInBill(bill bill);

        List<bill> GetListUnpaidBill();
        List<bill> GetListPaidBill();
        void CreateBill(bill newBill);
        void PayBill(int id);
        void AddServiceToBill(int billId, clinic_service service);
        void AddPrescriptionToBill(int billId, prescription prescription);
        long CalculateRevenueByMonth(DateTime dateTime);
        long CalculateRevenueByDate(DateTime dateTime);
        long CalculateRevenueByYear(DateTime dateTime);
        void CalculateTotalMoneyInBill(int billId);
        List<bill> GetListPaidBillByYear(DateTime dateTime);
        List<bill> GetListPaidBillByMonth(DateTime dateTime);
        List<bill> GetListPaidBillByDate(DateTime dateTime);
        RevenueViewModel GetRevenueByDate(DateTime dateTime);
        RevenueViewModel GetRevenueByYear(DateTime dateTime);
        RevenueViewModel GetRevenueByMonth(DateTime dateTime);
        bill GetUnpaidBillByPhoneNumber(string phoneNumber);
        List<bill> GetUnpaidBillsByPatientName(string patientName);
        bill GetUnpaidBillByPatientId(int patientId);
        bill GetUnpaidBillById(int billId);
    }
}