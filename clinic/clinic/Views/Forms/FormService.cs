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
using clinic.Presenters;
using clinic.Views;

namespace clinic
{
    public partial class FormService : Form, IServiceView
    {
        private readonly clinicEntities _clinicEntities;
        //private Presenter
        public FormService(clinicEntities clinicEntities)
        {
            _clinicEntities = clinicEntities;
            InitializeComponent();
        }
        #region Properties
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public string TxtTenDichVu { get; set; }
        public string TxtGia { get; set; }
        public string ErrorMessage { get; set; }
        #endregion
        private void FormService_Load(object sender, EventArgs e)
        {

        }
    }
}
