using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models.Repositories
{
    //ERROR: Refactor patientRepo not using async
    //public class PatientRepository : IPatientRepository
    //{
    //    private readonly clinicEntities _clinicEntities;
    //    public PatientRepository(clinicEntities entities)
    //    {
    //        _clinicEntities = entities;
    //    }
    //    public patient GetPatientById(int id)
    //    {
    //        patient patientFromDb = _clinicEntities.patients.AsNoTracking().FirstOrDefault(patient => patient.id == id);

    //        return patientFromDb;
    //    }
    //    public  Task<IList<patient>> GetPatientsByName(string name)
    //    {
    //        List<patient> patientsFromDb = await Task.Run(() => _clinicEntities.patients.AsNoTracking().Where(p => p.patient_name == name).ToList());

    //        return  patientsFromDb;
    //    }

    //    public  Task<IList<patient>> GetPatientsByPhone(string phoneNumber)
    //    {
    //        List<patient> patientsFromDb =await Task.Run(() => _clinicEntities.patients.AsNoTracking().Where(p => p.phone_number == phoneNumber).ToList());

    //        return patientsFromDb;
    //    }

    //    public  Task<IList<patient>> GetPatients()
    //    {
    //        return await Task.Run(() => _clinicEntities.patients.AsNoTracking().ToList());
    //    }

    //    public void InsertPatient(patient patient)
    //    {
    //        _clinicEntities.patients.Add(patient);
    //    }

    //    public  Task Save()
    //    {
    //        await _clinicEntities.SaveChanges();
    //    }

    //    public void UpdatePatient(patient patient)
    //    {
    //        _clinicEntities.Entry(patient).State = System.Data.Entity.EntityState.Modified;
    //    }
    //}
}
