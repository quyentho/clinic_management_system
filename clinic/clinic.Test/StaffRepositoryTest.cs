using clinic.Models;
using clinic.Models.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Test
{
    [TestClass]
    public class StaffRepositoryTest
    {
        private readonly Mock<clinicEntities> _stubDbContext;
        private IQueryable<staff> _fakeStaffList;
        private IQueryable<permission> _fakePermissionList;
        private readonly StaffRepository _mockStaffRepo;

        public StaffRepositoryTest()
        {
            _fakeStaffList = new List<staff>()
            {
                new staff(){ id = 1, full_name = "nv1", date_of_birth = new DateTime(1999,1,3),
                    phone_number ="0945664870", salary = 4500000, is_still_working = true, permission_id = 1},
                new staff(){ id = 2, full_name = "nv2", date_of_birth = new DateTime(1994,12,2),
                    phone_number ="0948664870", salary = 5000000, is_still_working = true, permission_id = 2},
                new staff(){ id = 3, full_name = "nv3", date_of_birth = new DateTime(2006,7,7),
                    phone_number ="0941664870", salary = 2500000, is_still_working = true, permission_id = 3},
            }.AsQueryable();

            var stubStaffDbSet = new Mock<DbSet<staff>>();
            stubStaffDbSet.As<IQueryable<staff>>().Setup(m => m.Provider).Returns(_fakeStaffList.Provider);
            stubStaffDbSet.As<IQueryable<staff>>().Setup(m => m.Expression).Returns(_fakeStaffList.Expression);
            stubStaffDbSet.As<IQueryable<staff>>().Setup(m => m.ElementType).Returns(_fakeStaffList.ElementType);
            stubStaffDbSet.As<IQueryable<staff>>().Setup(m => m.GetEnumerator()).Returns(()=>_fakeStaffList.GetEnumerator());

            _fakePermissionList = new List<permission>()
            {
                new permission(){ id = 1, position_name = "QUẢN LÝ" },
                new permission(){ id = 2, position_name = "BÁC SĨ" },
                new permission(){ id = 3, position_name = "Y SĨ" }
            }.AsQueryable();

            var stubPermissionDbSet = new Mock<DbSet<permission>>();
            stubPermissionDbSet.As<IQueryable<permission>>().Setup(m => m.Provider).Returns(_fakePermissionList.Provider);
            stubPermissionDbSet.As<IQueryable<permission>>().Setup(m => m.Expression).Returns(_fakePermissionList.Expression);
            stubPermissionDbSet.As<IQueryable<permission>>().Setup(m => m.ElementType).Returns(_fakePermissionList.ElementType);
            stubPermissionDbSet.As<IQueryable<permission>>().Setup(m => m.GetEnumerator()).Returns(()=>_fakePermissionList.GetEnumerator());

            _stubDbContext = new Mock<clinicEntities>();
            _stubDbContext.Setup(c => c.staffs).Returns(stubStaffDbSet.Object);
            var stubPermissionRepo = new PermissionRepository(_stubDbContext.Object);
            _mockStaffRepo = new StaffRepository(_stubDbContext.Object,stubPermissionRepo);
        }
        [TestMethod]
        public void GetStaffList_WhenCalled_ReturnsStaffList()
        {
            var actual = _mockStaffRepo.GetStaffList();

            CollectionAssert.AreEqual(_fakeStaffList.ToList(), actual);
        }
    }

}
