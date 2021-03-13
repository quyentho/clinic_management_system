using System;
using System.Windows.Forms;
using clinic.Models;
using clinic.Presenters;

namespace clinic.Views.Forms
{
    public partial class FormAssignService : Form, IAssignServiceView
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IBillRepository _billRepository;
        private AssignServicePresenter _presenter;
        public FormAssignService(IServiceRepository repository, IBillRepository billRepository)
        {
            _serviceRepository = repository;
            _billRepository = billRepository;
            InitializeComponent();
        }
        #region IView Properties
        public object DgvServiceDataSource { get => dgvService.DataSource; set => dgvService.DataSource = value; }
        public int PatientId { get ; set; }
        public DataGridView DgvServicesSelected{ get => dgvServicesSelected; set => dgvServicesSelected = value; }
        public int IdServiceSelected { get; set; }
        public int IndexRemove { get; set; }
        public string ErrMessage { get ; set ; }
        #endregion
        private void FormAssignServices_Load(object sender, EventArgs e)
        {
            _presenter = new AssignServicePresenter(_serviceRepository,_billRepository, this);
            _presenter.LoadExistingServices(PatientId);

            if (dgvServicesSelected.Rows.Count > 0)
                btnRemove.Enabled = true;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            _presenter.AssignService();
        }

        private void dgvService_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            IdServiceSelected = int.Parse(dgvService.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
        private void dgvServicesSelected_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvServicesSelected.Rows.Count > 0)
                btnRemove.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _presenter.RemoveServiceAssigned();
        }

        private void dgvServicesSelected_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            IndexRemove = int.Parse(dgvServicesSelected.Rows[e.RowIndex].Index.ToString());
        }
        private void dgvServicesSelected_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvServicesSelected.Rows.Count <= 0)
                btnRemove.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _presenter.AddServicesToBill();
            if(!string.IsNullOrEmpty(ErrMessage))
            {
                MessageBox.Show(ErrMessage);
            }
            
            this.Close();
        }
    }
}
