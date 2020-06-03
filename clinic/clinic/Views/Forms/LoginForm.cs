using clinic.Models;
using clinic.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic.Views.Forms
{
    public partial class LoginForm : Form, ILoginView
    {
        private IAccountRepository _accountRepository;

        public string TxtUsername { get => txtUsername.Text; set => txtUsername.Text = value; }
        public string TxtPassword { get => txtPassword.Text; set => txtPassword.Text = value; }
        public LoginForm(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            InitializeComponent();
        }

        private string _errMessage;
        private LoginPresenter _presenter;

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateStringInput(txtUsername.Text, out _errMessage))
                e.Cancel = false;
            else e.Cancel = true;
            errorProvider.SetError(txtUsername, _errMessage);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateStringInput(txtPassword.Text, out _errMessage))
                e.Cancel = false;
            else e.Cancel = true;
            errorProvider.SetError(txtPassword, _errMessage);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            _presenter = new LoginPresenter(_accountRepository, this);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (_presenter.ValidateLogin())
                {
                    this.Close();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Sai Tài Khoản/Mật Khẩu");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
