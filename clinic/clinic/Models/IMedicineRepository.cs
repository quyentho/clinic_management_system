using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models
{
    public interface IMedicineRepository
    {
        Task<IEnumerable<medicine>> GetMedicines();
        medicine GetMedicineById(int id);
        void InsertMedicine(medicine medicine);
        void DeleteMedicine(medicine id);
        void UpdateMedicine(medicine medicine);
        Task Save();
    }
}
