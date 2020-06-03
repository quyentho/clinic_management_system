using System;
using System.ComponentModel;
using System.Windows.Forms;
using clinic.Presenters;

namespace clinic.Views.Forms
{
    public partial class FormAssignMedicine : Form, IAssignMedicineView
    {
        private AssignMedicinePresenter _presenter;

        public FormAssignMedicine()
        {
            InitializeComponent();
        }

        public string Quantity { get => txtQuantity.Text; set => txtQuantity.Text = value; }
        public string Description { get =>rtbDescription.Text; set =>rtbDescription.Text = value; }
        public bool IsSetValue { get; set; } = false;

        private void FormAssignMedicine_Load(object sender, EventArgs e)
        {
            _presenter = new AssignMedicinePresenter(this);
        }

        #region Validating input event
        private string _errMessage;

        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateNumberInput(txtQuantity.Text, out _errMessage))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            errorProvider.SetError(txtQuantity, _errMessage);
        }
        #endregion

        private void rtbDescription_Validating(object sender, CancelEventArgs e)
        {
            if (_presenter.ValidateStringInput(rtbDescription.Text, out _errMessage))
                e.Cancel = false;
            else e.Cancel = true;
            errorProvider.SetError(rtbDescription, _errMessage);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                IsSetValue = true;
                this.Close();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

   
}
