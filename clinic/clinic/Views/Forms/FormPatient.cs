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
    public partial class FormPatient : OperationForm, IPatientView
    {
        //ERROR: Refactor not use async
        private readonly IPatientRepository _repository;
        private PatientPresenter _presenter;
        public EventHandler updateDgvEvent;

        #region IView Properties
        public string Txtname { get => txtName.Text; set => txtName.Text = value; }
        public string TxtPhone { get => txtPhone.Text; set => txtPhone.Text = value; }
        public string TxtAge { get => txtAge.Text; set => txtAge.Text = value; }
        public string CbGender { get => cbGender.Text; set => cbGender.Text = value; }
        #endregion
        public FormPatient(IPatientRepository patientRepository)
        {
            _repository = patientRepository;
            InitializeComponent();
        }

        private void FormPatient_Load(object sender, EventArgs e)
        {
            _presenter = new PatientPresenter(_repository, this);
            cbGender.SelectedIndex = 0;
        }

        private  void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                string err = _presenter.Add();
                if (!string.IsNullOrWhiteSpace(err))
                {
                    MessageBox.Show(err, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.Close();
                updateDgvEvent?.Invoke(this,null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Validate textbox event
        private string _errMessage;
        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateStringInput(txtName.Text, out _errMessage))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            errorProvider.SetError(txtName, _errMessage);
        }
        #endregion

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateStringInput(txtPhone.Text, out _errMessage))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            errorProvider.SetError(txtPhone, _errMessage);
        }

        private void txtAge_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateStringInput(txtAge.Text, out _errMessage))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            errorProvider.SetError(txtAge, _errMessage);
        }
    }
}
