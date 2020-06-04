using clinic.Models;
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
    public partial class FormDisplayPrescription : Form, IDisplayPrescriptionView
    {
        private IPrescriptionRepository _repository;
        private DisplayPrescriptionPresenter _presenter;

        public FormDisplayPrescription(IPrescriptionRepository prescriptionRepository)
        {
            _repository = prescriptionRepository;
            InitializeComponent();
        }

        public int BillId { get ; set ; }
        public object DgvDisplayDataSource { get => dgvDisplay.DataSource; set => dgvDisplay.DataSource = value; }
        public string LbPatientName { get => lbPatientName.Text; set => lbPatientName.Text = value; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDisplayPrescription_Load(object sender, EventArgs e)
        {
            _presenter = new DisplayPrescriptionPresenter(_repository, this);

            _presenter.Display();
        }
    }
}
