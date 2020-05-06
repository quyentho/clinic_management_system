using clinic.Models;
using clinic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Presenters
{
    public class AssignServicePresenter
    {
        private readonly IServiceRepository _repository;
        private readonly IAssignServiceView _view;
        public AssignServicePresenter(IServiceRepository repository,IAssignServiceView view)
        {
            _repository = repository;
            _view = view;

            DisplayServiceDataGridView();
        }

        private void DisplayServiceDataGridView()
        {
            _view.ServiceDataSource = _repository.GetServiceList();
        }
    }
}
