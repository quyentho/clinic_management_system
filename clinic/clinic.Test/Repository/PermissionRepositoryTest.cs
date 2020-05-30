using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using clinic.Models;
using System.Data.Entity;
using clinic.Models.Repositories;

namespace clinic.Test.Repository
{
    [TestClass]
    public class PermissionRepositoryTest
    {
        [TestMethod]
        public void GetPermissionList_WhenCalled_ReturnsList()
        {
            var stubPermissionList = new List<permission>()
            {
                new permission(){ id = 1, position_name = "QUAN LY" },
                new permission(){id = 2, position_name = "BAC SI"},
                new permission(){id = 3, position_name = "Y SI"}
            };
            var mockPermissionRepo = new Mock<IPermissionRepository>();
            mockPermissionRepo.Setup(p => p.GetPermissionList()).Returns(stubPermissionList);

            var actual = mockPermissionRepo.Object.GetPermissionList();

            CollectionAssert.AreEqual(stubPermissionList, actual);
        }

        [TestMethod]
        public void GetPermissionList_WithMockContext_ReturnsList()
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

            var stubDbContext = new Mock<clinicEntities>();
            stubDbContext.Setup(c => c.permissions).Returns(stubPermissionDbSet.Object);
            stubDbContext.Setup(c => c.Set<permission>()).Returns(stubPermissionDbSet.Object);
            var mockPermissionRepo = new PermissionRepository(stubDbContext.Object);

            var actual = mockPermissionRepo.GetPermissionList();

            CollectionAssert.AreEqual(stubPermissionList.ToList(), actual);
        }
    }
}
