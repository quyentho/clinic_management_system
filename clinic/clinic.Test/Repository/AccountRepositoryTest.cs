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
    public class AccountRepositoryTest
    {
        private Mock<DbSet<account>> _fakeAcountDbSet;
        private List<account> _stubAccountList;
        private Mock<clinicEntities> _stubDbContext;
        private AccountRepository _sut;

        [TestInitialize]
        public void Test_Initialize()
        {

            _fakeAcountDbSet = new Mock<DbSet<account>>();
            _stubAccountList = new List<account>()
            {
                  new account()
                    {
                       id=1,
                    is_active = true,
                    pass = "1",
                    permission_id = 1,
                    staff_id = 1,
                    username = "0945664870"
                },
                  new account()
                    {
                      id=2,
                    is_active = true,
                    pass = "1",
                    permission_id = 2,
                    staff_id = 2,
                    username = "0845664870"
                },
                new account()
                    {
                    id=3,
                    is_active = true,
                    pass = "1",
                    permission_id = 3,
                    staff_id = 3,
                    username = "0745664870"
                },
                  new account()
                    {
                    id=4,
                    is_active = false,
                    pass = "1",
                    permission_id = 3,
                    staff_id = 3,
                    username = "0245664870"
                }
            };


            _fakeAcountDbSet.As<IQueryable<account>>().Setup(a => a.ElementType)
                .Returns(_stubAccountList.AsQueryable().ElementType);
            _fakeAcountDbSet.As<IQueryable<account>>().Setup(a => a.Expression)
                .Returns(_stubAccountList.AsQueryable().Expression);
            _fakeAcountDbSet.As<IQueryable<account>>().Setup(a => a.Provider)
                .Returns(_stubAccountList.AsQueryable().Provider);
            _fakeAcountDbSet.As<IQueryable<account>>().Setup(a => a.GetEnumerator())
                .Returns(_stubAccountList.AsQueryable().GetEnumerator());

            _fakeAcountDbSet.Setup(s => s.Find(It.IsAny<object[]>()))
                .Returns<object[]>(ids => _stubAccountList.FirstOrDefault(s => s.id == (int)ids[0]));

            _stubDbContext = new Mock<clinicEntities>();
            _stubDbContext.Setup(c => c.accounts).Returns(_fakeAcountDbSet.Object);
            _stubDbContext.Setup(c => c.Set<account>()).Returns(_fakeAcountDbSet.Object);

            _sut = new AccountRepository(_stubDbContext.Object);
        }
        [TestMethod]
        public void GetAccount_ValidUserNameAndPassword_ReturnsAccount()
        {
            string validUserName = "0745664870";
            string validPassword = "1";

            var actual = _sut.GetAccount(validUserName, validPassword);

            actual.Should().BeEquivalentTo(_stubAccountList[2]);
        }
        [TestMethod]
        public void GetAccount_InValidUserNameAndValidPassword_ReturnsNull()
        {
            string inValidUserName = "011111111";
            string password = "1";

            var actual = _sut.GetAccount(inValidUserName, password);

            actual.Should().BeNull();
        }
        [TestMethod]
        public void GetAccount_ValidUserNameAndInValidPassword_ReturnsNull()
        {
            string ValidUserName = "0745664870";
            string inValidPassword = "1234";

            var actual = _sut.GetAccount(ValidUserName, inValidPassword);

            actual.Should().BeNull();
        }
        [TestMethod]
        public void GetAccount_InValidUserNameAndInValidPassword_ReturnsNull()
        {
            string inValidUserName = "011111111";
            string inValidPassword = "1234";

            var actual = _sut.GetAccount(inValidUserName, inValidPassword);

            actual.Should().BeNull();
        }
        [TestMethod]
        public void Insert_ValidInput_InsertToDatabaseSuccessfully()
        {
            var newAccount = new account()
            {
                is_active = true,
                pass = "1",
                permission_id = 1,
                staff_id = 1,
                username = "0945664870"
            };

            _sut.Insert(newAccount);

            _stubDbContext.Verify(c => c.accounts.Add(newAccount));

            _stubDbContext.Verify(c => c.SaveChanges());
        }
        [TestMethod]
        public void GetAccount_ValidUserNameAndPasswordButAccountDisable_ReturnsAccount()
        {
            string validUserName = "0245664870";// disabled account
            string validPassword = "1";

            var actual = _sut.GetAccount(validUserName, validPassword);

            actual.Should().BeNull();
        }

        [TestMethod]
        public void Update_ValidInput_UpdateDatabaseSuccessfully()
        {
            var accountUpdated = new account()
            {
                id = 1,
                is_active = true,
                pass = "1234",
                permission_id = 1,
                staff_id = 1,
                username = "0945664870"
            };

            _sut.Update(accountUpdated);

            _stubDbContext.Verify(c => c.AddOrUpdateEntity<account>(_stubDbContext.Object, accountUpdated));
            _stubDbContext.Verify(c => c.SaveChanges());
        }

        [TestMethod]
        public void Delete_ExistsId_DeleteInDatabaseSuccessfully()
        {
            int id = 1;

            _sut.Delete(id);

            var accFromDb = _stubDbContext.Object.accounts.FirstOrDefault(a => a.id == id);
            _stubDbContext.Verify(c => c.accounts.Remove(accFromDb), Times.Once);
            _stubDbContext.Verify(c => c.SaveChanges());
        }

        [TestMethod]
        public void Delete_NoneExistsId_ThrowArgumentOutOfRangeException()
        {
            int noneExistsId = 10;

            Action act = () => _sut.Delete(noneExistsId);

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

    }
}
