using clinic.BusinessDomain.Medicine;
using clinic.BusinessDomain.Patient;
using clinic.BusinessDomain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Utilities
{
    public static class Transform
    {
        public static MedicineVM MedicineTransform(medicine medicine)
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
