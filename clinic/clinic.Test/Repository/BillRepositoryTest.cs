using clinic.Models;
using clinic.Models.Repositories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic.Test.Repository
{
    [TestClass]
    public class BillRepositoryTest
    {
        private List<bill> _stubBillList;
        private Mock<DbSet<bill>> _stubDbSet;
        private Mock<clinicEntities> _stubDbContext;
        private BillRepository _sut;
        private Mock<TimeProvider> _timeMock;

        [TestInitialize]
        public void Test_Initialize()
        {
            MockDateTime();
            var stubPatientList = new List<patient>()
            {
                new patient(){ id=1, patient_name = "bn1", age= 10, gender = "nam", phone_number = "0123456789"},
                new patient(){ id=2, patient_name = "bn2", age= 40, gender = "nu", phone_number = "0123452789"},
                new patient(){ id=3, patient_name = "bn3", age= 35, gender = "nam", phone_number = "0123656789"},
                new patient(){ id=4, patient_name = "bn1", age= 10, gender = "nam", phone_number = "0223456789"}
            };

            _stubBillList = new List<bill>()
            {
                new bill(){ id = 1 , is_paid = false, patient_id = 1, staff_created = 1
                , created_at= _timeMock.Object.UtcNow, total_money =100000, patient = stubPatientList[0]},
                 new bill(){ id = 2 , is_paid = false, patient_id = 2, staff_created = 1
                , created_at= _timeMock.Object.UtcNow, total_money =250000,patient = stubPatientList[1]},
                  new bill(){ id = 3 , is_paid = false, patient_id = 3, staff_created = 1
                , created_at= _timeMock.Object.UtcNow, total_money =500000, patient = stubPatientList[2]},
                   new bill(){ id = 4 , is_paid = true, patient_id = 1, staff_created = 1
                , created_at= _timeMock.Object.UtcNow, total_money =300000, patient = stubPatientList[3]},
            };
       
            _stubDbSet = new Mock<DbSet<bill>>();
            _stubDbSet.As<IQueryable>().Setup(b => b.ElementType).Returns(_stubBillList.AsQueryable().ElementType);
            _stubDbSet.As<IQueryable>().Setup(b => b.Expression).Returns(_stubBillList.AsQueryable().Expression);
            _stubDbSet.As<IQueryable>().Setup(b => b.Provider).Returns(_stubBillList.AsQueryable().Provider);
            _stubDbSet.As<IQueryable>().Setup(b => b.GetEnumerator()).Returns(_stubBillList.AsQueryable().GetEnumerator());

            _stubDbContext = new Mock<clinicEntities>();
            _stubDbContext.Setup(c => c.bills).Returns(_stubDbSet.Object);

            SetupDbSetForUsingFindMethod();

            // The following line bypasses the Include call.
            _stubDbSet.Setup(m => m.Include(It.IsAny<String>())).Returns(_stubDbSet.Object);


            _sut = new BillRepository(_stubDbContext.Object);
        }

        private void MockDateTime()
        {
            _timeMock = new Mock<TimeProvider>();
            _timeMock.SetupGet(tp => tp.UtcNow).Returns(new DateTime(2020, 5, 27));
            TimeProvider.Current = _timeMock.Object;
        }

        [TestCleanup]
        public void Test_CleanUp()
        {
            TimeProvider.ResetToDefault();
        }
        [TestMethod]
        public void GetListUnpaidBill_WhenCalled_ReturnsListUnpaidBill()
        {
            var actual = _sut.GetListUnpaidBill();

            actual.Should().BeEquivalentTo(_stubBillList.GetRange(0,3));
        }
        [TestMethod]
        public void GetListPaidBill_WhenCalled_ReturnsListPaidBill()
        {
            var actual = _sut.GetListPaidBill();

            actual.Should().BeEquivalentTo(_stubBillList[3]);
        }
        [TestMethod]
        public void CreateBill_WithValidBill_AddNewBillToListUnpaid()
        {
            var newBill = new bill()
            {
               
                created_at = _timeMock.Object.UtcNow,
                is_paid = false,
                patient_id = 1,
                staff_created = 2,
                total_money = 0
            };

            _sut.CreateBill(newBill);

            _sut.GetListUnpaidBill().Should().Contain(newBill);
        }
        [TestMethod]
        public void CreateBill_WithValidBill_AddNewBillToDatabase()
        {
            var newBill = new bill()
            {

                created_at = _timeMock.Object.UtcNow,
                is_paid = false,
                patient_id = 1,
                staff_created = 2,
                total_money = 0
            };
            _stubDbSet.Setup(s => s.Add(It.IsAny<bill>())).Callback<bill>(bill => newBill = bill);
            _sut.CreateBill(newBill);


            _stubDbContext.Verify(c => c.bills.Add(newBill));
            _stubDbContext.Verify(c => c.SaveChanges());
        }

        [TestMethod]
        public void PayBill_ValidBillId_UpdateBillStateInDatabaseSuccessfully()
        {
            int id = 1;
            var billUpdated = new bill();
            _stubDbContext.Setup(c => c.AddOrUpdateEntity<bill>(_stubDbContext.Object, It.IsAny<bill>()))
                .Callback<clinicEntities, bill>((c, b) => billUpdated = b);

            _sut.PayBill(id);

            _stubDbContext.Verify(c => c.AddOrUpdateEntity<bill>(_stubDbContext.Object,billUpdated));
            _stubDbContext.Verify(c => c.SaveChanges());
            billUpdated.Should().BeOfType<bill>().Which.is_paid.Should().BeTrue();
        }
        [TestMethod]
        public void PayBill_NoneExistsBillId_ThrowArgumentOutOfRangeException()
        {
            int noneExistsId = -1;
            

            Action act = () => _sut.PayBill(noneExistsId);

            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Hoa Don Khong Ton Tai\r\nParameter Name: id");

        }
        [TestMethod]
        public void PayBill_ValidBillId_RemoveFromUnpaidList()
        {
            int id = 1;

            _sut.PayBill(id);

            _sut.GetListUnpaidBill().Should().NotContain(_stubBillList[0]);
        }
        [TestMethod]
        public void PayBill_ValidBillId_AddBillToPaidList()
        {
            int id = 1;

            _sut.PayBill(id);

            _sut.GetListPaidBill().Should().Contain(_stubBillList[0]);
        }
        [TestMethod]
        public void CalculateRevenueByMonth_ExistsBillInThatMonth_ReturnsRevenueByMonth()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTest = new DateTime(2020, 5, 27);

            Int64 result = _sut.CalculateRevenueByMonth(dateTest);

            result.Should().Be(800000);
        }
        [TestMethod]
        public void CalculateRevenueByMonth_ExistsBillInThatMonth_ReturnsRevenueByMonth2()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTest = new DateTime(2020, 4, 30);

            Int64 result = _sut.CalculateRevenueByMonth(dateTest);

            result.Should().Be(900000);
        }
        [TestMethod]
        public void CalculateRevenueByMonth_NotExistsBillInThatMonth_ReturnsZero()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTest = new DateTime(2020, 12, 27);

            Int64 result = _sut.CalculateRevenueByMonth(dateTest);

            result.Should().Be(0);
        }
        [TestMethod]
        public void CalculateRevenueByDate_ExistsBillInThatDay_ReturnsRevenueByDay()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTest = new DateTime(2020, 5, 27);

            Int64 result = _sut.CalculateRevenueByDate(dateTest);

            result.Should().Be(600000);
        }
        [TestMethod]
        public void CalculateRevenueByDate_ExistsBillInThatDay_ReturnsRevenueByDay2()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTest = new DateTime(2020, 4, 30);

            Int64 result = _sut.CalculateRevenueByDate(dateTest);

            result.Should().Be(900000);
        }
        [TestMethod]
        public void CalculateRevenueByDate_NotExistsBillInThatDay_ReturnsZero()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTest = new DateTime(2020, 4, 1);

            Int64 result = _sut.CalculateRevenueByDate(dateTest);

            result.Should().Be(0);
        }
        [TestMethod]
        public void GetRevenueByDate_ValidDateTime_ReturnDatePropertyInCorrectFormatForDate()
        {
            DateTime dateTest = new DateTime(2020, 4, 1);

            RevenueViewModel dateTimeVM = _sut.GetRevenueByDate(dateTest);

            dateTimeVM.Date.Should().Be("01/04/2020");
        }
        [TestMethod]
        public void GetRevenueByMonth_ValidDateTime_ReturnDatePropertyInCorrectFormatForMonth()
        {
            DateTime dateTest = new DateTime(2020, 4, 1);

            RevenueViewModel dateTimeVM = _sut.GetRevenueByMonth(dateTest);

            dateTimeVM.Date.Should().Be("04/2020");
        }
        [TestMethod]
        public void GetRevenueByYear_ValidDateTime_ReturnDatePropertyInCorrectFormatForYear()
        {
            DateTime dateTest = new DateTime(2020, 4, 1);

            RevenueViewModel dateTimeVM = _sut.GetRevenueByYear(dateTest);

            dateTimeVM.Date.Should().Be("2020");
        }
        [TestMethod]
        public void CalculateRevenueByYear_ExistsBillInThatYear_ReturnsRevenueByYear()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTime = new DateTime(2019,1,1);

            Int64 result = _sut.CalculateRevenueByYear(dateTime);

            result.Should().Be(150000);
        }
        [TestMethod]
        public void CalculateRevenueByYear_ExistsBillInThatYear_ReturnsRevenueByYear2()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTime = new DateTime(2020, 1, 1);

            Int64 result = _sut.CalculateRevenueByYear(dateTime);

            result.Should().Be(1_700_000);
        }
        [TestMethod]
        public void CalculateRevenueByYear_NotExistsBillInThatDay_ReturnsZero()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTime = new DateTime(2030, 1, 1);

            Int64 result = _sut.CalculateRevenueByYear(dateTime);

            result.Should().Be(0);
        }
        [TestMethod]
        public void GetListPaidBillByYear_ExistsBillInThatYear_ReturnsListBillByYear()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTime = new DateTime(2020, 1, 1);

            List<bill> actual = _sut.GetListPaidBillByYear(dateTime);

            actual.Should().BeEquivalentTo(_stubBillList.GetRange(0, 4));
        }
        [TestMethod]
        public void GetListPaidBillByYear_ExistsBillInThatYear_ReturnsListBillByYear2()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTime = new DateTime(2019, 1, 1);

            List<bill> actual = _sut.GetListPaidBillByYear(dateTime);

            actual.Should().BeEquivalentTo(_stubBillList[4]);
        }
        [TestMethod]
        public void GetListPaidBillByYear_NotExistsBillInThatYear_ReturnsEmpty()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTime = new DateTime(2030, 1, 1);

            List<bill> actual = _sut.GetListPaidBillByMonth(dateTime);

            actual.Should().BeEmpty();
        }
        [TestMethod]
        public void GetListPaidBillByMonth_ExistsBillInThatMonth_ReturnsRevenueByMonth()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTime = new DateTime(2020, 5, 1);

            List<bill> actual = _sut.GetListPaidBillByMonth(dateTime);

            actual.Should().BeEquivalentTo(_stubBillList.GetRange(0, 2));
        }
        [TestMethod]
        public void GetListPaidBillByMonth_ExistsBillInThatMonth_ReturnsRevenueByMonth2()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTime = new DateTime(2019, 4, 1);

            List<bill> actual = _sut.GetListPaidBillByMonth(dateTime);

            actual.Should().BeEquivalentTo(_stubBillList[4]);
        }
        [TestMethod]
        public void GetListPaidBillByMonth_NotExistsBillInThatMonth_ReturnsEmpty()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTime = new DateTime(2020, 12, 1);

            List<bill> actual = _sut.GetListPaidBillByMonth(dateTime);

            actual.Should().BeEmpty();
        }
        [TestMethod]
        public void GetListPaidBillByDate_ExistsBillInThatDate_ReturnsRevenueByDate()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTime = new DateTime(2019, 4, 1);

            List<bill> actual = _sut.GetListPaidBillByDate(dateTime);
            actual.Should().BeEquivalentTo(_stubBillList[4]);
        }
        [TestMethod]
        public void GetListPaidBillByDate_ExistsBillInThatDate_ReturnsRevenueByDate2()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTime = new DateTime(2020, 4, 30);

            List<bill> actual = _sut.GetListPaidBillByDate(dateTime);
            actual.Should().BeEquivalentTo(_stubBillList.GetRange(2,2));
        }
        [TestMethod]
        public void GetListPaidBillByDate_NotExistsBillInThatDate_ReturnsEmpty()
        {
            SetupListForTestRevenueInDifferenceDate();
            DateTime dateTime = new DateTime(2020, 4, 1);

            List<bill> actual = _sut.GetListPaidBillByDate(dateTime);

            actual.Should().BeEmpty();
        }
        [TestMethod]
        public void AddServiceToBill_NoneExistsBillId_ThrowsArgumentOutOfRangeException()
        {
            clinic_service validService = new clinic_service();

            int NoneExistsBillId = -1;

           Action act = () => _sut.AddServiceToBill(NoneExistsBillId, validService);

            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Bill Khong Ton Tai\nParameter name: billId");
                
        }
        [TestMethod]
        public void AddServiceToBill_ExistsBillIdAndValidService_NotThrowsException()
        {
            clinic_service validService =
                new clinic_service() { id = 1, service_name = "Thu mau", price = 50000, is_active = true };
            _stubDbContext.Setup(c => c.clinic_service.Attach(validService));

            int NoneExistsBillId = 1;

            Action act = () => _sut.AddServiceToBill(NoneExistsBillId, validService);

            act.Should().NotThrow();
        }
        
        //[TestMethod]
        //public void AddServiceToBill_ExistsBillIdAndValidService_AddToUnpaidListSuccessfully()
        //{
        //    clinic_service validService =
        //      new clinic_service() { id = 1, service_name = "Thu mau", price = 50000, is_active = true };
        //    _stubDbContext.Setup(c => c.clinic_service.Attach(validService));

        //    int existsBillId = 1;


        //    _sut.AddServiceToBill(existsBillId, validService);

        //    _sut.GetListUnpaidBill()[0].clinic_service.Should().Contain(validService);
        //}
        [TestMethod]
        public void AddPrescriptionToBill_NoneExistsBillId_ThrowArgumentOutOfRangeException()
        {
            prescription validPrescription = new prescription();

            int NoneExistsBillId = -1;

            Action act = () => _sut.AddPrescriptionToBill(NoneExistsBillId, validPrescription);

            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Bill Khong Ton Tai\nParameter name: billId");
        }
        [TestMethod]
        public void AddPrescriptionToBill_ExistsBillIdAndValidService_AddToUnpaidListSuccessfully()
        {
            int existsBillId = 1;
            var validPrescription = new prescription()
            {
                bill_id = existsBillId,
                date_created = _timeMock.Object.UtcNow,
                description = "Ngay 3 lan",
                medicine_id = 1,
                quantity_indicated = 10,
                staff_id = 1
            };

            _sut.AddPrescriptionToBill(existsBillId, validPrescription);

            _sut.GetListUnpaidBill()[0].prescriptions.Should().Contain(validPrescription);
        }
        [TestMethod]
        public void AddPrescriptionToBill_ExistsBillIdAndValidPrescription_NotThrowsException()
        {
            clinic_service validPrescription =
                new clinic_service() { id = 1, service_name = "Thu mau", price = 50000, is_active = true };

            _stubDbContext.Setup(c => c.clinic_service.Attach(It.IsAny<clinic_service>()));
            int NoneExistsBillId = 1;

            Action act = () => _sut.AddServiceToBill(NoneExistsBillId, validPrescription);

            act.Should().NotThrow();
        }
        [TestMethod]
        public void CalculateToTalMoney_ExistsUnpaidBill_ReturnsTotalMoney()
        {
            SetupListMedicineAndServiceForBill1();

            _sut.CalculateTotalMoneyInBill(1);

            _stubBillList[0].total_money.Should().Be(175_000);
        }
        [TestMethod]
        public void GetUnpaidBillByPatientId_NoneExistsPatientId_ReturnsNull()
        {
            int patientId = -1;

            bill actual = _sut.GetUnpaidBillByPatientId(patientId);

            actual.Should().BeNull();
        }
        [TestMethod]
        public void GetUnpaidBillByPatientId_ExistingPatientId_ReturnsBillExactly()
        {
            int patientId = 2;

            var actual = _sut.GetUnpaidBillByPatientId(patientId);

            actual.Should().BeEquivalentTo(_stubBillList[1]);
        }
        [TestMethod]
        public void GetUnpaidBillByPhoneNumber_ExistingPhoneNumber_ReturnsUnpaidBill()
        {
            string ExistingPhoneNumber = "0123456789";

            var actual = _sut.GetUnpaidBillByPhoneNumber(ExistingPhoneNumber);

            actual.Should().BeEquivalentTo(_stubBillList[0]);
        }
        [TestMethod]
        public void GetBillByPhoneNumber_NoneExistsPhoneNumber_ReturnsNull()
        {
            string NoneExistsPhoneNumber = "00000000000";

            var actual = _sut.GetUnpaidBillByPhoneNumber(NoneExistsPhoneNumber);

            actual.Should().BeNull();
        }
        [TestMethod]
        public void GetBillsByPatientName_NoneExistsPatientName_ReturnsEmpty()
        {
            string noneExistsPatientName = "none";

            var actual = _sut.GetUnpaidBillsByPatientName(noneExistsPatientName);

            actual.Should().BeEmpty();
        }
        [TestMethod]
        public void GetBillsByPatientName_ExistingPatientName_ReturnsBillExactly()
        {
            string existingPatientName = "bn3";

            var actual = _sut.GetUnpaidBillsByPatientName(existingPatientName);

            actual.Should().BeEquivalentTo(_stubBillList[2]);
        }
        private void SetupListMedicineAndServiceForBill1()
        {
            var listService = new List<clinic_service>()
            {
               new clinic_service(){ id = 1, service_name = "Thu mau", price = 50000, is_active = true},
               new clinic_service(){ id = 2, service_name = "Kham Benh", price = 40000, is_active = true},
               new clinic_service(){ id = 3, service_name = "Sieu am", price = 70000, is_active = true}
            };

            string[] dateTimeFormats = {"d/M/yyyy","dd/M/yyyy","d/MM/yyyy","dd/MM/yyyy", "d-M-yyyy", "dd-M-yyyy"
                                            , "d-MM-yyyy","dd-MM-yyyy" };

            var listMedicine = new List<medicine>()
            {
                new medicine{ id = 1, medicine_name="thuoc 1", entry_unit = "Hop",
                    entry_price = 20000, expiry_day = DateTime.ParseExact("20-10-2020",dateTimeFormats,CultureInfo.InvariantCulture,DateTimeStyles.None),
                    quantity_in_entry_unit = 100, unit_exchange_ratio = 100, quantity_in_sale_unit = 100*100,
                    entry_day = DateTime.Now, sale_unit = "Vien", sale_price_per_unit = 1000, is_active = true},

                new medicine{ id = 2, medicine_name="thuoc 2", entry_unit = "Hop",
                    entry_price = 50000, expiry_day = DateTime.ParseExact("20-10-2020",dateTimeFormats,CultureInfo.InvariantCulture,DateTimeStyles.None),
                    quantity_in_entry_unit = 200, unit_exchange_ratio = 100, quantity_in_sale_unit = 200*100,
                    entry_day = DateTime.Now, sale_unit = "Vien", sale_price_per_unit = 500, is_active = true},
            };
            var listPrescription = new List<prescription>()
            {
                new prescription(){ bill_id = 1, bill = _stubBillList[0], date_created=_timeMock.Object.UtcNow
                ,description = "ngay 3 lan", medicine = listMedicine[0], medicine_id = 1, quantity_indicated = 10
                , staff_id = 1},
                 new prescription(){ bill_id = 1, bill = _stubBillList[0], date_created=_timeMock.Object.UtcNow
                ,description = "ngay 3 lan", medicine = listMedicine[1], medicine_id = 2, quantity_indicated = 10
                , staff_id = 1}
            };

            _stubBillList[0].clinic_service = listService;
            _stubBillList[0].prescriptions = listPrescription;
        }
        private void SetupDbSetForUsingFindMethod()
        {
            _stubDbContext.Setup(c => c.bills.Find(It.IsAny<object[]>()))
                .Returns<object[]>(ids => _stubBillList.FirstOrDefault(s => s.id == (int)ids[0]));
        }

        private void SetupListForTestRevenueInDifferenceDate()
        {
            _timeMock.SetupGet(tp => tp.UtcNow).Returns(new DateTime(2020, 5, 27));
            var bill1 = new bill()
            {
                id = 5,
                is_paid = true,
                patient_id = 1,
                staff_created = 1,
                created_at = _timeMock.Object.UtcNow,
                total_money = 600000
            };

            _timeMock.SetupGet(tp => tp.UtcNow).Returns(new DateTime(2020, 5, 28));
            var bill2 = new bill()
            {
                id = 6,
                is_paid = true,
                patient_id = 1,
                staff_created = 1,
                created_at = _timeMock.Object.UtcNow,
                total_money = 200000
            };

            _timeMock.SetupGet(tp => tp.UtcNow).Returns(new DateTime(2020, 4, 30));
            var bill3 = new bill()
            {
                id = 7,
                is_paid = true,
                patient_id = 1,
                staff_created = 1,
                created_at = _timeMock.Object.UtcNow,
                total_money = 800000
            };
            var bill4 = new bill()
            {
                id = 8,
                is_paid = true,
                patient_id = 1,
                staff_created = 1,
                created_at = _timeMock.Object.UtcNow,
                total_money = 100000
            };
            _timeMock.SetupGet(tp => tp.UtcNow).Returns(new DateTime(2019, 4, 1));
            var bill5 = new bill()
            {
                id = 9,
                is_paid = true,
                patient_id = 1,
                staff_created = 1,
                created_at = _timeMock.Object.UtcNow,
                total_money = 150000
            };
            _stubBillList = new List<bill>();
            _stubBillList.Add(bill1);
            _stubBillList.Add(bill2);
            _stubBillList.Add(bill3);
            _stubBillList.Add(bill4);
            _stubBillList.Add(bill5);

            _stubDbSet.As<IQueryable>().Setup(b => b.ElementType).Returns(_stubBillList.AsQueryable().ElementType);
            _stubDbSet.As<IQueryable>().Setup(b => b.Expression).Returns(_stubBillList.AsQueryable().Expression);
            _stubDbSet.As<IQueryable>().Setup(b => b.Provider).Returns(_stubBillList.AsQueryable().Provider);
            _stubDbSet.As<IQueryable>().Setup(b => b.GetEnumerator()).Returns(_stubBillList.AsQueryable().GetEnumerator());

            _stubDbContext = new Mock<clinicEntities>();
            _stubDbContext.Setup(c => c.bills).Returns(_stubDbSet.Object);

            _sut = new BillRepository(_stubDbContext.Object);
        }
            
    }
}
