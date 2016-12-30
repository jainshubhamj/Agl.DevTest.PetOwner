using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agl.DevTest.PetOwner.Helpers;
using Agl.DevTest.PetOwner.Models;
using System.Collections.Generic;

namespace Agl.DevTest.PetOwner.UnitTest.Helpers
{
    [TestClass]
    public class DataProcessorTests
    {

        DataProcessor _dProcessor;

        public DataProcessorTests()
        {
            _dProcessor = new DataProcessor();
        }

        [TestMethod]
        public void SortByPetTypeTest_ValidInputs()
        {
            //Arrange
            string petTypeFilter = "Cat";
            List<OwnerDetail> lstOwnerDet = new List<OwnerDetail>();
            OwnerDetail owner = new OwnerDetail();
            owner.Name = "Shubh";
            owner.Age = 27;
            owner.Gender = "Male";
            owner.Pets = new List<Pet>();

            Pet pet1 = new Pet();
            pet1.Name = "Kitty";
            pet1.Type = "Cat";

            owner.Pets.Add(pet1);

            //Act
            Dictionary<string,List<string>> dictOwners = _dProcessor.SortByPetType(lstOwnerDet, petTypeFilter);

            //Assert
            Assert.IsNotNull(dictOwners);
            
        }

        [TestMethod]
        public void SortByPetTypeTest_NullInputs()
        {
            //Arrange
            string petTypeFilter = null;
            List<OwnerDetail> lstOwnerDet = null;
            
            //Act
            Dictionary<string, List<string>> dictOwners = _dProcessor.SortByPetType(lstOwnerDet, petTypeFilter);

            //Assert
            Assert.IsNotNull(dictOwners);
            Assert.AreEqual(dictOwners.Keys.Count, 0);

        }

        [TestMethod]
        public void SortByPetTypeTest_OnlyListNullInput()
        {
            //Arrange
            string petTypeFilter = "Cat";
            List<OwnerDetail> lstOwnerDet = null;

            //Act
            Dictionary<string, List<string>> dictOwners = _dProcessor.SortByPetType(lstOwnerDet, petTypeFilter);

            //Assert
            Assert.IsNotNull(dictOwners);
            Assert.AreEqual(dictOwners.Keys.Count, 0);

        }

        [TestMethod]
        public void SortByPetTypeTest_OneOwnerIsNull()
        {
            //Arrange
            string petTypeFilter = "Cat";
            List<OwnerDetail> lstOwnerDet = new List<OwnerDetail>();
            OwnerDetail owner = null;
            lstOwnerDet.Add(owner);

            //Act
            Dictionary<string, List<string>> dictOwners = _dProcessor.SortByPetType(lstOwnerDet, petTypeFilter);

            //Assert
            Assert.IsNotNull(dictOwners);
            Assert.AreEqual(dictOwners.Count, 0);
        }

        [TestMethod]
        public void SortByPetTypeTest_OwnersPetListIsNull()
        {
            //Arrange
            string petTypeFilter = "Cat";
            List<OwnerDetail> lstOwnerDet = new List<OwnerDetail>();
            OwnerDetail owner = new OwnerDetail();
            owner.Name = "Shubh";
            owner.Age = 27;
            owner.Gender = "Male";
            owner.Pets = new List<Pet>();

            Pet pet1 = null;

            owner.Pets.Add(pet1);

            //Act
            Dictionary<string, List<string>> dictOwners = _dProcessor.SortByPetType(lstOwnerDet, petTypeFilter);

            //Assert
            Assert.IsNotNull(dictOwners);
            Assert.AreEqual(dictOwners.Count, 0);
        }
    }
}
