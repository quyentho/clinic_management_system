using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clinic.Models
{
    public interface IPatientRepository
    {
        List<patient> GetPatients();
        List<patient> GetPatientsByName(string name);
        List<patient> GetPatientsByPhone(string phone);
        patient GetPatientById(int id);
        void InsertPatient(patient patient);
        void UpdatePatient(patient patient);
    }
}
