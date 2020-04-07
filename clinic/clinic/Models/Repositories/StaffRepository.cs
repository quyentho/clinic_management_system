using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Models.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly clinicEntities _clinicEntities;
        public StaffRepository(clinicEntities entities)
        {
            _clinicEntities = entities;
        }
        public void DeleteStaff(staff staff)
        {
            staff.is_still_working = false;
            _clinicEntities.Entry(staff).Property(p => p.is_still_working).IsModified = true;
        }

        public staff GetStaffById(int id)
        {
            staff staffFromDb = _clinicEntities.staffs.FirstOrDefault(staff => staff.id == id);

            return staffFromDb;
        }

        public async Task<IEnumerable<staff>> GetStaffs()
        {
            return await Task.Run(() => _clinicEntities.staffs.Where(s=>s.is_still_working == true).ToList());
        }

        public void InsertStaff(staff staff)
        {
            _clinicEntities.staffs.Add(staff);
        }

        public async Task Save()
        {
            await _clinicEntities.SaveChangesAsync();
        }

        public void UpdateStaff(staff staff)
        {
            _clinicEntities.Entry(staff).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
