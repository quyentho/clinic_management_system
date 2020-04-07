using clinic.Models;
using clinic.Presenters;
using clinic.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clinic.Models.Repositories;

namespace clinic
{
    public partial class FormMedicine : Form, IMedicineView
    {
        //private readonly clinicEntities _clinicEntities;
        private MedicinePresenter _medicinePresenter;
        private readonly IMedicineRepository _medicineRepository;

        public event EventHandler UpdateDataGridView;
        public EventHandler handler;
        public FormMedicine(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
            InitializeComponent();
        }
       
        private void FormMedicine_Load(object sender, EventArgs e)
        {
            _medicinePresenter = new MedicinePresenter(_medicineRepository, this);
            if (IsEdit || IsDelete)
            {
                _medicinePresenter.Display(IdSelected);
            }

            if (IsDelete)
            {
                this.txtMedicineName.Enabled = false;
                this.txtUnit.Enabled = false;
                this.txtQuantity.Enabled = false;
                this.txtPrice.Enabled = false;

                this.btnOK.Text = "Xoá";

                this.btnOK.ForeColor = Color.Red;           
            }

        }
   
        private async void btnOK_Click(object sender, EventArgs e)
        {

            if (_medicinePresenter.ValidateAllInput())
            {
                string notification = "";
                if (!IsEdit && !IsDelete) // add medicine
                    notification = await _medicinePresenter.Add();
                if (IsEdit) // edit medicine
                  notification =await _medicinePresenter.Edit(IdSelected);
                if (IsDelete)
                {
                    DialogResult result = MessageBox.Show("Có chắc muốn xoá?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                       notification = await _medicinePresenter.Delete(IdSelected);
                    }
                }
                if (notification == "")
                {
                    handler = UpdateDataGridView;
                    handler?.Invoke(this,null);
                    this.Close();           
                }
                else 
                     MessageBox.Show(notification);
            }
            else
            {
                MessageBox.Show("Nhập sai dữ liệu");
                #region ReInput textbox if invalid
                if (errorProvider1.GetError(txtMedicineName) != "")
                {
                    txtMedicineName.Clear();
                    txtMedicineName.Focus();
                }
                else if (errorProvider2.GetError(txtQuantity) != "")
                {
                    txtQuantity.Clear();
                    txtQuantity.Focus();
                }
                else if (errorProvider3.GetError(txtUnit) != "")
                {
                    txtUnit.Clear();
                    txtUnit.Focus();
                }
                else if (errorProvider4.GetError(txtPrice) != "")
                {
                    txtPrice.Clear();
                    txtPrice.Focus();
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
        
        #region Validate Input Events
        private void txtMedicineName_Validating(object sender, CancelEventArgs e)
        {
            _medicinePresenter.ValidateName();
            errorProvider1.SetError(txtMedicineName, ErrorMessage);
        }

        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            _medicinePresenter.ValidateQuantity();
            errorProvider2.SetError(txtQuantity, ErrorMessage);
        }

        private void txtUnit_Validating(object sender, CancelEventArgs e)
        {
            _medicinePresenter.ValidateUnit();
            errorProvider3.SetError(txtUnit, ErrorMessage);
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            _medicinePresenter.ValidatePrice();
            errorProvider4.SetError(txtPrice, ErrorMessage);
        }
        #endregion

        #region IView Properties
        public string TxtMedicineName { get => txtMedicineName.Text; set => txtMedicineName.Text = value; }
        public string TxtQuantity { get => txtQuantity.Text; set => txtQuantity.Text = value; }
        public string TxtUnit { get => txtUnit.Text; set => txtUnit.Text = value; }
        public string TxtPrice { get => txtPrice.Text; set => txtPrice.Text = value; }
        public string ErrorMessage { get; set; }
        public int IdSelected { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }


        #endregion


    }


}
