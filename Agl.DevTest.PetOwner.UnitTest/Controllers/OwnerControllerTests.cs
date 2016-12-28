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
        public void AllOwnersTest_Valid()
        {
            // Arrange
            OwnerController controller = new OwnerController(new MockServiceCaller(), new Helpers.DataProcessor());

            // Act
            ViewResult result = controller.AllOwners().Result as ViewResult;

            // Assert
            Assert.IsNotNull(result);            
            Assert.AreEqual(result.ViewName, string.Empty); // As View name is not mention in action            
            Assert.IsInstanceOfType(result.Model, typeof(AllOwnersViewModel));
            AllOwnersViewModel resultViewModel = result.Model as AllOwnersViewModel;
            Assert.IsNotNull(resultViewModel.OwnerDetails);
            Assert.IsTrue(resultViewModel.OwnerDetails.Count > 0);            
        }

        [TestMethod()]
        public void SortedOwnersTest_Valid()
        {
            // Arrange
            string petType = "cat";
            OwnerController controller = new OwnerController(new MockServiceCaller(), new Helpers.DataProcessor());

            // Act
            ViewResult result = controller.SortedOwners(petType).Result as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewName, string.Empty); // As View name is not mention in action
            Assert.IsInstanceOfType(result.Model, typeof(SortedOwnerViewModel));
            SortedOwnerViewModel resultViewModel = result.Model as SortedOwnerViewModel;
            Assert.IsNotNull(resultViewModel.GenderWiseNames);
            Assert.IsTrue(resultViewModel.GenderWiseNames.Count > 0);
            Assert.IsTrue(resultViewModel.GenderWiseNames.Keys.Count == 2);

        }

        [TestMethod()]
        public void SortedOwnersTest_NullInput()
        {
            // Arrange
            string petType = null;
            OwnerController controller = new OwnerController(new MockServiceCaller(), new Helpers.DataProcessor());

            // Act
            ViewResult result = controller.SortedOwners(petType).Result as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewName, string.Empty); // As View name is not mention in action
            Assert.IsInstanceOfType(result.Model, typeof(SortedOwnerViewModel));
            SortedOwnerViewModel resultViewModel = result.Model as SortedOwnerViewModel;
            Assert.IsNull(resultViewModel.GenderWiseNames);            
        }
        
        [TestMethod()]
        public void SortedOwnersTest_IncorrectInput()
        {
            // Arrange
            string petType = "incorrect";
            OwnerController controller = new OwnerController(new MockServiceCaller(), new Helpers.DataProcessor());

            // Act
            ViewResult result = controller.SortedOwners(petType).Result as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewName, string.Empty); // As View name is not mention in action
            Assert.IsInstanceOfType(result.Model, typeof(SortedOwnerViewModel));
            SortedOwnerViewModel resultViewModel = result.Model as SortedOwnerViewModel;
            Assert.IsNotNull(resultViewModel.GenderWiseNames);
            Assert.IsTrue(resultViewModel.GenderWiseNames.Count == 0);            

        }

    }
}
