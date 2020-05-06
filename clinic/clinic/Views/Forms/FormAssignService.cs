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

namespace clinic.Views.Forms
{
    public partial class FormAssignService : Form, IAssignServiceView
    {
        private readonly IServiceRepository _repository;
        private AssignServicePresenter _presenter;
        public FormAssignService(IServiceRepository repository)
        {
            _repository = repository;
           
            InitializeComponent();
        }
        public IList<clinic_service> ServiceDataSource{ get =>(IList<clinic_service>) dgvService.DataSource; set => dgvService.DataSource = value; }

        private void FormAssignServices_Load(object sender, EventArgs e)
        {
            _presenter = new AssignServicePresenter(_repository, this);

        }
    }
}
