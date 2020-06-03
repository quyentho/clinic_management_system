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
    //ERROR: refactor not use async
    public partial class ReceptionForm : Form, IReceptionView
    {
      //  private ReceptionPresenter _presenter;
        private readonly clinicEntities _clinicEntities;
        private readonly ReceptionPresenter _presenter;
        private readonly PatientRepository _patientRepository;
        private readonly BillRepository _billRepository;
        private readonly ServiceRepository _serviceRepository;
        private readonly MedicineRepository _medicineRepository;
        private readonly AccountRepository _accountRepository;
        private readonly PermissionRepository _permissionRepository;
        private readonly StaffRepository _staffRepository;

        public string TxtSearch { get => txtSearch.Text; set => txtSearch.Text = value; }
        public int PatientIdSelected { get; set ; }
        public object DgvReceptionDataSource { get => dgvReception.DataSource; set => dgvReception.DataSource = value; }
        public string CbSearchValue { get => cbSearch.Text;}
        public ReceptionFunctionalityEnum Functionality { get  ; set  ; }

        public ReceptionForm()
        {
            _clinicEntities = new clinicEntities();
            InitializeComponent();
            _patientRepository = new PatientRepository(_clinicEntities);
            _billRepository = new BillRepository(_clinicEntities);
            _serviceRepository = new ServiceRepository(_clinicEntities);
            _medicineRepository = new MedicineRepository(_clinicEntities);
            _accountRepository = new AccountRepository(_clinicEntities);
            _permissionRepository = new PermissionRepository(_clinicEntities);
            _staffRepository = new StaffRepository(_clinicEntities,_permissionRepository, _accountRepository);
            _presenter = new ReceptionPresenter(_clinicEntities, this, _billRepository, _patientRepository);

        }

        private  void btnPatientFiles_Click(object sender, EventArgs e)
        {
            btnAddPatient.Enabled = true;
            Functionality = ReceptionFunctionalityEnum.Patient;
            _presenter.DisplayPatientsData();
        }

        private void ReceptionForm_Load(object sender, EventArgs e)
        {
            Functionality = ReceptionFunctionalityEnum.Patient;
            btnPatientFiles.PerformClick();
            cbSearch.SelectedIndex = 0;
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            btnAddPatient.Enabled = false;
            _presenter.DisplayListUnpaidBill();
            Functionality = ReceptionFunctionalityEnum.Bill;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Functionality == ReceptionFunctionalityEnum.Patient)
            {
                using (FormPatient form = new FormPatient(_patientRepository))
                {
                    form.updateDgvEvent += btnPatientFiles_Click;
                    form.ShowDialog();
                }
            }
        }
        private  void btnSearch_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtSearch.Text))
                _presenter.Search();
        }
        private void dgvReception_CellEnter(object sender, DataGridViewCellEventArgs e)
        {           
            PatientIdSelected = int.Parse(dgvReception.Rows[e.RowIndex].Cells[0].Value.ToString());
            btnAssignService.Enabled = true;
            btnAddPrescription.Enabled = true;

            if (Functionality == ReceptionFunctionalityEnum.Bill)
            {
                PatientIdSelected = int.Parse(dgvReception.Rows[e.RowIndex].Cells[1].Value.ToString());
                btnPay.Enabled = true;
            }
        }
        private void btnAssignService_Click(object sender, EventArgs e)
        {
            _presenter.CreateBillIfNotExists();
            using (FormAssignService form = new FormAssignService(_serviceRepository,_billRepository))
            {
                form.PatientId = PatientIdSelected;
                form.ShowDialog();
            }
            btnBills.PerformClick();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                if (Functionality == ReceptionFunctionalityEnum.Bill)
                    btnBills.PerformClick();
                else
                    btnPatientFiles.PerformClick();
            }
        }
        private void btnAddPrescription_Click(object sender, EventArgs e)
        {
            _presenter.CreateBillIfNotExists();
            using (FormPrescription form = new FormPrescription(_medicineRepository, _billRepository))
            {
                form.PatientId = PatientIdSelected;
                form.ShowDialog();
            }
            btnBills.PerformClick();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if(Functionality == ReceptionFunctionalityEnum.Bill)
                    _presenter.PayBill();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Thanh Toán Thành Công");
            btnBills.PerformClick();
        }

        private void btnPersonality_Click(object sender, EventArgs e)
        {
            using (FormPersonalInfor form = new FormPersonalInfor(_staffRepository))
            {
                form.ShowDialog();
            }
        }
    }
}
