using clinic.Models;
using clinic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Presenters
{
    //ERROR: Refactor not using async
    //public class PatientPresenter
    //{
    //    private IPatientView _view;
    //    private readonly IPatientRepository _repository;
    //    public PatientPresenter(IPatientRepository patientRepository,IPatientView patientView)
    //    {
    //        _repository = patientRepository;
    //        _view = patientView;
    //    }

    //    public  Task<string> Add()
    //    {
    //        string notification = "";
    //        try
    //        {
    //            var patient = new patient()
    //            {
    //                patient_name = _view.Txtname,
    //                age = Convert.ToInt32(_view.TxtAge),
    //                gender = _view.CbGender,
    //                phone_number = _view.TxtPhone,                    
    //            };
    //            _repository.InsertPatient(patient);
    //            await _repository.Save();

    //        }
    //        catch (Exception ex)
    //        {
    //            notification = ex.ToString();
    //        }
    //        return notification;
    //    }

    //    #region validating Method
    //    public bool ValidateName()
    //    {
    //        bool isValid = true;
    //        if (string.IsNullOrWhiteSpace(_view.Txtname))
    //        {
    //            _view.ErrorMessage = "Nhập tên bệnh nhân";
    //            isValid = false;
    //        }
    //        else
    //        {
    //            _view.ErrorMessage = "";

    //        }
    //        return isValid;
    //    }
    //    public bool ValidateAge()
    //    {
    //        bool isValid = true;
    //        if (string.IsNullOrWhiteSpace(_view.TxtAge))
    //        {
    //            _view.ErrorMessage = "Nhập Tuổi";
    //            isValid = false;
    //        }
    //        else
    //        {
    //            _view.ErrorMessage = "";
    //            try
    //            {
    //                int age = int.Parse(_view.TxtAge);
    //                if (age >= 0)
    //                {
    //                    _view.ErrorMessage = "";
    //                }
    //                else
    //                {
    //                    _view.ErrorMessage = "Tuổi phải lớn hơn 0";
    //                    isValid = false;
    //                }
    //            }
    //            catch
    //            {
    //                _view.ErrorMessage = "Vui lòng nhập đúng số";
    //                isValid = false;
    //            }
    //        }
    //        return isValid;
    //    }
    //    public bool ValidateAllInput()
    //    {
    //        bool isValidName = ValidateName();
    //        bool isValidAge = ValidateAge();
       
    //        if (isValidName && isValidAge)
    //        {
    //            return true;
    //        }
    //        else
    //            return false;
    //    }
    //    #endregion

    //}
}
