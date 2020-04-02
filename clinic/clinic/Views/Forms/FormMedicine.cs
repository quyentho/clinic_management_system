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
        private readonly MedicineRepository _medicineRepository;

        public event EventHandler UpdateDataGridView;
        public EventHandler handler;
        public FormMedicine(MedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
            InitializeComponent();
        }
        private void FormAddMedicine_Load(object sender, EventArgs e)
        {
            _medicinePresenter = new MedicinePresenter(_medicineRepository, this);
            if (IsEdit || IsDelete)
            {
                _medicinePresenter.DisplayMedicine(IdSelected);
            }

            if (IsDelete)
            {
                this.txtTenThuoc.Enabled = false;
                this.txtDonVi.Enabled = false;
                this.txtSoLuong.Enabled = false;
                this.txtGia.Enabled = false;

                this.btnXong.Text = "Xoá";

                this.btnXong.ForeColor = Color.Red;           
            }

        }
        #region IView Properties
        public string TxtTenThuoc { get => txtTenThuoc.Text; set => txtTenThuoc.Text = value; }
        public string TxtSoLuong { get => txtSoLuong.Text; set => txtSoLuong.Text = value; }
        public string TxtDonVi { get => txtDonVi.Text; set => txtDonVi.Text = value; }
        public string TxtGia { get => txtGia.Text; set => txtGia.Text = value; }
        public string ErrorMessage { get; set; }
        public int IdSelected { get; set; }
        public bool IsEdit { get; set; } 
        public bool IsDelete { get; set; }

 
        #endregion
        private async void btnXong_Click(object sender, EventArgs e)
        {

            if (_medicinePresenter.ValidateAllInput())
            {
                string notification = "";
                if (!IsEdit && !IsDelete) // add medicine
                    notification = await _medicinePresenter.AddMedicine();
                if (IsEdit) // edit medicine
                  notification =await _medicinePresenter.EditMedicine(IdSelected);
                if (IsDelete)
                {
                    DialogResult result = MessageBox.Show("Có chắc muốn xoá?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                       notification = await _medicinePresenter.DeleteMedicine(IdSelected);
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
                if (errorProvider1.GetError(txtTenThuoc) != "")
                {
                    txtTenThuoc.Clear();
                    txtTenThuoc.Focus();
                }
                else if (errorProvider2.GetError(txtSoLuong) != "")
                {
                    txtSoLuong.Clear();
                    txtSoLuong.Focus();
                }
                else if (errorProvider3.GetError(txtDonVi) != "")
                {
                    txtDonVi.Clear();
                    txtDonVi.Focus();
                }
                else if (errorProvider4.GetError(txtGia) != "")
                {
                    txtGia.Clear();
                    txtGia.Focus();
                }
                #endregion
            }


        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            handler = UpdateDataGridView;
            handler?.Invoke(this, null);
            this.Close();
        }
#region Validate Input Events
        private void txtTenThuoc_Validating(object sender, CancelEventArgs e)
        {
            _medicinePresenter.ValidateName();
            errorProvider1.SetError(txtTenThuoc, ErrorMessage);
        }

        private void txtSoLuong_Validating(object sender, CancelEventArgs e)
        {
            _medicinePresenter.ValidateQuantity();
            errorProvider2.SetError(txtSoLuong, ErrorMessage);
        }

        private void txtDonVi_Validating(object sender, CancelEventArgs e)
        {
            _medicinePresenter.ValidateUnit();
            errorProvider3.SetError(txtDonVi, ErrorMessage);
        }

        private void txtGia_Validating(object sender, CancelEventArgs e)
        {
            _medicinePresenter.ValidatePrice();
            errorProvider4.SetError(txtGia, ErrorMessage);
        }
        #endregion


    }


}
