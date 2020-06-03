using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinic.Models;
using clinic.Views;
using clinic.Views.Forms;

namespace clinic.Presenters
{
    public class LoginPresenter : Presenter
    {
        private IAccountRepository _accountRepository;
        private ILoginView _view;

        public LoginPresenter(IAccountRepository accountRepository, ILoginView loginView)
        {
            _accountRepository = accountRepository;
            _view = loginView;
        }

        public bool ValidateLogin()
        {
            var account = _accountRepository.GetAccount(_view.TxtUsername, _view.TxtPassword);
            if(account != null)
            {
                Program.staffId = account.staff_id;
                Program.permissionId = account.permission_id;
                return true;
            }
            return false;
        }
    }
}
