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
using clinic.Views.Forms;

namespace clinic
{
    public partial class FormService : OperationForm, IServiceView
    {
        private readonly IServiceRepository _repository;
        private readonly IMedicineRepository _medicineRepository;
        private ServicePresenter _presenter;
        public FormService(IServiceRepository serviceRepository, IMedicineRepository medicineRepository)
        {
            _repository = serviceRepository;
            _medicineRepository = medicineRepository;
            InitializeComponent();
        }
        #region IView Properties
        public string TxtServiceName { get => txtServiceName.Text; set => txtServiceName.Text = value; }
        public string TxtPrice { get => txtPrice.Text; set => txtPrice.Text = value; }
        public string ErrorMessage { get; set; }
        public ComboBox CbServiceTypes { get => cbServiceType; set => cbServiceType = value; }
        public int? SelectedMedicineId { get; set; }
        #endregion

        private void FormService_Load(object sender, EventArgs e)
        {
            _presenter = new ServicePresenter(_repository, this);
            _presenter.LoadServiceTypes();

            if (Operation != Operation.Insert)
            {
                _presenter.Display(IdSelected);
            }

            if (Operation == Operation.Delete)
            {
                this.txtServiceName.Enabled = false;
                this.txtPrice.Enabled = false;

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
        private void txtServiceName_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateName())
            {
                e.Cancel = false ;
            }
            else
            {
                e.Cancel = true;
            }
            
            errorProvider.SetError(txtServiceName, ErrorMessage);
        }
        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidatePrice())
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            errorProvider.SetError(txtPrice, ErrorMessage);
        }

        #endregion

        private void FormService_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateDataGridViewEventHandler?.Invoke(this, null);
            this.Dispose();
        }


        private void btnSelectMedicine_Click(object sender, EventArgs e)
        {
            using (FormDisplayMedicine form = new FormDisplayMedicine(_medicineRepository))
            {
                form.ShowDialog();

                SelectedMedicineId = form.SelectedMedicineId;

                txtSelectedMedicine.Text = form.SelectedMedicineName;
            }
        }
    }
}
