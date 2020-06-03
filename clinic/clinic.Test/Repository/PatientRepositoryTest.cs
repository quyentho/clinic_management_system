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
    public class PatientRepositoryTest
    {
        private Mock<clinicEntities> _stubDbContext;
        private List<patient> _stubPatientList;
        private PatientRepository _sut;

        [TestInitialize]
        public void Test_Initiallize()
        {
            _stubPatientList = new List<patient>()
            {
                new patient(){ id=1, patient_name = "bn1", age= 10, gender = "nam", phone_number = "0123456789"},
                new patient(){ id=2, patient_name = "bn2", age= 40, gender = "nu", phone_number = "0123452789"},
                new patient(){ id=3, patient_name = "bn3", age= 35, gender = "nam", phone_number = "0123656789"},
                new patient(){ id=4, patient_name = "bn1", age= 10, gender = "nam", phone_number = "0223456789"}
            };

            var stubPatientDbSet = new Mock<DbSet<patient>>();
            stubPatientDbSet.As<IQueryable<patient>>().Setup(p => p.Provider)
                .Returns(_stubPatientList.AsQueryable().Provider);
            stubPatientDbSet.As<IQueryable<patient>>().Setup(p => p.Expression)
                .Returns(_stubPatientList.AsQueryable().Expression);
            stubPatientDbSet.As<IQueryable<patient>>().Setup(p => p.ElementType)
                .Returns(_stubPatientList.AsQueryable().ElementType);
            stubPatientDbSet.As<IQueryable<patient>>().Setup(p => p.GetEnumerator())
                .Returns(_stubPatientList.AsQueryable().GetEnumerator());

            _stubDbContext = new Mock<clinicEntities>();
            _stubDbContext.Setup(c => c.patients).Returns(stubPatientDbSet.Object);
            _stubDbContext.Setup(c => c.Set<patient>()).Returns(stubPatientDbSet.Object);

            _sut = new PatientRepository(_stubDbContext.Object);
        }

        [TestMethod]
        public void GetPatientList_WhenCalled_ReturnsPatientList()
        {
            var patientList = _sut.GetPatientList();

            patientList.Should().BeEquivalentTo(_stubPatientList);
        }
        [TestMethod]
        public void GetPatientById_WithValidId_ReturnsPatientExactly()
        {
            int id = 1;

            var actual = _sut.GetPatientById(id);

            actual.Should().BeEquivalentTo(_stubPatientList[0]);
        }
        [TestMethod]
        public void GetPatientById_WithInValidId_ReturnsNull()
        {
            int id = 5;

            var actual = _sut.GetPatientById(id);

            actual.Should().BeNull();
        }
        [TestMethod]
        public void InsertPatient_WithValidPatient_InsertPatientToList()
        {
            var patient = new patient()
            {
                id = 5,
                patient_name = "bn5",
                age = 15,
                gender = "nam",
                phone_number = "0123496789"
            };

            _sut.InsertPatient(patient);

            _sut.GetPatientList().Should().Contain(patient);
        }
        [TestMethod]
        public void InsertPatient_WithValidPatient_InsertPatientToDatabaseSuccessfully()
        {
            var patient = new patient()
            {
                id = 5,
                patient_name = "bn5",
                age = 15,
                gender = "nam",
                phone_number = "0123096789"
            };

            _sut.InsertPatient(patient);

            _stubDbContext.Verify(c => c.patients.Add(patient),Times.Once);
            _stubDbContext.Verify(c => c.SaveChanges(), Times.Once);
        }
        [TestMethod]
        public void UpdatePatient_WithValidInput_UpdateDatabaseSuccessfully()
        {
            var patientUpdated = new patient()
            {
                id = 1,
                patient_name = "bnUpdate",
                age = 12,
                gender = "Nu",
                phone_number = "0123456789"
            };

             Action act = () =>  _sut.UpdatePatient(patientUpdated);

            act.Should().NotThrow();
        }
        [TestMethod]
        public void UpdatePatient_WithValidInput_UpdatePatientListExactly()
        {
            var patientUpdated = new patient()
            {
                id = 1,
                patient_name = "bnUpdate",
                age = 12,
                gender = "Nu",
                phone_number = "0123456789"
            };

            _sut.UpdatePatient(patientUpdated);
           

            _sut.GetPatientList().Should().Contain(patientUpdated);
        }

        [TestMethod]
        public void GetPatientsByName_WithExistsPatientName_ReturnExactly()
        {
            var patientName = "bn2";

            var actual = _sut.GetPatientsByName(patientName);

            actual.Should().BeEquivalentTo(_stubPatientList[1]);
        }
        [TestMethod]
        public void GetPatientsByName_WithExistsPatientName_ReturnExactly2()
        {
            var patientName = "bn3";

            var actual = _sut.GetPatientsByName(patientName);

            actual.Should().BeEquivalentTo(_stubPatientList[2]);
        }
        [TestMethod]
        public void GetPatientsByName_WithExistsPatientName_ReturnListPatientHaveSameName()
        {
            var patientName = "bn1";

            var actual = _sut.GetPatientsByName(patientName);

            actual.Should().Contain(_stubPatientList[0])
                .And.Contain(_stubPatientList[3]);
        }

        [TestMethod]
        public void GetPatientsByName_WithNoneExistsPatientName_ReturnsEmpty()
        {
            var patientName = "None Exist";

            var actual = _sut.GetPatientsByName(patientName);

            actual.Should().BeEmpty();
        }

        [TestMethod]
        public void GetPatientsByPhone_WithExistsPhoneNumber_ReturnExactly()
        {
            var phoneNumber = "0123456789";

            var actual = _sut.GetPatientsByPhone(phoneNumber);

            actual.Should().BeEquivalentTo(_stubPatientList[0]);
        }

        [TestMethod]
        public void GetPatientsByPhone_WithExistsPhoneNumber_ReturnExactly2()
        {
            var phoneNumber = "0123656789";

            var actual = _sut.GetPatientsByPhone(phoneNumber);

            actual.Should().BeEquivalentTo(_stubPatientList[2]);
        }

        [TestMethod]
        public void GetPatientsByPhone_WithNoneExistsPhoneNumber_ReturnsEmpty()
        {
            var noneExistsPhoneNumber = "09782345223";

            var actual = _sut.GetPatientsByPhone(noneExistsPhoneNumber);

            actual.Should().BeEmpty();
        }

        [TestMethod]
        public void InsertPatient_WithExistsPhoneNumber_ThrowsException()
        {
            var existsPhoneNumber = "0123456789";

            var patient = new patient()
            {
                id = 5,
                patient_name = "bn5",
                age = 15,
                gender = "nam",
                phone_number = existsPhoneNumber
            };

            Action act = () => _sut.InsertPatient(patient);

            act.Should().Throw<ArgumentException>();
        }
    }
}
