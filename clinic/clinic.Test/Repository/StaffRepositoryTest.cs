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

namespace clinic.Test.Repository
{
    [TestClass]
    public class StaffRepositoryTest
    {
        List<StaffViewModel> _mockStaffListVM;
        private Mock<IAccountRepository> _stubAccountRepository;
        StaffRepository _sut;
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
             
            var stubPermissionRepo = new PermissionRepository(_stubDbContext.Object);

            _stubAccountRepository = new Mock<IAccountRepository>();

            _sut = new StaffRepository(_stubDbContext.Object, stubPermissionRepo,_stubAccountRepository.Object);

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
            var actual = _sut.GetStaffList();

            actual.Should().Equals(_mockStaffListVM);
        }

        [TestMethod]
        public void GetStaffById_WithValidId_ReturnsRightStaff()
        {
            using (new AssertionScope())
            {
                int validId = 1;
                StaffViewModel actual = _sut.GetStaffById(validId);
                actual.Should().Equals(_mockStaffListVM[0]);

                validId = 2;
                actual = _sut.GetStaffById(validId);
                actual.Should().Equals(_mockStaffListVM[1]);

                validId = 3;
                actual = _sut.GetStaffById(validId);
                actual.Should().Equals(_mockStaffListVM[2]);
            }
        }

        [TestMethod]
        public void InsertStaff_HasNewPhoneNumber_InsertToListVM()
        {
            var newStaff = new staff()
            {
                id = 4,
                full_name = "nv4",
                date_of_birth = new DateTime(1999, 1, 3),
                phone_number = "1945664870",
                salary = 4500000,
                is_still_working = true,
                permission_id = 1,
            };

            _sut.InsertStaff(newStaff);

            var mockUpdatedStaffVMs = _sut.GetStaffList();

            StaffViewModel stubStaffVM = new StaffViewModel()
            {
                Id = 4,
                DateOfBirth = new DateTime(1999, 1, 3),
                FullName = "nv4",
                PhoneNumber = "1945664870",
                Salary = 4500000,
                PositionName = "QUAN LY"
            };
            mockUpdatedStaffVMs.Should().ContainEquivalentOf(stubStaffVM);
        }

        [TestMethod]
        public void InsertStaff_HasNewPhoneNumber_InsertToDatabaseSuccessfully()
        {
            var mockStaff = new staff()
            {
                
                full_name = "nv4",
                date_of_birth = new DateTime(1999, 1, 3),
                phone_number = "1945664870",
                salary = 4500000,
                is_still_working = true,
                permission_id = 1,
            };

            _sut.InsertStaff(mockStaff);
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

            _sut.UpdateStaff(staffUpdated);

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

            _sut.UpdateStaff(staffUpdated);

            var staffUpdatedVM = new StaffViewModel()
            {
                Id = 1,
                FullName = "nvupdate",
                DateOfBirth = new DateTime(1999, 1, 3),
                PhoneNumber = "0945664870",
                Salary = 700000,
                PositionName = "QUAN LY"
            };

            _sut.GetStaffList().Should().ContainEquivalentOf(staffUpdatedVM);
        }

        [TestMethod]
        public void DeleteStaff_WithValidId_DeleteStaffInDatabaseSuccessfully()
        {
            int id = 1;

            _sut.DeleteStaff(id);

            _stubDbContext.Verify(c => c.staffs.Remove(_stubStaffList[0]));
            _stubDbContext.Verify(c => c.SaveChanges());
        }

        [TestMethod]
        public void DeleteStaff_WithValidId_DeleteStaffInList()
        {
            int id = 1;

            _sut.DeleteStaff(id);
            var staffVM = _sut.GetStaffById(id);

            _sut.GetStaffList().Should().NotContain(staffVM);
        }

        [TestMethod]
        public void InsertStaff_ExistingPhoneNumber_ThrowArgumentException()
        {
            var staffWithDuplicatePhoneNumber = new staff()
            {
                id = 5,
                full_name = "nv5",
                date_of_birth = new DateTime(1999, 1, 3),
                phone_number = "0945664870",
                salary = 4500000,
                is_still_working = true,
                permission_id = 1
            };

            Action act = () => _sut.InsertStaff(staffWithDuplicatePhoneNumber);

            act.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void InsertStaff_HasNewPhoneNumber_CreateNewAccount()
        {
            var newStaff = new staff()
            {
                
                full_name = "nv4",
                date_of_birth = new DateTime(1999, 1, 3),
                phone_number = "1945664870",
                salary = 4500000,
                is_still_working = true,
                permission_id = 1,
            };
            var newAccount = new account();
            _stubAccountRepository.Setup(a => a.Insert(It.IsAny<account>())).Callback<account>(a => newAccount = a);
            
          
           


            _sut.InsertStaff(newStaff);

            _stubAccountRepository.Verify(a => a.Insert(newAccount),Times.Once);
            _stubDbContext.Verify(c => c.SaveChanges());
        }
    }

}
