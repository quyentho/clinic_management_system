using clinic.Models;
using clinic.Presenters;
using clinic.Views;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace clinic
{
    public partial class FormMedicine : OperationForm, IMedicineView
    {
        //private readonly clinicEntities _clinicEntities;
        private MedicinePresenter _presenter;
        private readonly IMedicineRepository _repository;

       
        #region IView Properties
        public string TxtMedicineName { get => txtMedicineName.Text; set => txtMedicineName.Text = value; }
        public string TxtEntryUnit { get => txtEntryUnit.Text; set => txtEntryUnit.Text = value; }
        public string TxtEntryPrice { get => txtEntryPrice.Text; set => txtEntryPrice.Text = value; }
   
        public string TxtSaleUnit { get => txtSaleUnit.Text; set => txtSaleUnit.Text = value; }
        public string TxtSalePrice { get => txtSalePrice.Text; set => txtSalePrice.Text = value; }
        public string TxtExpiryDay { get => txtExpiryDay.Text; set => txtExpiryDay.Text = value; }
        public string TxtEntryQuantity { get => txtEntryQuantity.Text; set => txtEntryQuantity.Text = value; }
        public string TxtExchangeRatio { get => txtExchangeRatio.Text; set => txtExchangeRatio.Text = value; }
        #endregion
        public FormMedicine(IMedicineRepository medicineRepository)
        {
            _repository = medicineRepository;
            _presenter = new MedicinePresenter(_repository, this);
            InitializeComponent();
        }

        private void FormMedicine_Load(object sender, EventArgs e)
        {
           
            if (Operation != Operation.Insert)
            {
                _presenter.Display(IdSelected);
            }

            if (Operation == Operation.Delete)
            {
                this.panel1.Enabled = false;
                this.panel2.Enabled = false;
                this.panel3.Enabled = false;
                this.panel4.Enabled = false;
                this.panel5.Enabled = false;
                this.panel6.Enabled = false;
                this.panel7.Enabled = false;
                this.panel8.Enabled = false;
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

        #region Validate Input Events
        private string _errMessage;
        private void txtMedicineName_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateStringInput(txtMedicineName.Text, out _errMessage))
                e.Cancel = false;
            else e.Cancel = true;
            errorProvider.SetError(txtMedicineName, _errMessage);
        }
        private void txtEntryQuantity_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateNumberInput(txtEntryQuantity.Text,out _errMessage))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            errorProvider.SetError(txtEntryQuantity, _errMessage);
        }
        private void txtEntryPrice_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateNumberInput(txtEntryPrice.Text,out _errMessage))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            errorProvider.SetError(txtEntryPrice, _errMessage);
        }
        private void txtEntryUnit_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateStringInput(txtEntryUnit.Text,out _errMessage))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            errorProvider.SetError(txtEntryUnit, _errMessage);
        }

        private void txtExpiryDay_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateDateTimeInput(txtExpiryDay.Text, out _errMessage))
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
            errorProvider.SetError(txtExpiryDay, _errMessage);
        }

        private void txtSalePrice_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateNumberInput(txtSalePrice.Text, out _errMessage))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            errorProvider.SetError(txtSalePrice, _errMessage);
        }

        private void txtSaleUnit_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateStringInput(txtSaleUnit.Text, out _errMessage))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            errorProvider.SetError(txtSaleUnit, _errMessage);
        }
        private void txtExchangeRatio_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateNumberInput(txtExchangeRatio.Text, out _errMessage))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            errorProvider.SetError(txtSalePrice, _errMessage);
        }

        #endregion

        private void FormMedicine_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateDataGridViewEventHandler?.Invoke(this, null);
        }

    }
}
