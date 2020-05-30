using System;
using System.Collections.Generic;
using clinic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Moq;
using System.Linq;
using clinic.Models.Repositories;
using System.Globalization;
using System.Linq.Expressions;
using FluentAssertions;

namespace clinic.Test.Repository
{
   
    [TestClass]
    public class MedicineRepositoryTest
    {
        private readonly Mock<clinicEntities> _stubContext;
        private IQueryable<medicine> _fakeMedicineList;
        private readonly MedicineRepository _sut;
        public MedicineRepositoryTest()
        {
            string[] dateTimeFormats = {"d/M/yyyy","dd/M/yyyy","d/MM/yyyy","dd/MM/yyyy", "d-M-yyyy", "dd-M-yyyy"
                                            , "d-MM-yyyy","dd-MM-yyyy" };
            _fakeMedicineList = new List<medicine>{
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
            }.AsQueryable();

            var stubDbSet = new Mock<DbSet<medicine>>();
            stubDbSet.As<IQueryable<medicine>>().Setup(m => m.Provider).Returns(_fakeMedicineList.Provider);
            stubDbSet.As<IQueryable<medicine>>().Setup(m => m.Expression).Returns(_fakeMedicineList.Expression);
            stubDbSet.As<IQueryable<medicine>>().Setup(m => m.ElementType).Returns(_fakeMedicineList.ElementType);
            stubDbSet.As<IQueryable<medicine>>().Setup(m => m.GetEnumerator())
                .Returns(() => _fakeMedicineList.GetEnumerator());

            stubDbSet.Setup(m => m.Find(It.IsAny<object[]>()))
                .Returns<object[]>(ids => _fakeMedicineList.FirstOrDefault(d => d.id == (int)ids[0]));

            _stubContext = new Mock<clinicEntities>();
            _stubContext.Setup(c => c.medicines).Returns(stubDbSet.Object);
            _stubContext.Setup(c => c.Set<medicine>()).Returns(stubDbSet.Object);
            _sut = new MedicineRepository(_stubContext.Object);
        }

        [TestMethod]
        public void GetMedicinesFromDatabase_WhenCalled_ReturnsMedicineList()
        {
            var actual = _sut.GetMedicineList();

            CollectionAssert.AreEqual(_fakeMedicineList.ToList(), actual);
        }

        [TestMethod]
        public void InsertMedicine_WhenCalled_AddToMedicineListAndDatabase()
        {
            var newMedicine = new medicine()
            {
                
                medicine_name = "thuoc test",
                entry_unit = "Hop",
                entry_price = 20000,
                expiry_day = DateTime.ParseExact("20-10-2020", "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None),
                quantity_in_entry_unit = 100,
                unit_exchange_ratio = 100,
                quantity_in_sale_unit = 100 * 100,
                entry_day = DateTime.Now,
                sale_unit = "Vien",
                sale_price_per_unit = 1000,
                is_active = true
            };
         
            _sut.InsertMedicine(newMedicine);
           
            Assert.IsTrue(_sut.GetMedicineList().Contains(newMedicine));
            _stubContext.Verify(c => c.medicines.Add(newMedicine), Times.Once);
            _stubContext.Verify(c => c.SaveChanges(), Times.Once);
        }
        [TestMethod]
        public void GetMedicineById_IfExist_ReturnsMedicine()
        {
            int id = 1;

            var actual = _sut.GetMedicineById(id);
            var expected = _fakeMedicineList.ToList()[0];

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetMedicineByIdInDatabase_IfExist_ReturnsMedicine()
        {
            int id = 2;

            var actual = _stubContext.Object.medicines.Find(id);
            var expected = _fakeMedicineList.ToList()[1];

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateMedicine_WithValidMedicine_UpdateMedicineInList()
        {
            var medicineUpdated = new medicine()
            {
                id = 1,
                medicine_name = "thuoc test 123",
                entry_unit = "Hop",
                entry_price = 10000,
                expiry_day = DateTime.ParseExact("20-10-2020", "dd-MM-yyyy",
                                                  CultureInfo.InvariantCulture, DateTimeStyles.None),
                quantity_in_entry_unit = 100,
                unit_exchange_ratio = 100,
                quantity_in_sale_unit = 100 * 100,
                entry_day = DateTime.Now,
                sale_unit = "Vien",
                sale_price_per_unit = 1000,
                is_active = true
            };
            _sut.UpdateMedicine(medicineUpdated);

           _sut.GetMedicineList().Should().Contain(medicineUpdated);
           
        }
        [TestMethod]
        public void UpdateMedicine_WithValidMedicine_NotThrowsException()
        {

            var medicineUpdated = new medicine()
            {
                id = 1,
                medicine_name = "thuoc test 123",
                entry_unit = "Hop",
                entry_price = 10000,
                expiry_day = DateTime.ParseExact("20-10-2020", "dd-MM-yyyy",
                                                  CultureInfo.InvariantCulture, DateTimeStyles.None),
                quantity_in_entry_unit = 100,
                unit_exchange_ratio = 100,
                quantity_in_sale_unit = 100 * 100,
                entry_day = DateTime.Now,
                sale_unit = "Vien",
                sale_price_per_unit = 1000,
                is_active = true
            };

            Action act = () =>  _sut.UpdateMedicine(medicineUpdated);

            act.Should().NotThrow();
        }
        
        [TestMethod]
        public void DeleteMedicine_WithValidId_DeleteMedicineInList()
        {
            int id = 1;

            _sut.DeleteMedicine(id);

            Assert.IsTrue(!_sut.GetMedicineList().Contains(_fakeMedicineList.ToList()[0]));
        }
        [TestMethod]
        public void DeleteMedicine_WithValidId_DeleteMedicineInDatabaseSuccessfully()
        {
            int id = 1;

            _sut.DeleteMedicine(id);

            _stubContext.Verify(c => c.medicines.Remove(_fakeMedicineList.ToList()[0]));
            _stubContext.Verify(c => c.SaveChanges());
        }

        [TestMethod]
        public void GetMedicinesByName_SameMedicineName_ReturnsListMedicine()
        {
            List<medicine> actual = _sut.GetMedicinesByName("thuoc");

            actual.Should().BeEquivalentTo(_fakeMedicineList);
        }
        [TestMethod]
        public void GetMedicinesByName_CognomenName_ReturnsExactMedicine()
        {
            var actual = _sut.GetMedicinesByName("thuoc 2");

            actual.Should().BeEquivalentTo(_fakeMedicineList.ToList()[1]);
        }
        [TestMethod]
        public void GetMedicinesByName_NotExistName_ReturnsEmpty()
        {
            var actual = _sut.GetMedicinesByName("none exist name");

            actual.Should().BeEmpty();
        }
    }
}
