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
    public class PersonalInfoPresenter : Presenter
    {
        private IStaffRepository _staffRepository;
        private IPersonalInfoView _view;

        public PersonalInfoPresenter(IStaffRepository staffRepository, IPersonalInfoView personalInfoView)
        {
            _staffRepository = staffRepository;
            _view = personalInfoView;
        }
        private staff GetMyInfo()
        {
            return _staffRepository.FindStaffFromDb(Program.staffId);
        }
        public void DisplayInfo()
        {
            var myInfo = GetMyInfo();

            _view.TxtName = myInfo.full_name;
            _view.DtpDoB = myInfo.date_of_birth;
        }

        public void UpdateInfo()
        {
            var myInfo = GetMyInfo();

            myInfo.id = myInfo.id;
            myInfo.date_of_birth = _view.DtpDoB;
            myInfo.full_name = _view.TxtName;
            myInfo.is_still_working = true;
            myInfo.permission_id = myInfo.permission_id;
            myInfo.salary = myInfo.salary;


            _staffRepository.UpdateStaff(myInfo);
        }

        public void ChangePassword()
        {
            if (_view.TxtNewPassword != _view.TxtConfirmPassword)
                throw new ArgumentException("Xác nhận mật khẩu không chính xác");
            _staffRepository.ChangeAccountPassword(Program.staffId, _view.TxtNewPassword);
        }
    }
}
