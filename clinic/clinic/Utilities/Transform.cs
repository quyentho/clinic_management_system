using clinic.BusinessDomain.Medicine;
using clinic.BusinessDomain.Patient;
using clinic.BusinessDomain.Service;
using clinic.BusinessDomain.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Utilities
{
    public static class Transform
    {
        public static TestVM TestTransform(ServiceStatistic test)
        {
            return new TestVM
            {
                MedicineId = test.MedicineId,
                EndDate = test.EndDate,
                Count = test.Count,
                MedicineName = test.medicine.medicine_name,
                ServiceId = test.ServiceId,
                ServiceName = test.clinic_service.service_name,
                StartDate = test.StartDate
            };
        }

        public static ReceptionMedicineVM ReceptionMedicineTransform(medicine medicine)
        {
            return new ReceptionMedicineVM
            {
                Id = medicine.id,
                Name = medicine.medicine_name,
                Quantity = medicine.quantity_in_sale_unit.ToString(),
                SalePrice = medicine.sale_price_per_unit.ToString(),
                Unit = medicine.sale_unit
            };
        }
        public static AdminMedicineVM AdminMedicineTransform(medicine medicine)
        {
            return new AdminMedicineVM
            {
                Id = medicine.id,
                Name = medicine.medicine_name,
                Quantity = medicine.quantity_in_sale_unit.ToString(),
                SalePrice = medicine.sale_price_per_unit.ToString(),
                SaleUnit = medicine.sale_unit,
                EntryDate = medicine.entry_day,
                EntryQuantity = medicine.quantity_in_entry_unit.ToString(),
                EntryUnit = medicine.entry_unit,
                ExpiryDate = medicine.expiry_day,
                ExchangeRatio = medicine.unit_exchange_ratio.ToString()

            };
        }
        public static ServiceVM ServiceTransform(clinic_service service)
        {
            return new ServiceVM
            {
                Id = service.id,
                Name = service.service_name,
                Price = service.price.ToString(),
                Type = service.Type,
                MedicineUsage = service.medicine != null ? service.medicine.medicine_name : string.Empty
            };
        }

        public static PatientVM PatientTransform(patient patient)
        {
            return new PatientVM
            {
                Id = patient.id.ToString(),
                Age = patient.age.ToString(),
                Gender = patient.gender,
                Name = patient.patient_name,
                PhoneNumber = patient.phone_number
            };
        }

    }
}
