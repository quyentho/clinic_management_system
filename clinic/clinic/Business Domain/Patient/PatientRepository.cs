using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clinic.Models.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly clinicEntities _clinicEntities;
        private List<patient> _patientList;
        public PatientRepository(clinicEntities entities)
        {
            _clinicEntities = entities;
            _patientList = GetPatientsFromDatabase();
        }

        public List<patient> GetPatientList()
        {
            return _patientList;
        }

        public patient GetPatientById(int id)
        {
            patient patientFromDb = _clinicEntities.patients.FirstOrDefault(patient => patient.id == id);

            return patientFromDb;
        }
        public List<patient> GetPatientsByName(string name)
        {
            List<patient> patientsFromDb = _clinicEntities.patients
                    .Where(p => p.patient_name == name).ToList();

            return patientsFromDb;
        }

        public List<patient> GetPatientsByPhone(string phoneNumber)
        {
            List<patient> patientsFromDb = _clinicEntities.patients
                .Where(p => p.phone_number == phoneNumber).ToList();

            return patientsFromDb;
        }

        private List<patient> GetPatientsFromDatabase()
        {
            return  _clinicEntities.patients.ToList();
        }

        public void InsertPatient(patient patient)
        {
            if(_patientList.Any(p=>p.phone_number == patient.phone_number))
            {
                throw new ArgumentException("Phone number already exists ", patient.phone_number);
            }
            else
            {
                _patientList.Add(patient);
                _clinicEntities.patients.Add(patient);
                Save();
            }
        }

        private void  Save()
        {
             _clinicEntities.SaveChanges();
        }

        public void UpdatePatient(patient patient)
        {
            if (_clinicEntities.patients.Find(patient.id) != null)
            {
                Save();
            }
        }
    }
}
