using clinic.Models.Repositories;
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
    public partial class FormPersonalInfor : Form, IPersonalInfoView
    {
        private IStaffRepository _staffRepository;
        private PersonalInfoPresenter _presenter;

        public FormPersonalInfor(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
            InitializeComponent();
        }

        public string TxtName { get => txtName.Text; set => txtName.Text = value; }
        public DateTime DtpDoB { get => dtpDoB.Value; set => dtpDoB.Value =value; }
        public string TxtNewPassword { get => txtNewPassword.Text; set => txtNewPassword.Text = value; }
        public string TxtConfirmPassword { get => txtConfirmPassword.Text; set => txtConfirmPassword.Text = value; }
        public bool IsChangePassword { get; set; } = false;

        private void FormPersonalInfor_Load(object sender, EventArgs e)
        {
            _presenter = new PersonalInfoPresenter(_staffRepository,this);


            _presenter.DisplayInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            pnName.Enabled = true;
            pnDob.Enabled = true;

            ChangingState();
        }

        private void ChangingState()
        {
            btnUpdate.Enabled = false;
            btnChangePassword.Enabled = false;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(IsChangePassword)
            {
                try
                {
                    _presenter.ChangePassword();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else // change info
            {
                _presenter.UpdateInfo();
            }
            DefaultState();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _presenter.DisplayInfo();

            DefaultState();
        }
        private void DefaultState()
        {
            pnName.Enabled = false;
            pnDob.Enabled = false;
            pnPassword.Enabled = false;
            pnConfirmPassword.Enabled = false;

            txtNewPassword.Clear();
            txtConfirmPassword.Clear();

            btnUpdate.Enabled = true;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnChangePassword.Enabled = true;
        }
        #region Validating
        private string _errMessage;
        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateStringInput(txtName.Text, out _errMessage))
                e.Cancel = false;
            else e.Cancel = true;
            errorProvider.SetError(txtName, _errMessage);
        }
        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateStringInput(txtNewPassword.Text, out _errMessage))
                e.Cancel = false;
            else e.Cancel = true;
            errorProvider.SetError(txtNewPassword, _errMessage);
        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateStringInput(txtConfirmPassword.Text, out _errMessage))
                e.Cancel = false;
            else e.Cancel = true;
            errorProvider.SetError(txtConfirmPassword, _errMessage);
        }
        #endregion
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            IsChangePassword = true;

            pnPassword.Enabled = true;
            pnConfirmPassword.Enabled = true;

            ChangingState();
        }
    }
}
