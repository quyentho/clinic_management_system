using clinic.Models;
using clinic.Models.Repositories;
using FluentAssertions;
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
    public class ServiceRepositoryTest
    {
        private Mock<clinicEntities> _stubDbContext;
        private List<clinic_service> _stubServiceList;
        private ServiceRepository _sut;

        [TestInitialize]
        public void Test_Initialize()
        {
            _stubServiceList = new List<clinic_service>()
            {
               new clinic_service(){ id = 1, service_name = "Thu mau", price = 50000, is_active = true},
               new clinic_service(){ id = 2, service_name = "Kham Benh", price = 40000, is_active = true},
               new clinic_service(){ id = 3, service_name = "Sieu am", price = 70000, is_active = true}
            };

            var stubServiceDbSet = new Mock<DbSet<clinic_service>>();
            stubServiceDbSet.As<IQueryable<clinic_service>>().Setup(s => s.Provider)
                .Returns(_stubServiceList.AsQueryable().Provider);
            stubServiceDbSet.As<IQueryable<clinic_service>>().Setup(s => s.Expression)
                .Returns(_stubServiceList.AsQueryable().Expression);
            stubServiceDbSet.As<IQueryable<clinic_service>>().Setup(s => s.ElementType)
                .Returns(_stubServiceList.AsQueryable().ElementType);
            stubServiceDbSet.As<IQueryable<clinic_service>>().Setup(s => s.GetEnumerator())
                .Returns(_stubServiceList.AsQueryable().GetEnumerator());

            _stubDbContext = new Mock<clinicEntities>();
            _stubDbContext.Setup(c => c.clinic_service).Returns(stubServiceDbSet.Object);
            _stubDbContext.Setup(c => c.Set<clinic_service>()).Returns(stubServiceDbSet.Object);

            _sut = new ServiceRepository(_stubDbContext.Object);
        }
        [TestMethod]
        public void GetServiceList_WhenCalled_ReturnsServiceList()
        {
            var serviceList = _sut.GetAll();

            serviceList.Should().BeEquivalentTo(_stubServiceList);
        }
        [TestMethod]
        public void GetServiceById_WithExistsId_ReturnsExactService()
        {
            int id = 1;
            var service = _sut.GetServiceById(id);

            service.Should().NotBeNull()
                .And
                .BeEquivalentTo(_stubServiceList[0]);
        }
        [TestMethod]
        public void GetServiceById_WithExistsId_ReturnsExactService2()
        {
            int id = 2;
            var service = _sut.GetServiceById(id);

            service.Should().NotBeNull()
                .And
                .BeEquivalentTo(_stubServiceList[1]);
        }
        [TestMethod]
        public void GetServiceById_WithNoneExistsId_ReturnsNull()
        {
            int id = 4;

            var service = _sut.GetServiceById(id);

            service.Should().BeNull();
        }
        [TestMethod]
        public void InsertService_WithValidService_InsertToList()
        {
            var newService = new clinic_service()
            {
                id = 4,
                service_name = "test"
                ,
                is_active = true,
                price = 10000
            };

            _sut.Insert(newService);

            _sut.GetAll().Should().Contain(newService);
        }
        [TestMethod]
        public void InsertService_WithValidService_InsertToDatabaseSuccessfully()
        {
            var newService = new clinic_service()
            {
                id = 4,
                service_name = "test",
                is_active = true,
                price = 10000
            };

            Action act = () => _sut.Insert(newService);

            act.Should().NotThrow();

        }
        [TestMethod]
        public void UpdateService_WithValidService_UpdateServiceInList()
        {
            var serviceUpdated = new clinic_service()
            {
                id = 1,
                service_name = "test",
                is_active = true,
                price = 10000
            };

            _sut.Update(serviceUpdated);

            _sut.GetAll().Should()
                .Contain(serviceUpdated)
                .And
                .NotContain(_stubServiceList[0]);
        }
       
        [TestMethod]
        public void DeleteService_ExistsId_DelelteServiceInDatabaseSuccessfully()
        {
            SetupDbSetForUsingFindMethod();
            int id = 1;
            var serviceDeleted = new clinic_service();
            _stubDbContext.Setup(c => c.clinic_service.Remove(It.IsAny<clinic_service>()))
                .Callback<clinic_service>(service => serviceDeleted = service);

            _sut.Delete(id);

            _stubDbContext.Verify(c => c.clinic_service.Remove(serviceDeleted),Times.Once);
            _stubDbContext.Verify(c => c.SaveChanges());
        }
        [TestMethod]
        public void DeleteService_DeleteSuccessfully_NotDeleteAllData()
        {
            _sut.Delete(1);

            PrivateObject privateObject = new PrivateObject(_sut);
            var database = privateObject.Invoke("GetServiceList");

            database.Should().NotBeNull();
        }
        [TestMethod]
        public void GetServicesByName_NoneExistsServiceName_ReturnEmpty()
        {
            string noneExistsName = "none";

            var actual = _sut.GetServicesByName(noneExistsName);

            actual.Should().BeEmpty();
        }
        [TestMethod]
        public void GetServicesByName_ExistsServiceName_ReturnListService()
        {
            var existsName = "Thu mau";

            var actual = _sut.GetServicesByName(existsName);

            actual.Should().BeEquivalentTo(_stubServiceList[0]);
        }
        private void SetupDbSetForUsingFindMethod()
        {
            _stubDbContext.Setup(c => c.clinic_service.Find(It.IsAny<object[]>()))
                .Returns<object[]>(ids => _stubServiceList.FirstOrDefault(s => s.id == (int)ids[0]));
        }
      
    }

}
