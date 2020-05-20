using clinic.Models;
using clinic.Models.Repositories;
using FluentAssertions;
using FluentAssertions.Execution;
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
        List<StaffViewModel> _mockStaffListVM;
        StaffRepository _mockStaffRepo;
        Mock<clinicEntities> _stubDbContext;
        List<staff> _stubStaffList;
        [TestInitialize]
        public void Test_Initiallize()
        {
            var stubPermissionList = new List<permission>()
            {
                new permission(){ id = 1, position_name = "QUAN LY" },
                new permission(){id = 2, position_name = "BAC SI"},
                new permission(){id = 3, position_name = "Y SI"}
            }.AsQueryable();
            var stubPermissionDbSet = new Mock<DbSet<permission>>();
            stubPermissionDbSet.As<IQueryable<permission>>().Setup(m => m.Provider)
                .Returns(stubPermissionList.Provider);
            stubPermissionDbSet.As<IQueryable<permission>>().Setup(m => m.Expression)
                .Returns(stubPermissionList.Expression);
            stubPermissionDbSet.As<IQueryable<permission>>().Setup(m => m.ElementType)
                .Returns(stubPermissionList.ElementType);
            stubPermissionDbSet.As<IQueryable<permission>>().Setup(m => m.GetEnumerator())
                .Returns(() => stubPermissionList.GetEnumerator());

            _stubDbContext = new Mock<clinicEntities>();
            _stubDbContext.Setup(c => c.permissions).Returns(stubPermissionDbSet.Object);
            _stubDbContext.Setup(c => c.Set<permission>()).Returns(stubPermissionDbSet.Object);

            _stubStaffList = new List<staff>()
            {
                new staff(){ id = 1, full_name = "nv1", date_of_birth = new DateTime(1999,1,3),
                    phone_number ="0945664870", salary = 4500000, is_still_working = true, permission_id = 1
                    ,permission = stubPermissionList.ToList()[0]},
                new staff(){ id = 2, full_name = "nv2", date_of_birth = new DateTime(1994,12,2),
                    phone_number ="0948664820", salary = 5000000, is_still_working = true, permission_id = 2
                    ,permission = stubPermissionList.ToList()[1]},
                new staff(){ id = 3, full_name = "nv3", date_of_birth = new DateTime(2006,7,7),
                    phone_number ="0941664830", salary = 2500000, is_still_working = true, permission_id = 3
                    ,permission = stubPermissionList.ToList()[2]},
            };

            var stubStaffDbSet = new Mock<DbSet<staff>>();
            stubStaffDbSet.As<IQueryable<staff>>().Setup(m => m.Provider).Returns(_stubStaffList.AsQueryable().Provider);
            stubStaffDbSet.As<IQueryable<staff>>().Setup(m => m.Expression).Returns(_stubStaffList.AsQueryable().Expression);
            stubStaffDbSet.As<IQueryable<staff>>().Setup(m => m.ElementType).Returns(_stubStaffList.AsQueryable().ElementType);
            stubStaffDbSet.As<IQueryable<staff>>().Setup(m => m.GetEnumerator())
                .Returns(_stubStaffList.GetEnumerator());
            stubStaffDbSet.Setup(s => s.Include(It.IsAny<string>())).Returns(stubStaffDbSet.Object);
            stubStaffDbSet.Setup(s => s.Find(It.IsAny<object[]>())).Returns<object[]>(ids => _stubStaffList.FirstOrDefault(s => s.id == (int)ids[0]));


            _stubDbContext.Setup(c => c.staffs).Returns(stubStaffDbSet.Object);
            _stubDbContext.Setup(c => c.Set<staff>()).Returns(stubStaffDbSet.Object);

            var stubPermissionRepo = new Mock<IPermissionRepository>();
            stubPermissionRepo.Setup(p => p.GetPermissionList()).Returns(stubPermissionList.ToList());

            _mockStaffRepo = new StaffRepository(_stubDbContext.Object, stubPermissionRepo.Object);

            _mockStaffListVM = new List<StaffViewModel>()
            {
                new StaffViewModel(){ Id = 1, FullName = "nv1", DateOfBirth = new DateTime(1999,1,3),
                    PhoneNumber ="0945664870", Salary = 4500000, PositionName = "QUAN LY"},
                new StaffViewModel(){ Id = 2, FullName = "nv2", DateOfBirth = new DateTime(1994,12,2),
                    PhoneNumber ="0948664820", Salary = 5000000, PositionName = "BAC SI"},
                new StaffViewModel(){ Id = 3, FullName = "nv3", DateOfBirth = new DateTime(2006,7,7),
                    PhoneNumber ="0941664830", Salary = 2500000, PositionName = "Y SI"},
            };
        }

        [TestMethod]
        public void GetStaffList_WhenCalled_ReturnsStaffList()
        {
            var actual = _mockStaffRepo.GetStaffList();

            actual.Should().Equals(_mockStaffListVM);
        }

        [TestMethod]
        public void GetStaffById_WithValidId_ReturnsRightStaff()
        {
            using (new AssertionScope())
            {
                int validId = 1;
                StaffViewModel actual = _mockStaffRepo.GetStaffById(validId);
                actual.Should().Equals(_mockStaffListVM[0]);

                validId = 2;
                actual = _mockStaffRepo.GetStaffById(validId);
                actual.Should().Equals(_mockStaffListVM[1]);

                validId = 3;
                actual = _mockStaffRepo.GetStaffById(validId);
                actual.Should().Equals(_mockStaffListVM[2]);
            }
        }

        [TestMethod]
        public void InsertStaff_WhenCalled_InsertToListVM()
        {
            var mockStaff = new staff()
            {
                id = 4,
                full_name = "nv4",
                date_of_birth = new DateTime(1999, 1, 3),
                phone_number = "0945664870",
                salary = 4500000,
                is_still_working = true,
                permission_id = 1,
            };

            _mockStaffRepo.InsertStaff(mockStaff);

            var mockUpdatedStaffVMs = _mockStaffRepo.GetStaffList();

            StaffViewModel stubStaffVM = new StaffViewModel()
            {
                Id = 4,
                DateOfBirth = new DateTime(1999, 1, 3),
                FullName = "nv4",
                PhoneNumber = "0945664870",
                Salary = 4500000,
                PositionName = "QUAN LY"
            };
            mockUpdatedStaffVMs.Should().ContainEquivalentOf(stubStaffVM);
        }

        [TestMethod]
        public void InsertStaff_WhenCalled_InsertToDatabaseSuccessfully()
        {
            var mockStaff = new staff()
            {
                id = 4,
                full_name = "nv4",
                date_of_birth = new DateTime(1999, 1, 3),
                phone_number = "0945664870",
                salary = 4500000,
                is_still_working = true,
                permission_id = 1,
            };

            _mockStaffRepo.InsertStaff(mockStaff);
            _stubDbContext.Verify(c => c.staffs.Add(mockStaff), Times.Once);
            _stubDbContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void UpdateStaff_WithExistsStaff_UpdateDatabaseSuccessfully()
        {
            var staffUpdated = new staff()
            {
                id = 1,
                full_name = "nvupdate",
                date_of_birth = new DateTime(1999, 1, 3),
                phone_number = "0945664870",
                salary = 700000,
                is_still_working = true,
                permission_id = 1
            };

            _mockStaffRepo.UpdateStaff(staffUpdated);

            _stubDbContext.Verify(c => c.AddOrUpdateEntity<staff>(_stubDbContext.Object, staffUpdated));
            _stubDbContext.Verify(c => c.SaveChanges());
        }

        [TestMethod]
        public void UpdateStaff_WithExistsStaff_UpdateStaffList()
        {
            var staffUpdated = new staff()
            {
                id = 1,
                full_name = "nvupdate",
                date_of_birth = new DateTime(1999, 1, 3),
                phone_number = "0945664870",
                salary = 700000,
                is_still_working = true,
                permission_id = 1
            };

            _mockStaffRepo.UpdateStaff(staffUpdated);

            var staffUpdatedVM = new StaffViewModel()
            {
                Id = 1,
                FullName = "nvupdate",
                DateOfBirth = new DateTime(1999, 1, 3),
                PhoneNumber = "0945664870",
                Salary = 700000,
                PositionName = "QUAN LY"
            };

            _mockStaffRepo.GetStaffList().Should().ContainEquivalentOf(staffUpdatedVM);
        }

        [TestMethod]
        public void DeleteStaff_WithValidId_DeleteStaffInDatabaseSuccessfully()
        {
            int id = 1;

            _mockStaffRepo.DeleteStaff(id);

            _stubDbContext.Verify(c => c.staffs.Remove(_stubStaffList[0]));
            _stubDbContext.Verify(c => c.SaveChanges());
        }

        [TestMethod]
        public void DeleteStaff_WithValidId_DeleteStaffInList()
        {
            int id = 1;

            _mockStaffRepo.DeleteStaff(id);
            var staffVM = _mockStaffRepo.GetStaffById(id);

            _mockStaffRepo.GetStaffList().Should().NotContain(staffVM);
        }
    }

}
