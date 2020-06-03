using clinic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using clinic.Models.Repositories;
using FluentAssertions;

namespace clinic.Test.Repository
{
    [TestClass]
    public class PrescriptionRepositoryTest
    {
        private List<prescription> _stubPrescriptionList;
        private Mock<DbSet<prescription>> _stubDbSet;
        private Mock<clinicEntities> _stubDbContext;
        private Mock<TimeProvider> _timeMock;
        private PrescriptionRepository _sut;

        [TestInitialize]
        public void Test_Initialize()
        {
            MockDateTime();
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
                 new medicine{ id = 3, medicine_name="thuoc 3", entry_unit = "Hop",
                    entry_price = 50000, expiry_day = DateTime.ParseExact("20-11-2021",dateTimeFormats,CultureInfo.InvariantCulture,DateTimeStyles.None),
                    quantity_in_entry_unit = 100, unit_exchange_ratio = 50, quantity_in_sale_unit = 50*100,
                    entry_day = DateTime.Now, sale_unit = "Vien", sale_price_per_unit = 500, is_active = true}
            };
            _stubPrescriptionList = new List<prescription>()
            {
                 new prescription(){ bill_id = 1, date_created=_timeMock.Object.UtcNow
                ,description = "ngay 3 lan", medicine = listMedicine[0], medicine_id = 1, quantity_indicated = 10
                , staff_id = 1},
                 new prescription(){ bill_id = 1, date_created=_timeMock.Object.UtcNow
                ,description = "ngay 3 lan", medicine = listMedicine[1], medicine_id = 2, quantity_indicated = 10
                , staff_id = 1}
            };
            _stubDbSet = new Mock<DbSet<prescription>>();
            _stubDbSet.As<IQueryable>().Setup(p => p.ElementType).Returns(_stubPrescriptionList.AsQueryable().ElementType);
            _stubDbSet.As<IQueryable>().Setup(p => p.Expression).Returns(_stubPrescriptionList.AsQueryable().Expression);
            _stubDbSet.As<IQueryable>().Setup(p => p.Provider).Returns(_stubPrescriptionList.AsQueryable().Provider);
            _stubDbSet.As<IQueryable>().Setup(p => p.GetEnumerator()).Returns(_stubPrescriptionList.AsQueryable().GetEnumerator());

            _stubDbContext = new Mock<clinicEntities>();
            _stubDbContext.Setup(c => c.prescriptions).Returns(_stubDbSet.Object);

            var stubMedicineRepository = new Mock<IMedicineRepository>();
            _sut = new PrescriptionRepository(_stubDbContext.Object, stubMedicineRepository.Object);
        }
        //[TestMethod]
        //public void CheckMedicineQuantity_EnoughForIndicated_ReturnsQuantityIndicated()
        //{
        //    int quantityIndicated = 10;

        //    int result = _sut.CheckMedicineQuantity(quantityIndicated);

        //    result.Should().Be(10);
        //}
        private void MockDateTime()
        {
            _timeMock = new Mock<TimeProvider>();
            _timeMock.SetupGet(tp => tp.UtcNow).Returns(new DateTime(2020, 5, 27));
            TimeProvider.Current = _timeMock.Object;
        }
    }
}
