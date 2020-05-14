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
        //FIXME: Inject serviceRepo, staffRepo, medicineRepo from program.cs
        //FIXME: Remove _clinicEntities
        private  clinicEntities _clinicEntities;
        private  AdminPresenter _presenter;
        private  OperationForm _form;
        private  IMedicineRepository _medicineRepository;
        private  IStaffRepository _staffRepository;
        private  IServiceRepository _serviceRepository;
        private  IPermissionRepository _permissionRepository;


     
        public AdminForm()
        {
            //HACK: temporarily create instance of all repository, will be moved to program.cs
            _clinicEntities = new clinicEntities();
            _medicineRepository = new MedicineRepository(_clinicEntities);
            _serviceRepository = new ServiceRepository(_clinicEntities);
            _permissionRepository = new PermissionRepository(_clinicEntities);
            _staffRepository = new StaffRepository(_clinicEntities, _permissionRepository);
            _presenter = new AdminPresenter(this,_medicineRepository,_staffRepository,_serviceRepository);
            InitializeComponent();
        }
 
        #region Properties

        public string TxtTimKiem { get => txtSearch.Text; set => txtSearch.Text = value; }
        public int IndexSelected { get; set; }
        public DataGridView AdminDataGridView { get => dgvAdmin; set => dgvAdmin = value; }
        #endregion

        private void AdminForm_Load(object sender, EventArgs e)
        {
            btnStaff.Focus();

            btnStaff.PerformClick();
        }



        #region Add, Edit, Delete button_click
        //TODO: Update for staff & service
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _form.Operation = Operation.Insert;
            _form.UpdateDataGridViewEventHandler += UpdateDataGridView;
            _form.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _form.Operation = Operation.Edit;
            _form.IdSelected = IndexSelected;
            _form.UpdateDataGridViewEventHandler += UpdateDataGridView;
            _form.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _form.Operation = Operation.Delete;
            _form.IdSelected = IndexSelected;
            _form.UpdateDataGridViewEventHandler += UpdateDataGridView; 
            _form.ShowDialog();
        }
        #endregion
        private void UpdateDataGridView(object sender, EventArgs e)
        {
            if (_form is FormMedicine) _presenter.DisplayMedicines();
            else if (_form is FormService) _presenter.DisplayServices();
            else if (_form is FormStaff) _presenter.DisplayStaffs();
        }

        #region functionality button_click

        private void btnService_Click(object sender, EventArgs e)
        {
            if (_form != null )
                _form.Dispose();
            _form = new FormService(_serviceRepository);
            _presenter.DisplayServices();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            if (_form != null)
                _form.Dispose();
            _form = new FormStaff(_staffRepository,_permissionRepository);
            _presenter.DisplayStaffs();
        }

        private  void btnMedicine_Click(object sender, EventArgs e)
        {
            if (_form != null)
                _form.Dispose();
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
            //TODO: Search Staff & service
           _presenter.SearchMedicines();
        }
    }
}


