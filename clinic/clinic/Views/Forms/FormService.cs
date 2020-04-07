using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clinic.Models;
using clinic.Models.Repositories;
using clinic.Presenters;
using clinic.Views;

namespace clinic
{
    public partial class FormService : Form, IServiceView
    {
        private readonly IServiceRepository _serviceRepository;
        private ServicePresenter _servicePresenter;
        //private Presenter

        public event EventHandler UpdateDataGridView;
        public EventHandler handler;
        public FormService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
            InitializeComponent();
        }
        #region Iview Properties
        public int IdSelected { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public string TxtServiceName { get => txtServiceName.Text; set => txtServiceName.Text = value; }
        public string TxtPrice { get => txtPrice.Text; set => txtPrice.Text = value; }
        public string ErrorMessage { get; set; }
        #endregion
        private void FormService_Load(object sender, EventArgs e)
        {
            _servicePresenter = new ServicePresenter(_serviceRepository, this);
            if (IsEdit || IsDelete)
            {
                _servicePresenter.Display(IdSelected);
            }

            if (IsDelete)
            {
                this.txtServiceName.Enabled = false;              
                this.txtPrice.Enabled = false;

                this.btnOK.Text = "Xoá";

                this.btnOK.ForeColor = Color.Red;
            }

        }

        private async void btnOK_Click(object sender, EventArgs e)
        {

            if (_servicePresenter.ValidateAllInput())
            {
                string notification = "";
                if (!IsEdit && !IsDelete) // add service
                    notification = await _servicePresenter.Add();
                if (IsEdit) // edit service
                    notification = await _servicePresenter.Edit(IdSelected);
                if (IsDelete)
                {
                    DialogResult result = MessageBox.Show("Có chắc muốn xoá?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        notification = await _servicePresenter.Delete(IdSelected);
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
                //if (errorProvider1.GetError(txtServiceName) != "")
                //{
                //    txtServiceName.Clear();
                //    txtServiceName.Focus();
                //}
                //else if (errorProvider2.GetError(txtQuantity) != "")
                //{
                //    txtQuantity.Clear();
                //    txtQuantity.Focus();
                //}
                //else if (errorProvider3.GetError(txtUnit) != "")
                //{
                //    txtUnit.Clear();
                //    txtUnit.Focus();
                //}
                //else if (errorProvider4.GetError(txtPrice) != "")
                //{
                //    txtPrice.Clear();
                //    txtPrice.Focus();
                //}
                #endregion
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            handler = UpdateDataGridView;
            handler?.Invoke(this, null);
            this.Close();
        }

        #region Validate Input Events
        private void txtServiceName_Validating(object sender, CancelEventArgs e)
        {
            _servicePresenter.ValidateName();
            errorProvider1.SetError(txtServiceName, ErrorMessage);
        }
        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            _servicePresenter.ValidatePrice();
            errorProvider2.SetError(txtPrice, ErrorMessage);
        }
        #endregion

    }
}
