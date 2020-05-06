using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models
{
    public interface IMedicineRepository
    {
        IList<medicine> GetMedicineList();
        IList<medicine> GetMedicinesByName(string name);
        medicine GetMedicineById(int id);
        void InsertMedicine(medicine medicine);
        void DeleteMedicine(medicine medicine);
        void UpdateMedicine(medicine medicine);
        void Save();
    }
}
