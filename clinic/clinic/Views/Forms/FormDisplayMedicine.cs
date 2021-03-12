using clinic.Models;
using clinic.Presenters;
using System;
using System.Windows.Forms;

namespace clinic.Views.Forms
{
    public partial class FormDisplayMedicine : Form, IDisplayMedicineView
    {
        private IMedicineRepository _repository;
        private DisplayMedicinePresenter _presenter;

        public FormDisplayMedicine(IMedicineRepository medicineRepository)
        {
            _repository = medicineRepository;
            InitializeComponent();
        }
        public object DgvDisplayDataSource { get => dgvDisplay.DataSource; set => dgvDisplay.DataSource = value; }
        public string TxtSearchText { get => txtSearch.Text; set => txtSearch.Text = value; }

        public int SelectedMedicineId { get; set; }
        public string SelectedMedicineName { get; set; }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDisplayMedicine_Load(object sender, EventArgs e)
        {
            _presenter = new DisplayMedicinePresenter(_repository, this);

            _presenter.Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                _presenter.Display();
            else
            {
                _presenter.SearchMedicine();
            }
        }

        private void dgvDisplay_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dgvDisplay_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedMedicineId = int.Parse(dgvDisplay.Rows[e.RowIndex].Cells[0].Value.ToString());
            SelectedMedicineName = dgvDisplay.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.Close();
        }
    }
}
