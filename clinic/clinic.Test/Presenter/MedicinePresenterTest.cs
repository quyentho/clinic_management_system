using clinic.Models;
using clinic.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using clinic.Presenters;
using FluentAssertions;

namespace clinic.Test.Presenter
{
    [TestClass]
    public class MedicinePresenterTest
    {
        private Mock<IMedicineRepository> _mockMedicineRepo;
        private Mock<IMedicineView> _mockMedicineView;
        private medicine _stubMedicine;
        private MedicinePresenter _sut;
        [TestInitialize]
        public void Test_Initialize()
        {
            _mockMedicineRepo = new Mock<IMedicineRepository>();
            _mockMedicineView = new Mock<IMedicineView>();
            _mockMedicineView.SetupAllProperties();
            _mockMedicineView.Object.TxtMedicineName = "thuoc 1";
            _mockMedicineView.Object.TxtEntryPrice = "200000";
            _mockMedicineView.Object.TxtEntryQuantity = "20";
            _mockMedicineView.Object.TxtEntryUnit = "Hop";
            _mockMedicineView.Object.TxtExchangeRatio = "50";
            _mockMedicineView.Object.TxtExpiryDay = "5/12/2021";
            _mockMedicineView.Object.TxtSalePrice = "2000";
            _mockMedicineView.Object.TxtSaleUnit = "Vien";


            var timeMock = new Mock<TimeProvider>();
            timeMock.SetupGet(tp => tp.UtcNow).Returns(new DateTime(2020, 5, 24));
            TimeProvider.Current = timeMock.Object;

            _stubMedicine = new medicine()
            {
                medicine_name = "thuoc 1",
                entry_day = timeMock.Object.UtcNow,
                entry_price = 200000,
                entry_unit = "Hop",
                expiry_day = new DateTime(2021, 12, 5),
                is_active = true,
                quantity_in_entry_unit = 20,
                quantity_in_sale_unit = 20 * 50,
                sale_price_per_unit = 2000,
                sale_unit = "Vien",
                unit_exchange_ratio = 50
            };

            _sut = new MedicinePresenter(_mockMedicineRepo.Object,_mockMedicineView.Object);
        }
        [TestCleanup]
        public void Test_CleanUp()
        {
            TimeProvider.ResetToDefault();
        }

        [TestMethod]
        public void Add_WithValidInput_AddSuccessfully()
        {
            medicine medicineInserted = null;
            _mockMedicineRepo.Setup(m => m.InsertMedicine(It.IsAny<medicine>())).Callback<medicine>(medicine =>
                  medicineInserted = medicine
            );
            _sut.Add();

            _mockMedicineRepo.Verify(m => m.InsertMedicine(medicineInserted));

            medicineInserted.Should().BeEquivalentTo(_stubMedicine);
        }

    }
}
