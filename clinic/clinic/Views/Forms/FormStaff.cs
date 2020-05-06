using clinic.Models;
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
    public partial class FormStaff : OperationForm, IStaffView
    {
        private StaffPresenter _presenter;
        private readonly IStaffRepository _repository;
        private readonly IPermissionRepository _permissionRepository;

        #region IView properties
        public int CbPermission_id { get => (int)cbPermission.SelectedValue; set => cbPermission.SelectedValue =value; }
        public string TxtStaffName { get => txtStaffName.Text; set => txtStaffName.Text = value; }
        public string TxtDoB { get => txtDoB.Text; set => txtDoB.Text = value; }
        public string TxtPhone { get => txtPhone.Text; set => txtPhone.Text = value; }
        public string TxtSalary { get => txtSalary.Text; set => txtSalary.Text = value; }
        public ComboBox CbPermission { get => cbPermission; set => cbPermission = value; }
        #endregion

        public FormStaff(IStaffRepository staffRepository, IPermissionRepository permissionRepository)
        {
            _repository = staffRepository;
            _permissionRepository = permissionRepository;
            InitializeComponent();
        }
        private  void FormStaff_Load(object sender, EventArgs e)
        {
            //get permission display in combobox
            _presenter = new StaffPresenter(_repository,_permissionRepository, this);
  
            if (Operation != Operation.Insert)
            {
                _presenter.Display(IdSelected);
            }

            if (Operation == Operation.Delete)
            {
                this.txtStaffName.Enabled = false;
                this.txtPhone.Enabled = false;
                this.txtSalary.Enabled = false;
                this.txtDoB.Enabled = false;

                this.btnOK.Text = "Xoá";

                this.btnOK.ForeColor = Color.Red;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                switch (Operation)
                {
                    case Operation.Insert:
                        _presenter.Add();
                        break;
                    case Operation.Edit:
                        _presenter.Edit(IdSelected);
                        break;
                    case Operation.Delete:
                        DialogResult dialogResult = MessageBox.Show("Có chắc muốn xoá?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _presenter.Delete(IdSelected);
                        }
                        break;
                }
                this.Close();
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region validate input event
        private string _errMessage;
        private void txtStaffName_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateStringInput(txtStaffName.Text,out _errMessage))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            errorProvider.SetError(txtStaffName, _errMessage);
        }
        private void txtSalary_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateNumberInput(txtSalary.Text,out _errMessage))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            errorProvider.SetError(txtSalary, _errMessage);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateStringInput(txtPhone.Text,out _errMessage))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            errorProvider.SetError(txtPhone, _errMessage);
        }
        #endregion

        private void FormStaff_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            UpdateDataGridViewEventHandler?.Invoke(this, null);
        }
    }
}
