using clinic.Models;
using clinic.Models.Repositories;
using clinic.Presenters;
using clinic.Views;
using clinic.Views.Forms;
using System;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace clinic
{
    public partial class AdminForm : Form, IAdminView
    {
        
        private  clinicEntities _clinicEntities;
        private  AdminPresenter _presenter;
        private  OperationForm _form;
        private  IMedicineRepository _medicineRepository;
        private  IStaffRepository _staffRepository;
        private  IServiceRepository _serviceRepository;
        private  IPermissionRepository _permissionRepository;
        private  IAccountRepository _accountRepository;
        private IBillRepository _billRepository;
        public AdminForm(clinicEntities clinicEntities)
        {
            _clinicEntities = clinicEntities;
            _medicineRepository = new MedicineRepository(_clinicEntities);
            _serviceRepository = new ServiceRepository(_clinicEntities);
            _permissionRepository = new PermissionRepository(_clinicEntities);
            _accountRepository = new AccountRepository(_clinicEntities);
            _billRepository = new BillRepository(_clinicEntities);
            _staffRepository = new StaffRepository(_clinicEntities,_permissionRepository,_accountRepository);
            _presenter = new AdminPresenter(this,_medicineRepository,_staffRepository,_serviceRepository,_billRepository);
            InitializeComponent();
        }

     
        #region Properties

        public string TxtTimKiem { get => txtSearch.Text; set => txtSearch.Text = value; }
        public int IndexSelected { get; set; }
        public DataGridView AdminDataGridView { get => dgvAdmin; set => dgvAdmin = value; }
        public DateTime DtpRevenue { get => dtpRevenue.Value; set => dtpRevenue.Value=value; }
        public bool RbDate { get => rbDate.Checked; set => rbDate.Checked = value; }
        public bool RbMonth { get => rbMonth.Checked; set => rbMonth.Checked = value; }
        public bool RbYear { get => rbYear.Checked; set => rbYear.Checked = value; }
        #endregion
        private void AdminForm_Load(object sender, EventArgs e)
        {
            btnStaff.Focus();

            btnStaff.PerformClick();
        }
        #region Add, Edit, Delete button_click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(_form != null)
            {
                _form.Operation = Operation.Insert;
                _form.UpdateDataGridViewEventHandler += UpdateDataGridView;
                _form.ShowDialog();
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(_form != null)
            {
                _form.Operation = Operation.Edit;
                _form.IdSelected = IndexSelected;
                _form.UpdateDataGridViewEventHandler += UpdateDataGridView;
                _form.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(_form != null)
            {
                _form.Operation = Operation.Delete;
                _form.IdSelected = IndexSelected;
                _form.UpdateDataGridViewEventHandler += UpdateDataGridView;
                _form.ShowDialog();
            }
        }
        #endregion
        private void UpdateDataGridView(object sender, EventArgs e)
        {
            if (_form is FormMedicine) btnMedicine.PerformClick();
            else if (_form is FormService) btnService.PerformClick();
            else if (_form is FormStaff) btnStaff.PerformClick();
        }

        #region functionality button_click

        private void btnService_Click(object sender, EventArgs e)
        {
            if (_form != null)
                DisposeFormAndSetNull();
            _form = new FormService(_serviceRepository, _medicineRepository);
            _presenter.DisplayServices();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            if (_form != null)
                DisposeFormAndSetNull();
            _form = new FormStaff(_staffRepository,_permissionRepository);
            _presenter.DisplayStaffs();
        }

        private  void btnMedicine_Click(object sender, EventArgs e)
        {
            if (_form != null)
                DisposeFormAndSetNull();
            _form = new FormMedicine(_medicineRepository);
            _presenter.DisplayMedicines();
        }

        #endregion
        private void dgvAdmin_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            IndexSelected = int.Parse(dgvAdmin.Rows[e.RowIndex].Cells[0].Value.ToString());
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (_form is FormMedicine) _presenter.SearchMedicines();
            else if (_form is FormService) _presenter.SearchServices();
            else if (_form is FormStaff) _presenter.SearchStaffs();
          
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            if (_form != null)
            {
                DisposeFormAndSetNull();
            }
              _presenter.DisplayRevenue();
        }

        private void DisposeFormAndSetNull()
        {
            _form.Dispose();
            _form = null;
        }

        private void dtpRevenue_ValueChanged(object sender, EventArgs e)
        {
            CallPresenterToDisplayRevenueByDatetime();
        }

        private void CallPresenterToDisplayRevenueByDatetime()
        {
            if (_form is null)
                _presenter.DisplayRevenue();
        }

        private void rbDate_CheckedChanged(object sender, EventArgs e)
        {
            CallPresenterToDisplayRevenueByDatetime();
        }

        private void rbMonth_CheckedChanged(object sender, EventArgs e)
        {
            CallPresenterToDisplayRevenueByDatetime();
        }

        private void rbYear_CheckedChanged(object sender, EventArgs e)
        {
            CallPresenterToDisplayRevenueByDatetime();
        }

        private void dgvAdmin_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if(dgvAdmin.RowCount <= 0)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void dgvAdmin_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if(dgvAdmin.RowCount > 0)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnServiceStatistic_Click(object sender, EventArgs e)
        {

        }
    }
}


