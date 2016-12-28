using Agl.DevTest.PetOwner.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agl.DevTest.PetOwner.UnitTest.Models;
using System.Web.Mvc;
using Agl.DevTest.PetOwner.Models;

namespace Agl.DevTest.PetOwner.Controllers.UnitTest
{
    [TestClass()]
    public class OwnerControllerTests
    {
        [TestMethod()]
        public void AllOwnersTest()
        {
            // Arrange
            OwnerController controller = new OwnerController(new MockServiceCaller(), new Helpers.DataProcessor());

            // Act
            ViewResult result = controller.AllOwners().Result as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(AllOwnersViewModel));
            Assert.AreEqual(result.ViewName, "AllOwners");

        }

        [TestMethod()]
        public void SortedOwnersTest()
        {
            // Arrange
            string petType = "cat";
            OwnerController controller = new OwnerController(new MockServiceCaller(), new Helpers.DataProcessor());

            // Act
            ViewResult result = controller.SortedOwners(petType).Result as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(SortedOwnerViewModel));
            Assert.AreEqual(result.ViewName, "SortedOwners");
        }


    }
}
