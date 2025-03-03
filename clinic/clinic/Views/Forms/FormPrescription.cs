﻿using clinic.Models;
using clinic.Presenters;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace clinic.Views.Forms
{
    public partial class FormPrescription : Form, IPrescriptionView
    {
        private PrescriptionPresenter _presenter;
        private IMedicineRepository _medicineRepository;
        private IBillRepository _billRepository;
        private readonly IPrescriptionRepository _prescriptionRepository;
        #region IView properties
        public object DgvMedicineDataSource { get => dgvMedicine.DataSource; set => dgvMedicine.DataSource = value; }
        public int PatientId { get; set; }
        public int MedicineSelectedId { get; set; }
        public int RemoveIndex { get; set; }
        public object DgvMedicinesSelectedDatasource { get => dgvMedicinesSelected.DataSource; set => dgvMedicinesSelected.DataSource = value; }
        public string ErrMessage { get; set; }
        public string Descriptions { get; set; }
        public int Quantity { get; set; }
        public string TxtSearch { get => txtSearch.Text; set => txtSearch.Text = value; }
        #endregion
        public FormPrescription(IMedicineRepository medicineRepository, IBillRepository billRepository, IPrescriptionRepository prescriptionRepository)
        {
            _medicineRepository = medicineRepository;
            _billRepository = billRepository;
            this._prescriptionRepository = prescriptionRepository;
            InitializeComponent();
        }

        private void FormPrescription_Load(object sender, EventArgs e)
        {
            _presenter = new PrescriptionPresenter(_medicineRepository, _billRepository, _prescriptionRepository, this);

            _presenter.LoadExistingPrescription(PatientId);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _presenter.RemoveMedicineAssigned();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            using (FormAssignMedicine form = new FormAssignMedicine())
            {
                form.ShowDialog();
                if (form.IsSetValue == true)
                {
                    Quantity = int.Parse(form.Quantity);
                    Descriptions = form.Description;
                    _presenter.AssignMedicine();
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _presenter.AddPresciptionToBill();
            if (!string.IsNullOrEmpty(ErrMessage))
            {
                MessageBox.Show(ErrMessage);
            }

            this.Close();
        }

        private void dgvMedicine_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MedicineSelectedId = int.Parse(dgvMedicine.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void dgvMedicinesSelected_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            RemoveIndex = int.Parse(dgvMedicinesSelected.Rows[e.RowIndex].Index.ToString());
        }

        private void dgvMedicinesSelected_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvMedicinesSelected.Rows.Count > 0)
                btnRemove.Enabled = true;
        }

        private void dgvMedicinesSelected_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvMedicinesSelected.Rows.Count <= 0)
                btnRemove.Enabled = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                _presenter.DisplayMedicineDataGridView();
            else
            {
                _presenter.SearchMedicine();
            }
        }
    }
}
