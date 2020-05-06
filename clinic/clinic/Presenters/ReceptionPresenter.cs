using clinic.Models;
using clinic.Models.Repositories;
using clinic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Presenters
{
    //ERROR: Refactor not using async
    //public class ReceptionPresenter
    //{
    //    private readonly clinicEntities _clinicEntities;
    //    private IPatientRepository _patientRepository;
    //    private IReceptionView _view;
    //    public ReceptionPresenter(clinicEntities clinicEntities, IReceptionView view)
    //    {
    //        _clinicEntities = clinicEntities;
    //        _view = view;
    //        _patientRepository = new PatientRepository(_clinicEntities);
    //    }
    //    public  Task<IList<patient>> GetPatientData()
    //    {
    //        return await Task.Run(() =>_clinicEntities.patients.ToList());
    //    }
    //    public  Task<IList<bill>> GetBillsUnpaidData()
    //    {
    //        return await Task.Run(() => _clinicEntities.bills.Where(b => b.is_paid == false).ToList());
    //    }
    //    public  Task<IList<patient>> SearchPatientsByName()
    //    {            
    //        return await _patientRepository.GetPatientsByName(_view.TxtSearch);
    //    }
    //    public  Task<IList<patient>> SearchPatientsByPhone()
    //    {
    //        return await _patientRepository.GetPatientsByPhone(_view.TxtSearch);
    //    }

    //}
}
