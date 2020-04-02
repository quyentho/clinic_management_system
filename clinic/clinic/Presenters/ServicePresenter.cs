using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinic.Models;
using clinic.Views;
namespace clinic.Presenters
{
    class ServicePresenter
    {
        private readonly clinicEntities _clinicEntities;
        private readonly IServiceView _view;
        public ServicePresenter(clinicEntities clinicEntities, IServiceView view)
        {
            _clinicEntities = clinicEntities;
            _view = view;
        }
      //  public async Task Add
    }
}
