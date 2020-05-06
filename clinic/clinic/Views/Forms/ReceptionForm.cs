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
        
        private Form _form;

        public string TxtSearch { get => txtSearch.Text; set => txtSearch.Text = value; }
        public int IdSelected { get; set ; }

        public ReceptionForm()
        {
            _clinicEntities = new clinicEntities();
            InitializeComponent();
        }

        private  void btnPatientFiles_Click(object sender, EventArgs e)
        {
         //   dgvReception.DataSource = await _presenter.GetPatientData();
        }

        private void ReceptionForm_Load(object sender, EventArgs e)
        {
            //_presenter = new ReceptionPresenter(_clinicEntities, this);

            //btnPatientFiles.PerformClick();
            //cbSearch.SelectedIndex = 0;           
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
          //  dgvReception.DataSource = _presenter.GetBillsUnpaidData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //_form = new FormPatient(new PatientRepository(_clinicEntities));
            //(_form as FormPatient).UpdateDataGridView += btnPatientFiles_Click;
            //_form.ShowDialog();
        }

        private  void btnSearch_Click(object sender, EventArgs e)
        {
            //if (cbSearch.Text == "SDT")
            //    dgvReception.DataSource =await _presenter.SearchPatientsByPhone();
            //else
            //    dgvReception.DataSource =await _presenter.SearchPatientsByName();
        }
        private void dgvReception_CellEnter(object sender, DataGridViewCellEventArgs e)
        {           
            IdSelected = int.Parse(dgvReception.Rows[e.RowIndex].Cells[0].Value.ToString());
            btnAssignService.Enabled = true;
            btnAddPrescription.Enabled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                EventHandler handler = btnPatientFiles_Click;
                handler?.Invoke(sender, null);
            }
        }

        private void btnAssignService_Click(object sender, EventArgs e)
        {

        }
    }
}
