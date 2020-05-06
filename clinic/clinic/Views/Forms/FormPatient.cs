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
       // PatientPresenter _presenter;
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
           // _presenter = new PatientPresenter(_repository, this);
        }

        private  void btnOK_Click(object sender, EventArgs e)
        {
            //if (_presenter.ValidateAllInput())
            //{
            //   await _presenter.Add();
            //    UpdateDataGridView.Invoke(this,null);
            //    this.Close();
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Validate textbox event
        private void txtName_Validated(object sender, EventArgs e)
        {
            //bool isValid = _presenter.ValidateName();
            //if (!isValid)
            //{
            //    errorProvider1.SetError(txtName, ErrorMessage);
            //}
        }


        private void txtAge_Validated(object sender, EventArgs e)
        {
            //bool isValid = _presenter.ValidateAge();
            //if (!isValid)
            //{
            //    errorProvider3.SetError(txtAge, ErrorMessage);
            //}
        }
        #endregion
    }
}
