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
    public partial class FormStaff : Form, IStaffView
    {
        private StaffPresenter _staffPresenter;
        private readonly IStaffRepository _staffRepository;
        private readonly IPermissionRepository _permissionRepository;

        public event EventHandler UpdateDataGridView;
        public EventHandler handler;
        #region IView properties
        public int CbPermissionValue { get =>cbPermission.SelectedIndex; }
        public string TxtStaffName { get => txtStaffName.Text; set => txtStaffName.Text = value; }
        public DateTime DtpDayOfBirth { get => dtpDoB.Value; set => dtpDoB.Value = value; }
        public string TxtPhone { get => txtPhone.Text; set => txtPhone.Text = value; }
        public string TxtSalary { get => txtSalary.Text; set => txtSalary.Text = value; }
        public string ErrorMessage { get; set; }
        public bool IsEdit { get; set; }
        public int IdSelected { get; set; }
        public bool IsDelete { get; set; }
        #endregion

        public FormStaff(IStaffRepository staffRepository, IPermissionRepository permissionRepository)
        {
            _staffRepository = staffRepository;
            _permissionRepository = permissionRepository;
            InitializeComponent();
        }
        private void FormStaff_Load(object sender, EventArgs e)
        {
            _staffPresenter = new StaffPresenter(_staffRepository, this);
            IList<permission> permissions = _permissionRepository.GetPermissions().Result;
            cbPermission.DataSource = permissions;
            cbPermission.DisplayMember = "posision_name";
            cbPermission.Invalidate();

            if (IsEdit || IsDelete)
            {
                _staffPresenter.Display(IdSelected);
            }

            if (IsDelete)
            {
                this.txtStaffName.Enabled = false;
                this.txtPhone.Enabled = false;
                this.txtSalary.Enabled = false;
                this.dtpDoB.Enabled = false;

                this.btnOK.Text = "Xoá";

                this.btnOK.ForeColor = Color.Red;
            }

        }

        private async void btnOK_Click(object sender, EventArgs e)
        {

            if (_staffPresenter.ValidateAllInput())
            {
                string notification = "";
                if (!IsEdit && !IsDelete) // add staff
                    notification = await _staffPresenter.Add();
                if (IsEdit) // edit staff
                    notification = await _staffPresenter.Edit(IdSelected);
                if (IsDelete)
                {
                    DialogResult result = MessageBox.Show("Có chắc muốn xoá?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        notification = await _staffPresenter.Delete(IdSelected);
                    }
                }
                if (notification == "")
                {
                    handler = UpdateDataGridView;
                    handler?.Invoke(this, null);
                    this.Close();
                }
                else
                    MessageBox.Show(notification);
            }
            else
            {
                MessageBox.Show("Nhập sai dữ liệu");

                #region ReInput textbox if invalid
                if (errorProvider1.GetError(txtStaffName) != "")
                {
                    txtStaffName.Clear();
                    txtStaffName.Focus();
                }
                else if (errorProvider2.GetError(txtPhone) != "")
                {
                    txtPhone.Clear();
                    txtPhone.Focus();
                }
                else if (errorProvider3.GetError(txtSalary) != "")
                {
                    txtSalary.Clear();
                    txtSalary.Focus();
                }
               
                #endregion
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            handler = UpdateDataGridView;
            handler?.Invoke(this, null);
            this.Close();
        }
        #region validate input event
        private void txtStaffName_Validating(object sender, CancelEventArgs e)
        {
            _staffPresenter.ValidateName();
            errorProvider1.SetError(txtStaffName, ErrorMessage);
        }
        private void txtSalary_Validating(object sender, CancelEventArgs e)
        {
            _staffPresenter.ValidateSalary();
            errorProvider2.SetError(txtSalary, ErrorMessage);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            _staffPresenter.ValidatePhone();
            errorProvider3.SetError(txtPhone, ErrorMessage);
        }
        #endregion

    }
}
