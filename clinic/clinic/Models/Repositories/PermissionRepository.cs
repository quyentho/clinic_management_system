using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly clinicEntities _clinicEntities;
        private List<permission> _permissions;
        public PermissionRepository(clinicEntities clinicEntities)
        {
            _clinicEntities = clinicEntities;
            _permissions = GetPermissionsFromDatabase();
        }
        public List<permission> GetPermissionList()
        {
           return _permissions;
        }
        private List<permission> GetPermissionsFromDatabase()
        {
            return  _clinicEntities.permissions.AsNoTracking().ToList();
        }
    }
}
