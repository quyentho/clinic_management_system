using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models
{
    public interface IPatientRepository
    {
        Task<IList<patient>> GetPatients();
        Task<IList<patient>> GetPatientsByName(string name);
        Task<IList<patient>> GetPatientsByPhone(string phone);
        patient GetPatientById(int id);
        void InsertPatient(patient patient);
   
        void UpdatePatient(patient patient);
        Task Save();
    }
}
