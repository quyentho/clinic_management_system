using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models
{
    public interface IPrescriptionRepository
    {
        void AddPrescriptionToDatabase(prescription prescription);
        
        List<prescription> GetPrescriptionByBillId(int billId);
    }
}
