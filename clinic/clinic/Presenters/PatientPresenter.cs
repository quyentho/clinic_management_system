using clinic.Models;
using clinic.Views;
using System;

namespace clinic.Presenters
{
    public class PatientPresenter : Presenter
    {
        private IPatientView _view;
        private readonly IPatientRepository _repository;
        public PatientPresenter(IPatientRepository patientRepository, IPatientView patientView)
        {
            _repository = patientRepository;
            _view = patientView;
        }

        public string Add()
        {
            string notification = "";
            try
            {
                var patient = new patient()
                {
                    patient_name = _view.Txtname,
                    age = Convert.ToInt32(_view.TxtAge),
                    gender = _view.CbGender,
                    phone_number = _view.TxtPhone,
                };
                _repository.InsertPatient(patient);

            }
            catch (Exception ex)
            {
                notification = ex.ToString();
            }
            return notification;
        }
    }
}
