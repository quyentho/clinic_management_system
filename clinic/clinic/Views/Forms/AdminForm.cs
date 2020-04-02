using clinic.Models;
using clinic.Models.Bussiness_Logics;
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


namespace clinic
{
    public partial class AdminForm : Form, IAdminView
    {
        private readonly clinicEntities _clinicEntities;
        private AdminPresenter _adminPresenter;
        private Form _form;

        public AdminForm()
        {
            _clinicEntities = new clinicEntities();
            _adminPresenter = new AdminPresenter(this, _clinicEntities);
            InitializeComponent();
        }

        #region Properties
     
        public string TxtTimKiem { get => txtTimKiem.Text; set => txtTimKiem.Text = value; }
        public int IndexSelected { get; set; }
        #endregion
        private async void btnQuanLyThuoc_Click(object sender, EventArgs e)
        {
            dgvAdmin.DataSource = await _adminPresenter.GetMedicineData();

            //set display of datagridview
            dgvAdmin.Columns[1].HeaderText = "Tên thuốc";
            dgvAdmin.Columns[2].HeaderText = "Tồn kho";
            dgvAdmin.Columns[3].HeaderText = "Đơn vị thuốc";
            dgvAdmin.Columns[4].HeaderText = "Giá/Đơn vị";

            dgvAdmin.Columns[5].Visible = false; // not show navigation property

            if (_form != null)
                _form.Dispose();
            _form = new FormMedicine(new Models.Repositories.MedicineRepository(_clinicEntities));
        }


        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvAdmin.DataSource = await _adminPresenter.SearchMedicines(txtTimKiem.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ((FormMedicine)_form).UpdateDataGridView += btnQuanLyThuoc_Click;
            _form.ShowDialog();
            

            //    dgvAdmin.DataSource = await _adminPresenter.GetMedicineData();
        }
        private async void btnDichVu_Click(object sender, EventArgs e)
        {
            dgvAdmin.DataSource = await _adminPresenter.GetServiceData();

            dgvAdmin.Columns[1].HeaderText = "Tên dịch vụ";
            dgvAdmin.Columns[2].HeaderText = "Giá dịch vụ";

            dgvAdmin.Columns[3].Visible = false;

            if (_form != null)
                _form.Dispose();
        //    _form = new FormService();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //casting to FormMedicine
            if (_form is FormMedicine medicineForm)
            {
                medicineForm.IsEdit = true;
                medicineForm.IdSelected = IndexSelected;
                medicineForm.UpdateDataGridView += btnQuanLyThuoc_Click;
            }
            _form.ShowDialog();

            //   dgvAdmin.DataSource = await _adminPresenter.GetMedicineData();
        }

        private void dgvAdmin_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            IndexSelected = int.Parse(dgvAdmin.Rows[e.RowIndex].Cells[0].Value.ToString());
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (_form is FormMedicine medicineForm)
            {
                medicineForm.IsDelete = true;
                medicineForm.IdSelected = IndexSelected;
                medicineForm.UpdateDataGridView += btnQuanLyThuoc_Click;
            }
            _form.ShowDialog();
            
        }
        //#region Update DataGridView Display When Changed Db Value
        //private void Add_Row_DataGridView(object sender, UpdateDataGridViewEventArgs e)
        //{
        //    dgvAdmin.Rows.Add(e.Value.ToString().Clone());
        //}
        //private void Edit_Row_DataGridView(object sender, UpdateDataGridViewEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
        //private void Delete_Row_DataGridView(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
        //#endregion

        private void btnNhanVien_Click(object sender, EventArgs e)
        {

        }


    }
}


