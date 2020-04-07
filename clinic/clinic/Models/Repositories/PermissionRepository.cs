using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        clinicEntities _clinicEntities;
        public PermissionRepository(clinicEntities clinicEntities)
        {
            _clinicEntities = clinicEntities;
        }
        public async Task<IList<permission>> GetPermissions()
        {
            return await Task.Run(() => _clinicEntities.permissions.ToList());
        }


    }
}
